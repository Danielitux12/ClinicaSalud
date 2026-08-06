using ClimicaSalud.Models;

namespace ClimicaSalud.Services
{
    /// <summary>
    /// Handles the business logic related to patient management,
    /// including registration, listing, and searching.
    /// </summary>
    public class PatientService
    {
        public void RegisterPatient(List<Patient> list)
        {
            Console.WriteLine("\n--- Register new patient ---");

            try
            {
                // The Id is generated automatically as a GUID,
                // so the user never types it and it's always unique.
                Guid id = Guid.NewGuid();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Symptom: ");
                string symptom = Console.ReadLine();

                Patient newPatient = new Patient
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Symptom = symptom
                };

                list.Add(newPatient);

                Console.WriteLine($"Patient registered successfully. Assigned Id: {id}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Age must be a valid whole number. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        public void ListPatients(List<Patient> list)
        {
            Console.WriteLine("\n--- Patient list ---");

            if (list.Count == 0)
            {
                Console.WriteLine("No patients registered.");
                return;
            }

            foreach (Patient p in list)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Age: {p.Age} | Symptom: {p.Symptom}");
            }
        }

        public void SearchPatientByName(List<Patient> list, string name)
        {
            Console.WriteLine($"\n--- Searching for patient: {name} ---");

            try
            {
                Patient found = list.FirstOrDefault(p =>
                    p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (found != null)
                {
                    Console.WriteLine($"Found -> ID: {found.Id} | Name: {found.Name} | Age: {found.Age} | Symptom: {found.Symptom}");
                }
                else
                {
                    Console.WriteLine("No patient found with that name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the patient: {ex.Message}");
            }
        }
    }
}