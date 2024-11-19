using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ECart.Models;

namespace ECart.DBAccess
{
    public class ECartDBContext: DbContext
    {
        public ECartDBContext() : base("Constr")
        {

        }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Product> ProductsTable { get; set; }

    }
}