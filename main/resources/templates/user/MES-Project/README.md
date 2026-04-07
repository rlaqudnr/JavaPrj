# MES Project

## Overview
The MES (Manufacturing Execution System) Project is designed to streamline and manage manufacturing processes through an efficient software solution. This project encompasses various components, including core models, data access layers, and an API for interaction.

## Project Structure
The project is organized into several key directories:

- **src/MES.Core**: Contains core models, interfaces, and services.
  - **Models**: Base model classes.
  - **Interfaces**: Repository interfaces for data access.
  - **Services**: Common service logic.

- **src/MES.Data**: Manages data entities and repositories.
  - **Entities**: Defines data structures.
  - **Context**: Database context for entity management.
  - **Repositories**: Implements data access methods.

- **src/MES.API**: The API layer for handling HTTP requests.
  - **Controllers**: Manages API endpoints.
  - **Program.cs**: Entry point for the application.
  - **Startup.cs**: Configures services and middleware.

- **src/MES.Tests**: Contains unit and integration tests to ensure code quality and functionality.

## Setup Instructions
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd MES-Project
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run --project src/MES.API/MES.API.csproj
   ```

## Usage
Once the application is running, you can interact with the API endpoints defined in the `ProductController`. Use tools like Postman or curl to send HTTP requests to the API.

## Testing
To run the tests, navigate to the test project directory and execute:
```
dotnet test
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.