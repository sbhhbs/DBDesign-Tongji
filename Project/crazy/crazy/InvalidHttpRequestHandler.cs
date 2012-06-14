using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;



namespace crazy
{
    public class InvalidHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/InvalidWebRequestHandler";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse serverResponse = context.Response;

            // Indicate the failure as a 404 not found
            serverResponse.StatusCode = (int)HttpStatusCode.NotFound;

            // Fill in the response body
            string message = "Could not find resource.";
            byte[] messageBytes = Encoding.Default.GetBytes(message);
            serverResponse.OutputStream.Write(messageBytes, 0, messageBytes.Length);

            // Send the HTTP response to the client
            serverResponse.Close();

            // Print a message to console indicate invalid request as well
            Console.WriteLine("Invalid request from client. Request string: "
                + context.Request.RawUrl);
        } // end public void handle(HttpListenerContext context)

        public string GetName()
        {
            return NAME;
        } // end public string GetName()

    } // end public class InvalidHttpRequestHandler

}