using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solstat.Library
{
    public class Category
    {
        private readonly string _name;
        private readonly IList<CategoryValue> _values = new List<CategoryValue>();

        public Category(string name)
        {
            _name = name;
        }

        public string Name { get { return _name; } }
        public IList<CategoryValue> Values { get { return _values; } }
    }
}
