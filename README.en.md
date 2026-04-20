# Vehículos App

[![es](https://img.shields.io/badge/lang-es-yellow.svg)](README.md)
[![en](https://img.shields.io/badge/lang-en-red.svg)](README.en.md)

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![.NET MAUI](https://img.shields.io/badge/.NET_MAUI-10.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp)

Comprehensive application for vehicle management and maintenance. The project consists of a backend developed with ASP.NET Core (Web API) and a cross-platform client developed with .NET MAUI using the MVVM pattern.

## 🚀 Key Features

*   **Vehicle Management**: Complete CRUD operations (Create, Read, Update, Delete) for the vehicle inventory.
*   **Maintenance & Incidents**: Logging of maintenance history, reporting faults, and services performed on each vehicle.
*   **System Catalogs**: Administration of catalogs for standardized classification.
*   **Modern UI/UX**: Attractive and intuitive design in the client application, offering a smooth and professional user experience.
*   **MVVM Pattern**: Clear separation of concerns in the MAUI application using Model-View-ViewModel.

## 🛠️ Technologies Used

### Backend (`VehiculosAPI`)
*   **.NET 10.0**
*   **ASP.NET Core Web API**
*   **Entity Framework Core** for data access.
*   **SQL Server** as the relational database.
*   **OpenAPI/Swagger** for API documentation and testing.

### Frontend (`VehiculosMaui`)
*   **.NET MAUI** (.NET Multi-platform App UI) targeting .NET 10.0.
*   **XAML** for designing user interfaces.
*   Cross-platform support: Windows, Android, iOS, and MacCatalyst.

## 📁 Project Structure

The solution contains two main projects:

1.  **`VehiculosAPI`**: Backend project that exposes RESTful endpoints for business logic and data persistence.
2.  **`VehiculosMaui`**: MAUI client project with Views, ViewModels, and presentation logic to consume the API.

## ⚙️ Setup and Execution

### Prerequisites
*   [Visual Studio 2022](https://visualstudio.microsoft.com/) (version compatible with .NET 10, MAUI, and ASP.NET workloads).
*   [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
*   SQL Server LocalDB or a configured SQL Server instance.

### Steps to run locally

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/ChriZStormy/Vehiculos-App.git
    cd VehiculosApp
    ```

2.  **Configure the Database (`VehiculosAPI`)**:
    *   Verify the connection string in the `appsettings.json` file of the `VehiculosAPI` project.
    *   Open the Package Manager Console in Visual Studio, select the `VehiculosAPI` project, and run:
        ```powershell
        Update-Database
        ```
    *   Alternatively, you can use the .NET CLI in the API directory:
        ```bash
        dotnet ef database update
        ```

3.  **Configure the API URL (`VehiculosMaui`)**:
    *   Ensure that the services in the MAUI app (e.g., `VehiculoService.cs`) point to the correct local or remote URL where `VehiculosAPI` is running (default is usually `https://localhost:port`).

4.  **Run the Solution**:
    *   Open `VehiculosApp.sln` in Visual Studio.
    *   To run both projects simultaneously, you can configure Visual Studio for "Multiple startup projects" and start both (`VehiculosAPI` and `VehiculosMaui`).

## 📝 License
This project is distributed under the terms specified in the repository.
