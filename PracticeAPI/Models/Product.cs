using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOM { get; set; }
        public DateTime DOE { get; set; }
        public bool Active { get; set; }

    
    }
}