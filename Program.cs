using ClimicaSalud.Models;
using ClimicaSalud.UI;

// Entry point of the application.
// One single list — pets now live inside their owning patient,
// so there's no need for a separate pets collection.
List<Patient> patients = new List<Patient>();

var menu = new Menu();
menu.Run(patients);