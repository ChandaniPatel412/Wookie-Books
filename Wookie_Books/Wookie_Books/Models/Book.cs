using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wookie_Books.Models
{
    public class Book
    {
        public Int32 Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public float Price { get; set; }
    }
}
