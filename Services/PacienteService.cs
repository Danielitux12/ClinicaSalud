using ClimicaSalud.Models;

namespace ClimicaSalud.Services
{
    /// <summary>
    /// Handles the business logic related to patient (and their pets)
    /// management, including registration, listing, searching,
    /// updating, deleting, and filtering.
    /// </summary>
    public class PatientService
    {
        /// <summary>
        /// Prompts the user for patient data via console input,
        /// validates the numeric fields, and adds a new patient
        /// to the provided list.
        /// </summary>
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
                    // Pets list starts empty automatically.
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

        /// <summary>
        /// Iterates through the patient list and prints each patient's
        /// details, including their registered pets, to the console.
        /// </summary>
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

                if (p.Pets.Count == 0)
                {
                    Console.WriteLine("    No pets registered for this patient.");
                }
                else
                {
                    foreach (Pet pet in p.Pets)
                    {
                        Console.WriteLine($"    - Pet: {pet.Name} | Age: {pet.Age} | Breed: {pet.Breed}");
                    }
                }
            }
        }

        /// <summary>
        /// Searches for a patient by name (case-insensitive) and
        /// prints their details, including their pets, to the console.
        /// </summary>
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

                    if (found.Pets.Count == 0)
                    {
                        Console.WriteLine("    No pets registered for this patient.");
                    }
                    else
                    {
                        foreach (Pet pet in found.Pets)
                        {
                            Console.WriteLine($"    - Pet: {pet.Name} | Age: {pet.Age} | Breed: {pet.Breed}");
                        }
                    }
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

        /// <summary>
        /// Registers a new pet and associates it with an existing
        /// patient, found by name.
        /// </summary>
        public void RegisterPetForPatient(List<Patient> list)
        {
            Console.Write("Enter the owner's (patient) name: ");
            string ownerName = Console.ReadLine();

            Patient owner = list.FirstOrDefault(p =>
                p.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));

            if (owner == null)
            {
                Console.WriteLine("Error: no patient found with that name. Register the patient first.");
                return;
            }

            Console.WriteLine("\n--- Register new pet ---");

            try
            {
                Guid petId = Guid.NewGuid();

                Console.Write("Pet name: ");
                string petName = Console.ReadLine();

                Console.Write("Pet age: ");
                int petAge = int.Parse(Console.ReadLine());

                Console.Write("Breed: ");
                string breed = Console.ReadLine();

                Pet newPet = new Pet
                {
                    Id = petId,
                    Name = petName,
                    Age = petAge,
                    Breed = breed
                };

                owner.Pets.Add(newPet);

                Console.WriteLine($"Pet registered successfully under patient '{owner.Name}'.");
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

        /// <summary>
        /// Updates an existing patient's editable fields (Age and Symptom).
        /// </summary>
        public void UpdatePatient(List<Patient> list, string name)
        {
            Patient found = list.FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (found == null)
            {
                Console.WriteLine("No patient found with that name.");
                return;
            }

            Console.WriteLine($"Editing patient: {found.Name}");

            try
            {
                Console.Write($"New age (current: {found.Age}): ");
                int newAge = int.Parse(Console.ReadLine());
                found.Age = newAge;

                Console.Write($"New symptom (current: {found.Symptom}): ");
                string newSymptom = Console.ReadLine();
                found.Symptom = newSymptom;

                Console.WriteLine("Patient updated successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Age must be a valid whole number. Update cancelled.");
            }
        }

        /// <summary>
        /// Removes a patient from the list by name.
        /// </summary>
        public void DeletePatient(List<Patient> list, string name)
        {
            Patient found = list.FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (found == null)
            {
                Console.WriteLine("No patient found with that name.");
                return;
            }

            list.Remove(found);
            Console.WriteLine($"Patient '{found.Name}' was removed successfully.");
        }

        /// <summary>
        /// Removes a specific pet from a patient's pet list, by pet name.
        /// </summary>
        public void DeletePetFromPatient(List<Patient> list, string ownerName, string petName)
        {
            Patient owner = list.FirstOrDefault(p =>
                p.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));

            if (owner == null)
            {
                Console.WriteLine("No patient found with that name.");
                return;
            }

            Pet pet = owner.Pets.FirstOrDefault(p =>
                p.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));

            if (pet == null)
            {
                Console.WriteLine("No pet found with that name for this patient.");
                return;
            }

            owner.Pets.Remove(pet);
            Console.WriteLine($"Pet '{pet.Name}' removed from patient '{owner.Name}'.");
        }

        /// <summary>
        /// Filters and displays patients within a given age range.
        /// </summary>
        public void FilterPatientsByAge(List<Patient> list, int minAge, int maxAge)
        {
            Console.WriteLine($"\n--- Patients between {minAge} and {maxAge} years old ---");

            List<Patient> filtered = list
                .Where(p => p.Age >= minAge && p.Age <= maxAge)
                .ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("No patients found in that age range.");
                return;
            }

            foreach (Patient p in filtered)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Age: {p.Age} | Symptom: {p.Symptom}");
            }
        }

        /// <summary>
        /// Filters and displays patients who own at least one pet
        /// matching the given breed (case-insensitive).
        /// </summary>
        public void FilterPatientsByPetBreed(List<Patient> list, string breed)
        {
            Console.WriteLine($"\n--- Patients with a pet of breed: {breed} ---");

            List<Patient> filtered = list
                .Where(p => p.Pets.Any(pet => pet.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("No patients found with a pet of that breed.");
                return;
            }

            foreach (Patient p in filtered)
            {
                Console.WriteLine($"Owner: {p.Name}");

                var matchingPets = p.Pets.Where(pet =>
                    pet.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase));

                foreach (Pet pet in matchingPets)
                {
                    Console.WriteLine($"    - Pet: {pet.Name} | Age: {pet.Age} | Breed: {pet.Breed}");
                }
            }
        }
    }
}