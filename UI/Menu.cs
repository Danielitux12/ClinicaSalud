using ClimicaSalud.Models;
using ClimicaSalud.Services;

namespace ClimicaSalud.UI
{
    /// <summary>
    /// Represents the console-based main menu of the application.
    /// Responsible for displaying options, capturing user input,
    /// and delegating business logic to the PatientService class.
    /// </summary>
    public class Menu
    {
        private PatientService patientService = new PatientService();

        /// <summary>
        /// Runs the main menu loop until the user chooses to exit.
        /// </summary>
        /// <param name="patients">The shared list of patients for this session.</param>
        public void Run(List<Patient> patients)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("===== MAIN MENU =====");
                Console.WriteLine("1. Register patient");
                Console.WriteLine("2. List patients (with pets)");
                Console.WriteLine("3. Search patient");
                Console.WriteLine("4. Register pet for a patient");
                Console.WriteLine("5. Update patient");
                Console.WriteLine("6. Delete patient");
                Console.WriteLine("7. Delete pet from patient");
                Console.WriteLine("8. Filter patients by age");
                Console.WriteLine("9. Filter patients by pet breed");
                Console.WriteLine("10. Exit");
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
                        string searchName = Console.ReadLine();
                        patientService.SearchPatientByName(patients, searchName);
                        break;

                    case "4":
                        patientService.RegisterPetForPatient(patients);
                        break;

                    case "5":
                        Console.Write("Enter the name of the patient to update: ");
                        string updateName = Console.ReadLine();
                        patientService.UpdatePatient(patients, updateName);
                        break;

                    case "6":
                        Console.Write("Enter the name of the patient to delete: ");
                        string deleteName = Console.ReadLine();
                        patientService.DeletePatient(patients, deleteName);
                        break;

                    case "7":
                        Console.Write("Enter the owner's name: ");
                        string ownerName = Console.ReadLine();
                        Console.Write("Enter the pet's name to delete: ");
                        string petName = Console.ReadLine();
                        patientService.DeletePetFromPatient(patients, ownerName, petName);
                        break;

                    case "8":
                        try
                        {
                            Console.Write("Enter minimum age: ");
                            int minAge = int.Parse(Console.ReadLine());
                            Console.Write("Enter maximum age: ");
                            int maxAge = int.Parse(Console.ReadLine());
                            patientService.FilterPatientsByAge(patients, minAge, maxAge);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: age values must be valid whole numbers.");
                        }
                        break;

                    case "9":
                        Console.Write("Enter breed to filter by: ");
                        string breed = Console.ReadLine();
                        patientService.FilterPatientsByPetBreed(patients, breed);
                        break;

                    case "10":
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