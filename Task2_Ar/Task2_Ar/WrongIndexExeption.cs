using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Ar
{
    public class WrongIndexExeption : Exception
    {
        public WrongIndexExeption(string message) : base(message) { }
    }
}
