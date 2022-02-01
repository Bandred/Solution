using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Enum
{
    public abstract class EnumHelper : IComparable
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        protected EnumHelper()
        {
        }

        protected EnumHelper(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public int CompareTo(object obj)
        {
            return Id.CompareTo(((EnumHelper)obj).Id);
        }
    }
}
