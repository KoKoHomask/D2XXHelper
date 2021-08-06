using D2XXHelper;
using System;

namespace TestSample
{
    class Program
    {
        static void Main(string[] args)
        {
            D2XXHelper.D2XX fTDI = new D2XXHelper.D2XX();
            var infolst = new FT_DEVICE_INFO_NODE[100];
            var res = fTDI.GetDeviceList(infolst);
            if (infolst[0] == null) return;
            uint id = infolst[0].ID;
            var openStatus = fTDI.OpenByIndex(2);
            var baudStatus = fTDI.SetBaudRate(12000000);
            var closeSattus = fTDI.Close();
            Console.WriteLine("Hello World!");
            Console.WriteLine(res);
            Console.WriteLine(openStatus);
            Console.WriteLine(baudStatus);
            Console.WriteLine(closeSattus);

            Console.WriteLine("Hello World!");
        }
    }
}
