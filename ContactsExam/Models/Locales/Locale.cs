using ContactsExam.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Locales
{
    public abstract class Locale
    {
        public string Path { get; set; }
        public string PathCat { get; set; }
        public string LocaleName { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string CreationDate { get; set; }
        public string ErrorText { get; set; }
        public string Success { get; set; }
        public string CategoryMenu { get; set; }
        public string ContactMenu { get; set; }
        public string FilterMenu { get; set; }
        public string EnterChar { get; set; }
        public string AddCategory { get; set; }
        public string ViewCategories { get; set; }
        public string[] AddContactMenu { get; set; }
        public string[] EditContactMenu { get; set; }
        private Locale() { }
        public Locale(
            string path, 
            string pathCat,
            string localeName, 
            string name, 
            string category, 
            string telNo, 
            string email, 
            string creationDate, 
            string errorText, 
            string success,
            string categoryMenu, 
            string contactMenu, 
            string filterMenu,
            string enterChar,
            string addCategory,
            string viewCategories,
            string[] addContactMenu,
            string[] editContactMenu)
        {
            Path = path;
            PathCat = pathCat;
            LocaleName = localeName;
            Name = name;
            Category = category;
            TelNo = telNo;
            Email = email;
            CreationDate = creationDate;
            ErrorText = errorText;
            Success = success;
            CategoryMenu = categoryMenu;
            ContactMenu = contactMenu;
            FilterMenu = filterMenu;
            EnterChar = enterChar;
            AddCategory = addCategory;
            ViewCategories = viewCategories;
            AddContactMenu = addContactMenu;
            EditContactMenu = editContactMenu;
        }
    }
}
