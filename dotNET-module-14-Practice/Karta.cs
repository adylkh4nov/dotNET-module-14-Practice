using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_module_14_Practice
{
    public class Karta
    {
        public string Mast { get; set; }
        public string Nominal { get; set; }

        public Karta(string mast, string nominal)
        {
            Mast = mast;
            Nominal = nominal;
        }
    }
}
