using ContactsExam.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Categories
{
    public class CategoryList : List<Category>, IDisposable
    {
        public bool AddCategory(Category category)
        {
            if (this.Count > 10)
            {
                return false;
            }
            if (Contains(category))
            {
                return false;
            }
            Add(category);
            return true;
        }
        public bool RemoveCategory(Category category)
        {
            if (!Contains(category))
            {
                return false;
            }
            Remove(category);
            return true;
        }
        public bool Contains(Category category)
        {
            return this.Any(x => x.Equals(category));
        }
        public override string ToString()
        {
            string tmp = string.Empty;
            int i = 1;
            foreach (Category c in this)
            {
                tmp += $"{i++} - {c.ToString()}\n";
            }
            return tmp;
        }

        public void Dispose()
        {
            FileController.GetInstance().WriteInfo(this);
        }
    }
}
