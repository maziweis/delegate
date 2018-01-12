using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托事件
{
    public class CompareDog:IComparer<Dog>
    {
        public int Compare(Dog x, Dog y)
        {
            return x.age - y.age;
        }
    }
}
