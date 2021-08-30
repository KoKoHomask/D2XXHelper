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
            var openStatus = fTDI.OpenByIndex(0);
            var baudStatus = fTDI.SetBaudRate(3000000);
            var dtr=fTDI.SetDTR(true);
            var rts = fTDI.SetRTS(true);
            var closeSattus = fTDI.Close();
            Console.WriteLine("Hello World!");
            Console.WriteLine(res);
            Console.WriteLine(openStatus);
            Console.WriteLine(baudStatus);
            Console.WriteLine(closeSattus);
            Console.WriteLine(dtr);
            Console.WriteLine(rts);

            Console.WriteLine("Hello World!");
        }
    }
}
