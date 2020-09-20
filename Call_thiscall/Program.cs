using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Call_thiscall
{
    class Program
    {
        static void Main(string[] args)
        {
            ThisCallClass class1 = new ThisCallClass(1);
            int res= class1.func_thiscall(3,4,5,6);
            Console.WriteLine(res.ToString());
            class1 = null;
            Console.ReadLine();
        }

     }
}
