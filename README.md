# CrateSample

CrateSample is a sample solution used as part of an interview code test. It combines an ASP.NET Core backend with a React frontend.

The solution demonstrates a clean architecture approach with clear separation of concerns across domain, application, infrastructure, and presentation layers.

---

## Requirements

Before running the solution, ensure the following are installed:

- [Git](https://git-scm.com/) – to clone the repository
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) **or** [JetBrains Rider](https://www.jetbrains.com/rider/) – for the ASP.NET Core backend
- [Visual Studio Code](https://code.visualstudio.com/) – recommended editor for the React frontend
- [Node.js and npm](https://nodejs.org/) – required for building and running the frontend

---

## Architecture

The solution follows a layered architecture with the following projects:

- **`src/CrateSample.Domain`**  
  The **Domain Layer** contains the core business logic and entities. It is independent of other layers and does not depend on external frameworks.

- **`src/CrateSample.Application`**  
  The **Application Layer** defines the use cases of the system. It coordinates the domain logic and acts as the mediator between the domain and infrastructure. Contains application services, DTOs, and interfaces.

- **`src/CrateSample.Infrastructure`**  
  The **Infrastructure Layer** provides implementations for external concerns such as data persistence, external APIs, and other integrations. It references both the domain and application layers.

- **`src/Website`**  
  The **Presentation Layer** is an ASP.NET Core MVC project that serves as the entry point of the application.  
  It also integrates a **React frontend**, which handles client-side interactivity.

---

## Getting Started

### Clone the repository
```bash
git clone https://github.com/cb-mlittle/crate-sample.git
```

### Backend Setup

1. Open the solution in Visual Studio or Rider.
2. Build and run the Website project.

### Frontend Setup

1. Install dependencies:
   ```bash
   npm install
   ```

2. Build:
   ```bash
   npm run build
   ```

3. Reference the script in a .cshtml view:
   ```html
   <script src="/dist/static/js/main.xxxxxxxx.js"></script>
   ```
   - This resultant file will be in the src/Website/wwwroot/dist/static folder.

4. Build and run the Website project.

---

## Contributing

This solution is meant for interview code exercises only. Please do not submit pull requests unless explicitly asked to do so.

---

## License

This project is provided as-is for interview purposes only and does not carry a production license.

---