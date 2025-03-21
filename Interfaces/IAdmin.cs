using Patient_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Interfaces
{
    internal interface IAdmin
    {
        public Patient AdminLogin(string Id, string Password);
        public bool ChangePatientPhoneNumber(int patientId, string newPhoneNumber);


    }
}
