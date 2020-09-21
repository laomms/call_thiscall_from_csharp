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
        [DllImport("thiscallDll.dll", EntryPoint = "?func_thiscall@TestClass@@QAEHHHHHH@Z", CallingConvention = CallingConvention.ThisCall)] //类成员函数
        private static extern int func_thiscall(ThisCallClass.TestClass ths, int a, int b, int c, int d, int e);
        
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int func_thiscall3(ThisCallClass.TestClass ths, int a, int b, int c, int d, int e);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        delegate int func_thiscall2( int a, int b, int c, int d, int e);
        static void Main(string[] args)
        {
            ThisCallClass class1 = new ThisCallClass(1);
            int res= func_thiscall(ThisCallClass.class1, 3, 4, 5, 6, 7);
            Console.WriteLine(res.ToString());
            IntPtr hDll= LoadLibrary("thiscallDll.dll");
            func_thiscall3 func3 = (func_thiscall3)Marshal.GetDelegateForFunctionPointer(IntPtr.Add(hDll, 0x11680), typeof(func_thiscall3));
            res = func3(ThisCallClass.class1, 3, 4, 5, 6, 7);
            Console.WriteLine(res.ToString());
            func_thiscall2 func2 = (func_thiscall2)Marshal.GetDelegateForFunctionPointer(IntPtr.Add(hDll, 0x11680), typeof(func_thiscall2));
            res = func2( 3, 4, 5, 6, 7);
            Console.WriteLine(res.ToString());
            class1.Dispose();
            Console.ReadLine();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
    }
}
