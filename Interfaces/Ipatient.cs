using Patient_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Interfaces
{
    public interface Ipatient
    {
        public Patient Login(int Id, string Password);
        public Patient PatientRegiter();

        public IEnumerable<Patient>  GetPatientById(int id);

    }
}
