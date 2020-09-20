using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Call_thiscall.Program;

namespace Call_thiscall
{
    public unsafe class ThisCallClass : IDisposable
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct TestClass
        {
            public IntPtr _vtable;
        }

        private TestClass* class1;//虚构类

        [DllImport("thiscallDll.dll", EntryPoint = "?func_thiscall@TestClass@@QAEHHHHH@Z", CallingConvention = CallingConvention.ThisCall)] //类成员函数
        private static extern int _func_thiscall(TestClass* ths, int a, int b, int c, int d);
        public ThisCallClass(int value)
        {
            class1 = (TestClass*)Marshal.AllocHGlobal(sizeof(TestClass));
        }
        public void Dispose()
        {
            Marshal.FreeHGlobal((IntPtr)class1);
            class1 = null;
        }
        public int func_thiscall(int a, int b, int c, int d)
        {
            return _func_thiscall(class1, a,  b,  c,  d);
        }

    }
}
