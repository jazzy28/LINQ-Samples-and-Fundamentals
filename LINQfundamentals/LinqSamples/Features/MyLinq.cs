using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {
        public static int Count(this IEnumerable<Task> sequence)//by adding this to this metod, we can invoke it
        {
            int count = 0;
            foreach(var item in sequence)
            {
                count += 1;
            }
            return count;
        }
    }
}
