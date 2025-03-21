using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management.Models
{
    public class Patient
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password {  get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public Patient()
        {

        }
        public Patient(int id,string name,string password ,string phoneNumber,int age)
        {
            Id = id;
            Name = name;
            Password = password;    
            PhoneNumber = phoneNumber;
            Age = age;

        }

        public  void AddPatient()
        {
            Console.WriteLine("Enter  Name");
            Name = Console.ReadLine();

            string newPhoneNumber;
            do
            {
                Console.WriteLine("Enter  Phone Number (10 digits):");
                newPhoneNumber = Console.ReadLine() ?? "";

                if (newPhoneNumber.Length != 10 || !newPhoneNumber.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid phone number. Please enter exactly 10 digits.");
                }
                else
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Enter Age");
            int age;
            while(int.TryParse(Console.ReadLine(),out age)==false || age<=0)
            {
                Console.WriteLine("Please enter the valid age .Try again");
            }

            Age = age;

        }

        public override string ToString()
        {
            return $"ID : {Id}" +
                $"\nName : {Name}" +
                $"\nPhoneNumber : {PhoneNumber}" +
                $"\nAge : {Age}";
        }


    }
}
