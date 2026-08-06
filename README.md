# ClinicaSalud

Console application built with .NET for managing patients and pets in a clinic system. The project follows a simple layered architecture, separating presentation (UI), business logic (Services), and data models (Models).

## Features

- **Patient management**
  - Register a new patient (Id auto-generated as a GUID)
  - List all registered patients
  - Search for a patient by name
- **Pet management**
  - Register a new pet (Id auto-generated as a GUID)
  - List all registered pets
  - Search for a pet by name
- Basic error handling with `try-catch` for invalid numeric input (e.g., non-numeric age)

## Tech stack

- C# / .NET
- Console application (no external dependencies)

## Project structure

```
ClinicaSalud/
├── Models/
│   ├── Paciente.cs      # Patient model
│   └── Pets.cs          # Pet model
├── Services/
│   ├── PacienteService.cs   # Patient business logic
│   └── PetService.cs        # Pet business logic
├── UI/
│   └── Menu.cs           # Console menu and navigation
├── Program.cs             # Application entry point
└── ClinicaSalud.csproj
```

### Layer responsibilities

| Layer | Responsibility |
|---|---|
| **Models** | Plain data representations (`Patient`, `Pet`) — no logic |
| **Services** | Business logic: registration, listing, searching, validation |
| **UI** | Console menu, user input/output |
| **Program.cs** | Wires everything together and starts the application |

## Getting started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- Verify your installation:
  ```bash
  dotnet --version
  ```

### Running the project

1. Clone the repository:
   ```bash
   git clone https://github.com/Danielitux12/ClinicaSalud.git
   cd ClinicaSalud
   ```
2. Run the application:
   ```bash
   dotnet run
   ```

## Usage

On launch, the application displays the main menu:

```
===== MAIN MENU =====
1. Register patient
2. List patients
3. Search patient
4. Register pet
5. List pets
6. Search pet
7. Exit
Select an option:
```

Enter the number corresponding to the action you want to perform, and follow the on-screen prompts. Patient and pet Ids are generated automatically as GUIDs — you won't be asked to enter one.

## Notes

- Data is stored in memory only; it resets each time the application is restarted.
- Name-based searches are case-insensitive.