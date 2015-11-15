using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Week4.Models
{
    public class ToDoItemsDBContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}