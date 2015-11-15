using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4.Models
{
    public class ToDoItem
    {
        public ToDoItem(string item)
        {
            Item = item;
            DateAdded = DateTime.Now.ToString();
        }

        public ToDoItem()
        {
            DateAdded = DateTime.Now.ToString();
        }

        public int Id { get; set; }
        [Required]
        public string Item { get; set; }
        public string DateAdded { get; private set; }
        public bool IsCompleted { get; set; }
    }
}