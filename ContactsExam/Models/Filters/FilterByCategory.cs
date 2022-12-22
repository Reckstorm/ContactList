using ContactsExam.Models.Categories;
using ContactsExam.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Filters
{
    public class FilterByCategory : IFilter
    {
        public ContactsList Filter(object? obj, ContactsList contactsList)
        {
            if (obj == null) return null;
            Category filter = obj as Category;
            ContactsList temp = new ContactsList();
            temp.AddRange(contactsList.FindAll(x => x.Category.Equals(filter)));
            return temp;
        }
    }
}
