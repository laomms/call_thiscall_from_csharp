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
        [DllImport("thiscallDll.dll", EntryPoint = "?func_thiscall@TestClass@@QAEHHHHH@Z", CallingConvention = CallingConvention.ThisCall)] //类成员函数
        private static extern int _func_thiscall(ThisCallClass.TestClass ths, int a, int b, int c, int d);
        static void Main(string[] args)
        {
            ThisCallClass class1 = new ThisCallClass(1);
            int res= _func_thiscall(ThisCallClass.class1, 3, 4,5,6);
            Console.WriteLine(res.ToString());
            class1.Dispose();
            Console.ReadLine();
        }

     }
}
