using Patient_Management.Interfaces;
using Patient_Management.Models;
using Patient_Management.Services;
using System.Numerics;
using System.Threading.Channels;

namespace Patient_Management
{
    public class Program 
    {
        Ipatient patient;
        PatientService patientService;

        public Program()
        {
            patientService = new PatientService();
        }

        private void AdminLogin()
        {
            Console.WriteLine("Enter Admin ID:");
            string adminId=Console.ReadLine();
            
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine() ?? "";

            Patient result = patientService.AdminLogin(adminId, password);
            if (result != null)
            {
                Console.WriteLine("Admin Login Successful");
                
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }
        }

        private void Login(Ipatient patient)
        {
            Console.WriteLine("Enter patientID");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id))
            {
                Console.WriteLine("Please enter a valid doctor Id");

            }
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine() ?? "";
            Patient result = patient.Login(Id, password);
            if (result != null)
            {
                Console.WriteLine("Login Successful");
                Console.WriteLine("Welcome Patient. Here are your details");
                Console.WriteLine(result);
            }

        }

        private bool ChangeNumber()
        {
            Console.WriteLine("Enter patientID");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id))
            {
                Console.WriteLine("Please enter a valid patient ID");
            }

            string newPhoneNumber;
            do
            {
                Console.WriteLine("Enter new Phone Number (10 digits):");
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
            bool result = patientService.ChangePatientPhoneNumber(Id, newPhoneNumber);

            if (result)
            {
                Console.WriteLine("Phone number changed successfully");
            }
            return result;
        }


        private void ViewAllPatients()
        {
            var patients = patientService.GetPatientDetails();
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
                Console.WriteLine("---------------------");
            }
        }

        private void ViewAllPatientsBYID()
        {
            Console.WriteLine("Enter patientID");
            int Id;
            while (!int.TryParse(Console.ReadLine(), out Id))
            {
                Console.WriteLine("Please enter a valid Patient Id");

            }
            var patients = patientService.GetPatientById(Id);
            foreach (var patient in patients)
            {
                Console.WriteLine(patient);
                Console.WriteLine("---------------------");
            }
        }

        void PrintUserMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Patient Login");
            Console.WriteLine("3. Admin Login");
            Console.WriteLine("4. Exit");
        }

        void PrintPatientMenu()
        {
            
            
            Console.WriteLine("1. View Patient ");
            Console.WriteLine("2. Exit");
        }

        void PrintAdminMenu()
        {
            
            Console.WriteLine("1. View All Patients");
            Console.WriteLine("2. View Patient by ID");
            Console.WriteLine("3. Change number");
            Console.WriteLine("4. Exit");
        }

        void UserInteraction()
        {
            int role;
            do
            {
                PrintUserMenu();
                Console.WriteLine("Enter your choice:");
                while (!int.TryParse(Console.ReadLine(), out role))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (role)
                {
                    case 1:
                        patientService.PatientRegiter();
                        break;
                    case 2:
                        PatientInteraction();
                        break;
                    case 3:
                        AdminInteraction();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Application");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (role != 4);
        }

        void PatientInteraction()
        {
            patient = patientService;

            
            Console.WriteLine("Patient Login");
            Login(patient);

            int choice;
            do
            {
                PrintPatientMenu();
                Console.WriteLine("Enter your choice:");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (choice)
                {
    
                    case 1:
                        ViewAllPatientsBYID();
                        break;
                    case 2:
                        Console.WriteLine("Exiting from Patient Interaction");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 2);
        }

        void AdminInteraction()
        {
            Console.WriteLine("Admin Login");
            AdminLogin();

            int choice;
            do
            {
                PrintAdminMenu();
                Console.WriteLine("Enter your choice:");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (choice)
                {
                   
                    case 1:
                        ViewAllPatients();
                        break;
                    case 2:
                        ViewAllPatientsBYID();
                        break;

                    case 3:
                        ChangeNumber();
                        break;
                    case 4:
                        Console.WriteLine("Exiting from Admin Interaction");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 3);
        }
        static void Main(string[] args)
        {

            Console.WriteLine("------------------------------------------Welcome to Patient Management System------------------------------------------");

            Program program = new Program();
            program.UserInteraction();

        }
        }
    }

