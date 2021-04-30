using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MavelArtist.Models
{
    public class DataRespone<T>
    {
        public bool Ok { get; set; }
        public T data { get; set; }
        public string error { get; set; }
    }
}
