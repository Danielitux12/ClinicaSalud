using ClimicaSalud.Models;
using ClimicaSalud.Services;

namespace ClimicaSalud.UI
{
    public class Menu
    {
        private PatientService patientService = new PatientService();
        private PetService petService = new PetService();

        public void Run(List<Patient> patients, List<Pet> pets)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("===== MAIN MENU =====");
                Console.WriteLine("1. Register patient");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. Search patient");
                Console.WriteLine("4. Register pet");
                Console.WriteLine("5. List pets");
                Console.WriteLine("6. Search pet");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        patientService.RegisterPatient(patients);
                        break;

                    case "2":
                        patientService.ListPatients(patients);
                        break;

                    case "3":
                        Console.Write("Enter the name to search: ");
                        string patientName = Console.ReadLine();
                        patientService.SearchPatientByName(patients, patientName);
                        break;

                    case "4":
                        petService.RegisterPet(pets);
                        break;

                    case "5":
                        petService.ListPets(pets);
                        break;

                    case "6":
                        Console.Write("Enter the pet name to search: ");
                        string petName = Console.ReadLine();
                        petService.SearchPetByName(pets, petName);
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting the system...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}