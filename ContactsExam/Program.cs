using ContactsExam.Controllers;
using ContactsExam.Models.Locales;

ConsoleKeyInfo key= new ConsoleKeyInfo();
Locale locale = new LocaleEN();
Console.WriteLine("Choose language:\n1 - EN\n2 - RU\nESC - Exit");
key = Console.ReadKey(true);
do
{
    if (key.KeyChar == '1')
    {
        Console.Clear();
        ViewController.GetInstance(locale).RunClient();
    }
    else if (key.KeyChar == '2')
    {
        locale = new LocaleRU();
        ViewController.GetInstance(locale).RunClient();
    }
    else if (key.KeyChar == 27)
    {
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine(locale.ErrorText);
    }
} while (true);