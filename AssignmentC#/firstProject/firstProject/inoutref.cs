using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstProject
{
    class inoutref
    {
        public static int Program(ref int i,out int j,in int k)
        {
            i += 1;
            j = k;
            return j;
        }
        public static void Main(string[] args)
        {
            int i, j, k;
            i = 0;
            k = 0;
            Console.WriteLine(Program(ref i, out j,in k));
            i += 1;
            j +=1;
            Console.WriteLine($"{i},{j}");
        }
    }
}
