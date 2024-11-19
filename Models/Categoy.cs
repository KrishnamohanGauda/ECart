using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECart.Models
{

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 
        public virtual ICollection<Product> Products { get; set; }

    }
}