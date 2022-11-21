using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Category)}: {Category}, {nameof(Number)}: {Number}";
        }

        protected bool Equals(Product other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
