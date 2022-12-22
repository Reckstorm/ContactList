using ContactsExam.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Filters
{
    public class FilterByLetter : IFilter
    {
        public ContactsList Filter(object? obj, ContactsList contactsList)
        {
            if (obj == null) return null;
            char? filter = (char?)obj;
            ContactsList temp = new ContactsList();
            temp.AddRange(contactsList.FindAll(x => x.FirstName[0].Equals(filter)));
            return temp;
        }
    }
}
