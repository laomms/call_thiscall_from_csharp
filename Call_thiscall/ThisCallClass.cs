using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Call_thiscall.Program;

namespace Call_thiscall
{
    public class ThisCallClass : IDisposable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct TestClass
        {
            public IntPtr vtable;
        }
        private TestClass class1;//虚构类
        IntPtr ptr;
        [DllImport("thiscallDll.dll", EntryPoint = "?func_thiscall@TestClass@@QAEHHHHH@Z", CallingConvention = CallingConvention.ThisCall)] //类成员函数
        private static extern int _func_thiscall(TestClass ths, int a, int b, int c, int d);
        public ThisCallClass(int value)
        {
           ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TestClass)));
           class1 = (TestClass)Marshal.PtrToStructure(ptr, typeof(TestClass));
        }
        public void Dispose()
        {
            Marshal.FreeHGlobal(ptr);
        }
        public int func_thiscall(int a, int b, int c, int d)
        {
            return _func_thiscall(class1, a,  b,  c,  d);
        }

    }
}
