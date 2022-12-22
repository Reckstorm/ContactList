using ContactsExam.Models.Categories;
using ContactsExam.Models.Contacts;
using ContactsExam.Models.Filters;
using ContactsExam.Models.Locales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Controllers
{
    public class ViewController
    {
        private static Locale _locale { get; set; }
        private static ViewController _viewController { get; set; }
        private static ContactsList _contacts { get; set; }

        public static ViewController GetInstance(Locale locale)
        {
            if (_viewController == null)
            {
                _viewController = new ViewController();
                _locale = locale;
                _contacts = FileController.GetInstance(_locale.Path, _locale.PathCat).ReadInfo();
            }
            return _viewController;
        }
        public void RunClient()
        {
            Contact temp;
            string[] str = { string.Empty, string.Empty, string.Empty, string.Empty };
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(_locale.ContactMenu);
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    Console.Clear();
                    PrintContacts(_contacts);
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == '2')
                {
                    for (int i = 0; i < _locale.AddContactMenu.Length; i++)
                    {
                        Console.Clear();
                        Console.WriteLine(_locale.AddContactMenu[i]);
                        str[i] = Console.ReadLine();
                    }
                    temp = new Contact(str[0], str[1], str[2], str[3], CategoryPick());
                    PrintResult(_contacts.AddContact(temp));
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == '3')
                {
                    Console.Clear();
                    Console.WriteLine(_locale.AddContactMenu[0]);
                    str[0] = Console.ReadLine();
                    PrintResult(_contacts.RemoveContactByName(str[0]));
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == '4')
                {
                    PrintContacts(FilterControl());
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == '5')
                {
                    CategoryControl();
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == 27)
                {
                    _contacts.Dispose();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(_locale.ErrorText);
                }
            } while (true);
        }
        private void CategoryControl()
        {
            string str;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(_locale.CategoryMenu);
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    Console.Clear();
                    Console.WriteLine(_contacts.Categories);
                    Console.ReadKey(true);
                }
                else if(key.KeyChar == '2')
                {
                    Console.Clear();
                    Console.WriteLine(_locale.AddCategory);
                    str = Console.ReadLine();
                    PrintResult(_contacts.Categories.AddCategory(new Category(str)));
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == '3')
                {
                    Console.Clear();
                    PrintResult(_contacts.Categories.RemoveCategory(CategoryPick()));
                    Console.ReadKey(true);
                }
                else if (key.KeyChar == 27)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(_locale.ErrorText);
                    Console.ReadKey(true);
                }
            } while (true);

        }
        private Category CategoryPick()
        {
            Category category = new Category();
            ConsoleKeyInfo key;
            do
            {
                if (_contacts.Categories.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine(_locale.AddCategory);
                    PrintResult(_contacts.Categories.AddCategory(new Category(Console.ReadLine())));
                    Console.ReadKey(true);
                }
                Console.Clear();
                Console.WriteLine(_locale.ViewCategories);
                Console.WriteLine(_contacts.Categories);
                key = Console.ReadKey(true);
                if (key.KeyChar < 48 || key.KeyChar > 58)
                {
                    Console.WriteLine(_locale.ErrorText);
                    Console.ReadKey(true);
                    continue;
                }
                else if (key.KeyChar == 27)
                {
                    break;
                }
                category = _contacts.Categories[int.Parse(key.KeyChar.ToString())-1];
                break;
            } while (true);
            return category;
        }
        private ContactsList FilterControl()
        {
            IFilter filter;
            ConsoleKeyInfo key;
            ContactsList contacts = new ContactsList();
            do
            {
                Console.Clear();
                Console.WriteLine(_locale.FilterMenu);
                key = Console.ReadKey(true);
                if (key.KeyChar == '1')
                {
                    filter = new FilterCurrentMonth();
                    contacts = filter.Filter(DateTime.Now.Month, _contacts);
                    break;
                }
                else if (key.KeyChar == '2')
                {
                    Console.Clear();
                    filter = new FilterByLetter();
                    Console.WriteLine(_locale.EnterChar);
                    key = Console.ReadKey(false);
                    Console.WriteLine();
                    contacts = filter.Filter(key.KeyChar, _contacts);
                    break;
                }
                else if (key.KeyChar == '3')
                {
                    Console.Clear();
                    filter = new FilterByCategory();
                    contacts = filter.Filter(CategoryPick(), _contacts);
                    break;
                }
                else if (key.KeyChar == 27)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(_locale.ErrorText);
                }
            } while (true);
            return contacts;
        }
        private void PrintContacts(ContactsList contacts)
        {
            foreach (Contact contact in contacts)
            {
                string[] strings = contact.ToString().Split('\n');
                Console.WriteLine(
                    $"{_locale.Name}{strings[0]}\n" +
                    $"{_locale.TelNo}{strings[1]}\n" +
                    $"{_locale.Email}{strings[2]}\n" +
                    $"{_locale.CreationDate}{strings[3]}\n" +
                    $"{_locale.Category}{strings[4]}\n");
            }
        }
        private void PrintResult(bool res)
        {
            if (res)
            {
                Console.WriteLine(_locale.Success);
            }
            else
            {
                Console.WriteLine(_locale.ErrorText);
            }
        }
    }
}