using ClimicaSalud.Models;

namespace ClimicaSalud.Services
{
    public class PetService
    {
        public void RegisterPet(List<Pet> list)
        {
            Console.WriteLine("\n--- Register new pet ---");

            try
            {
                Guid id = Guid.NewGuid();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Breed: ");
                string breed = Console.ReadLine();

                Pet newPet = new Pet
                {
                    Id = id,
                    Name = name,
                    Age = age,
                    Breed = breed
                };

                list.Add(newPet);

                Console.WriteLine($"Pet registered successfully. Assigned Id: {id}");
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

        public void ListPets(List<Pet> list)
        {
            Console.WriteLine("\n--- Pet list ---");

            if (list.Count == 0)
            {
                Console.WriteLine("No pets registered.");
                return;
            }

            foreach (Pet p in list)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Age: {p.Age} | Breed: {p.Breed}");
            }
        }

        public void SearchPetByName(List<Pet> list, string name)
        {
            Console.WriteLine($"\n--- Searching for pet: {name} ---");

            try
            {
                Pet found = list.FirstOrDefault(p =>
                    p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (found != null)
                {
                    Console.WriteLine($"Found -> ID: {found.Id} | Name: {found.Name} | Age: {found.Age} | Breed: {found.Breed}");
                }
                else
                {
                    Console.WriteLine("No pet found with that name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for the pet: {ex.Message}");
            }
        }
    }
}