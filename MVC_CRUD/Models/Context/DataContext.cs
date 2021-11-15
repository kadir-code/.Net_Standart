using MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.Context
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
            Database.Connection.ConnectionString = @"Server=<Server Name>;Database=<Database Name>;Integrated Security=true;";
        }
        public DbSet<Category> Categories { get; set; }
    }
}
