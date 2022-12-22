using ContactsExam.Models.Categories;
using ContactsExam.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContactsExam.Controllers
{
    public sealed class FileController
    {
        private static string _path;
        private static string _pathCategories;

        private static FileController _instance;

        private FileController() { }
        public static FileController GetInstance(string? path = "", string? pathCategories = "")
        {
            if (_instance == null)
            {
                _path = path;
                _pathCategories = pathCategories;
                _instance = new FileController();
            }
            return _instance;
        }

        public void WriteInfo(ContactsList list) => File.WriteAllText(_path, JsonSerializer.Serialize(list));
        public void WriteInfo(CategoryList list) => File.WriteAllText(_pathCategories, JsonSerializer.Serialize(list));
        public ContactsList ReadInfo()
        {
            ContactsList temp = new ContactsList();
            CategoryList tempCat = new CategoryList();
            if (File.Exists(_path))
            {
                string tempContacts = File.ReadAllText(_path);
                temp = JsonSerializer.Deserialize<ContactsList>(tempContacts);
            }
            if (File.Exists(_pathCategories))
            {
                string tempCategories = File.ReadAllText(_pathCategories);
                tempCat = JsonSerializer.Deserialize<CategoryList>(tempCategories);
            }
            temp.Categories = tempCat;
            return temp;
        }
    }
}