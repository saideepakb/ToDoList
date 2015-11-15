using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace Week4.Models
{
    public class ToDoItemsDbConfiguration : DropCreateDatabaseIfModelChanges<ToDoItemsDBContext>
    {
        protected override void Seed(ToDoItemsDBContext context)
        {
            context.ToDoItems.AddOrUpdate(x => x.Item, new[] {
            new ToDoItem
            {
                Item = "Call mom"
            }
            });
        }
    }
}