using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MavelArtist.Errors
{
    public class MyNotFoundException : Exception
    {

        public HttpStatusCode HttpStatusCode { get;set; }

        public MyNotFoundException(HttpStatusCode httpStatusCode,string msg):base(msg)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
