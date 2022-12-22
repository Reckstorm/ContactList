using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Locales
{
    public class LocaleEN : Locale
    {
        public LocaleEN() : base(
            "ContactsEN.json",
            "CategoriesEN.json",
            "LocaleEN",
            "Name: ",
            "Category: ",
            "Phone: ",
            "Email: ",
            "Creation date: ",
            "Invalid data",
            "Success",
            "Choose Action:\n1 - View all categories\n2 - Add category\n3 - Remove category\nESC - go back\n",
            "Choose Action:\n1 - View all contacts\n2 - Add contact\n3 - Edit contact\n4 - Remove contact\n5 - View filtered contacts list\n6 - Categories menu\nESC - Exit\n",
            "Choose Action:\n1 - View all current month contacts\n2 - View contacts starting with letter *\n3 - View contacts according the category\nESC - go back\n",
            "Choose char to filter with:\n",
            "Enter category name: ",
            "Categories:\n",
             new string[] { "Enter first name: ", "Enter last name: ", "Enter phone number: ", "Enter email: " },
             new string[] { "1 - Change first name", "2 - Change last name", "3 - Change phone number", "4 - Change email", "5 - Change category", "Esc - Go back" }
            )  {  }
    }
}