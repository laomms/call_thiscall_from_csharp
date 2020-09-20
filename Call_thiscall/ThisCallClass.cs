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
        public static TestClass class1;//虚构类
        IntPtr ptr;      
        public ThisCallClass(int value)
        {
           ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TestClass)));
           class1 = (TestClass)Marshal.PtrToStructure(ptr, typeof(TestClass));
        }
        public void Dispose()
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}
