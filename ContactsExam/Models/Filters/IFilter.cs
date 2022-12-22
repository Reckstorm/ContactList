using ContactsExam.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Filters
{
    interface IFilter
    {
        ContactsList Filter(object? obj, ContactsList contactsList);
    }
}
