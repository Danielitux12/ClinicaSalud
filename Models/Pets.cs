namespace ClimicaSalud.Models
{
    /// <summary>
    /// Represents a pet record within the clinic system.
    /// This class is a plain data model (POCO) — it holds pet
    /// information only and contains no business logic.
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Unique identifier assigned to the pet.
        /// Generated automatically as a GUID to guarantee uniqueness.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Full name of the pet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age of the pet, in years.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Breed of the pet (e.g., Labrador, Siamese).
        /// </summary>
        public string Breed { get; set; }
    }
}