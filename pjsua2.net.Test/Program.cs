﻿using System;

namespace pjsua2.net.Test
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("IctBaden.pjsua2.net");
            Console.WriteLine();

            try
            {
                var pjsipVersion = pjsip.PjsipInfo.GetVersionInfo();
                Console.WriteLine("INFO: " + pjsipVersion);

                var ep = new Endpoint();
                ep.libCreate();

                var cfg = new EpConfig();
                ep.libInit(cfg);
                ep.libStart();

                var ver = ep.libVersion();
                var epVersion = $"PJSIP V{ver.full}";
                Console.WriteLine("INFO: " + epVersion);
                if (pjsipVersion != epVersion)
                {
                    Console.WriteLine("FAILED: Versions should be equal.");
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Environment.Exit(99);
            }

            Console.WriteLine("SUCEEDED: Test ok.");
            Environment.Exit(0);
        }
    }
}