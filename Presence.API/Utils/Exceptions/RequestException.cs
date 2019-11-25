using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presence.API.Utils.Exceptions
{
    public class RequestException : Exception
    {
        private readonly HttpStatusCode _status;

        public RequestException(HttpStatusCode status)
        {
            this._status = status;
        }

        public RequestException(HttpStatusCode status, string message)
            : base(message)
        {
            this._status = status;
        }

        public RequestException(HttpStatusCode status, string message, Exception inner)
            : base(message, inner)
        {
            this._status = status;
        }

        public HttpStatusCode GetStatus()
        {
            return this._status;
        }
    }
}
