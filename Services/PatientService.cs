using Patient_Management.Exceptions;
using Patient_Management.Interfaces;
using Patient_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Services
{
    public class PatientService : Ipatient , IAdmin
    {
        List<Patient> patients = new List<Patient>();

        public Patient AdminLogin(string Id, string Password)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (Id.ToLower() == "admin" && Password.ToLower() == "admin")
                {
                    return patients[i];
                }
            }
            return null;

        }

        public bool ChangePatientPhoneNumber(int patientId, string newPhoneNumber)
        {
            if (patients.Count == 0)
            {
                throw new PatientnotFoundException();
            }

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id == patientId)
                {
                    if (patients[i].PhoneNumber == newPhoneNumber)
                    {
                        throw new PhonenumexistException();
                    }
                    patients[i].PhoneNumber = newPhoneNumber;
                    return true;
                }
            }
            return false;

           
        }




        public IEnumerable<Patient> GetPatientById(int id)
        {
            if(patients.Count==0)
            {
                throw new PatientnotFoundException();

            }
            return patients;
        }

        public IEnumerable<Patient> GetPatientDetails()
        {
            if (patients.Count == 0)
            {
                throw new PatientnotFoundException();
            }
            return patients;

        }

            public Patient Login(int Id, string Password)
        {
            for(int i=0;i<patients.Count;i++)
            {
                if(patients[i].Id == Id && patients[i].Password==Password)
                {
                    return patients[i];
                }
            }
            return null;
        }

        public Patient PatientRegiter()
        {
            Patient patient=new Patient();
            patient.Id = GenerateId();
            patient.AddPatient();
            patient.Password = patient.Name + patient.Id;
            patients.Add(patient);
            string value = $"Registration Successful!! \nYour username is your Id({patient.Id})\nYour password is Your name followed by your Id which is  {patient.Id}";
            Console.WriteLine(value);
            return patient;

        }

        
        private int GenerateId()
        {
            if (patients.Count == 0)
            {
                return 1;
            }
            int maxid = 0;
            foreach (var patient in patients)
            {
                if(patient.Id>maxid)
                {
                    maxid=patient.Id;
                }
            }
            return maxid + 1;
        }
    }
}
