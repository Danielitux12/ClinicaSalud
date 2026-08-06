namespace ClimicaSalud.Models
{
    /// <summary>
    /// Represents a patient record within the clinic system.
    /// This class is a plain data model (POCO) — it holds patient
    /// information only and contains no business logic.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Unique identifier assigned to the patient.
        /// Generated automatically as a GUID to guarantee uniqueness
        /// without relying on a manual counter.
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
    }
}