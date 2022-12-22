using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsExam.Models.Categories;

namespace ContactsExam.Models.Contacts
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Category Category { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public Contact()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Category= new Category();
            TelNo= string.Empty;
            Email= string.Empty;
            CreationDate= DateTime.Now;
        }
        public Contact(string FirstName, string LastName, string TelNo, string Email, Category Category)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Category = Category;
            this.TelNo = TelNo;
            this.Email = Email;
            CreationDate = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}\n{TelNo}\n{Email}\n{CreationDate.ToShortDateString()}\n{Category}\n";
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + Category.GetHashCode() + TelNo.GetHashCode() + Email.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Contact contact = obj as Contact;
            if (contact == null) return false;
            return GetHashCode().Equals(contact.GetHashCode());
        }
    }
}
