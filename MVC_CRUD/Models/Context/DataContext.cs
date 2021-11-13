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
            Database.Connection.ConnectionString = @"Server=DESKTOP-J1PKMI5\SQLEXPRESS;Database=MyMVCCRUDDataBase;Integrated Security=true;";
        }
        public DbSet<Category> Categories { get; set; }
    }
}