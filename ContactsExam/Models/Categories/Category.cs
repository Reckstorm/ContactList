using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsExam.Models.Categories
{
    public class Category
    {
        public string Name { get; set; }
        public Category()
        {
            Name = string.Empty;
        }
        public Category(string name)
        {
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Category other = obj as Category;
            if (other == null) return false;
            return Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
