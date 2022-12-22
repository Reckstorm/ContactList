using ContactsExam.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Filters
{
    public class FilterCurrentMonth : IFilter
    {
        public ContactsList Filter(object? obj, ContactsList contactsList)
        {
            if (obj == null) return null;
            int? filter = obj as int?;
            ContactsList temp = new ContactsList();
            temp.AddRange(contactsList.FindAll(x => x.CreationDate.Month.Equals(filter)));
            return temp;
        }
    }
}
