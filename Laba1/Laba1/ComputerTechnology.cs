using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba1;

namespace Laba1
{
    public class ComputerTechnology : IPrintable
    {
        public string Manufacturer { get; protected set; }

        public ComputerTechnology()
        {
            Manufacturer = "DEXP";
        }

        public ComputerTechnology(string manufacturer)
        {
            Manufacturer = manufacturer;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Manufacturer: {Manufacturer}");
        }
    }
}