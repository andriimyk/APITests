using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Classes
{
    class SpecialExeption : Exception
    {

        public SpecialExeption(string message)
                : base(message)
        {
            message = "This is special exeption";
        }
        
    }
}
