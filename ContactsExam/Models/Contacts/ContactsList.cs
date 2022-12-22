using ContactsExam.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsExam.Models.Categories;

namespace ContactsExam.Models.Contacts
{
    public class ContactsList : List<Contact>, IDisposable
    {
        public CategoryList Categories { get; set; }

        public bool Contains(Contact contact)
        {
            return this.Any(x => x.Equals(contact));
        }
        public int FindIndexByName(string name)
        {
            return this.FindIndex(x => x.FirstName.Equals(name));
        }
        public bool AddContact(Contact contact)
        {
            if (Contains(contact))
            {
                return false;
            }
            Add(contact);
            if (Categories == null)
            {
                Categories = new CategoryList();
            }
            Categories.AddCategory(contact.Category);
            return true;
        }
        public bool RemoveContactByName(string name)
        {
            int i = this.FindIndexByName(name);
            if (i == -1)
            {
                return false;
            }
            this.RemoveAt(i);
            return true;
        }
        public void Dispose()
        {
            Categories.Dispose();
            FileController.GetInstance().WriteInfo(this);
        }
        public override string ToString()
        {
            string temp = string.Empty;
            foreach (Contact c in this)
            {
                temp += c + "\n";
            }
            return temp;
        }
    }
}
