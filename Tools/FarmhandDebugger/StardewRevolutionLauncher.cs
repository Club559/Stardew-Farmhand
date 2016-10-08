﻿using System;
using System.Reflection;

namespace FarmhandDebugger
{
    public class StardewFarmhandLauncher
    {
        private Assembly _FarmhandAssembly;
        public Assembly FarmhandAssembly => _FarmhandAssembly ?? (_FarmhandAssembly = Assembly.LoadFrom(Constants.FarmhandExeName));

        public bool Launch()
        {
            if (FarmhandAssembly == null)
                return false;
                        
            Console.WriteLine("Starting Stardew Valley...");
            try
            {
                FarmhandAssembly.EntryPoint.Invoke(null, new object[] { new string[0] });
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
