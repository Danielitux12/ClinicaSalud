namespace ClimicaSalud.Models
{
    /// <summary>
    /// Represents a patient record within the clinic system.
    /// This class is a plain data model (POCO) — it holds patient
    /// information, including their associated pets, and contains
    /// no business logic.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Unique identifier assigned to the patient.
        /// Generated automatically as a GUID to guarantee uniqueness.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Full name of the patient.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Age of the patient, in years.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Primary symptom reported by the patient.
        /// </summary>
        public string Symptom { get; set; }

        /// <summary>
        /// List of pets belonging to this patient.
        /// Initialized as an empty list so it's never null,
        /// even before any pet is registered.
        /// </summary>
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}