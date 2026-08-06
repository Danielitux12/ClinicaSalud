using ClimicaSalud.Models;
using ClimicaSalud.UI;

// Both lists are owned by the entry point and shared across
// the entire session via the Menu.
List<Patient> patients = new List<Patient>();
List<Pet> pets = new List<Pet>();

var menu = new Menu();
menu.Run(patients, pets);