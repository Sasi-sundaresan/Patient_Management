using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Exceptions
{
    public class PatientnotFoundException : Exception
    {
        public PatientnotFoundException() : base("Patient was not found") 
        { }
        public PatientnotFoundException(string message) : base(message)
        {

        }
    }
}
