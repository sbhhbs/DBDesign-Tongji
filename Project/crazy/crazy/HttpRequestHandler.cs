using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace crazy
{
    public interface HttpRequestHandler
    {
        void Handle(HttpListenerContext context);

        string GetName();

    } // end public interface HttpRequestHandler
}
