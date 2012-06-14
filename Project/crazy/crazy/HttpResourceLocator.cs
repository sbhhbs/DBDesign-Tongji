using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Threading;


namespace crazy
{
    
    public class HttpResourceLocator
    {
        private Dictionary<string, HttpRequestHandler> _httpRequestHandlers;

        public HttpResourceLocator()
        {
            _httpRequestHandlers = new Dictionary<string, HttpRequestHandler>();
            // Add the default handler that will handle invalid web request
            this.AddHttpRequestHandler(new InvalidHttpRequestHandler());

        } // end private HttpRequestController()

        public void AddHttpRequestHandler(HttpRequestHandler httpRequestHandler)
        {
            // If the httpRequestHandler is not yet added
            if (!_httpRequestHandlers.ContainsKey(httpRequestHandler.GetName()))
            {
                // Add a new record
                _httpRequestHandlers.Add(httpRequestHandler.GetName(), httpRequestHandler);
            }
            else
            {
                // Replace it
                _httpRequestHandlers[httpRequestHandler.GetName()] = httpRequestHandler;
            }
        } // end public void AddHttpRequestHandler(HttpRequestHandler httpRequestHandler)

        public void HandleContext(HttpListenerContext listenerContext)
        {

            // Search for the requested handler
            HttpListenerRequest request = listenerContext.Request;
            // Use the absolute path of the url to find the request
            // handler
            string requestHandlerName = request.Url.AbsolutePath;

            // Find the request handler to handle the request

            HttpRequestHandler handler;
            // If request handler is found
            if (_httpRequestHandlers.ContainsKey(requestHandlerName))
            {
                // Get the corresponding request handler
                handler = _httpRequestHandlers[requestHandlerName];
            }
            else
            {
                // Use the InvalidHttpRequestHandler to handle the request
                handler = _httpRequestHandlers[InvalidHttpRequestHandler.NAME];
            } // end if 

            this.InvokeHandler(handler, listenerContext);

        } // end public void handleContext(HttpListenerContext listenerContext)

        private void InvokeHandler(HttpRequestHandler handler,
            HttpListenerContext context)
        {
            // Start a new thread to invoke the handler to process the HTTP request
            HandleHttpRequestCommand handleHttpRequestCommand
                = new HandleHttpRequestCommand(handler, context);
            Thread handleHttpRequestThread = new Thread(handleHttpRequestCommand.Execute);
            handleHttpRequestThread.Start();
        } // end private void InvokeHandler(HttpRequestHandler handler,
        //         HttpListenerContext context)

        // Helper class for invoking handler to process
        // HTTP request
        public class HandleHttpRequestCommand
        {
            private HttpRequestHandler _handler;
            private HttpListenerContext _context;

            public HandleHttpRequestCommand(HttpRequestHandler handler,
                HttpListenerContext context)
            {
                this._handler = handler;
                this._context = context;
            }

            public void Execute()
            {
                this._handler.Handle(this._context);
            }
        } // end public class HandleHttpRequestCommand

    } // end public class HttpResourceLocator
}
