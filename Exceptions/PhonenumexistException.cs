using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Exceptions
{
    public class PhonenumexistException : Exception
    {
        public PhonenumexistException() :base("Patient already has the given phone number") 
        {

        }
        public PhonenumexistException(string message) : base(message) { }

    }
}
