using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class MyErrorResponse
    {
        public int  code { get; set; }
        public string type { get; set; }
        public string Message { get; set; }

        public MyErrorResponse(Exception ex,int code)
        {
            this.code = code;
            type = ex.GetType().Name;
            Message = ex.Message;
           
        }
    }
}
