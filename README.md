# Vehículos App

[![es](https://img.shields.io/badge/lang-es-yellow.svg)](README.md)
[![en](https://img.shields.io/badge/lang-en-red.svg)](README.en.md)

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![.NET MAUI](https://img.shields.io/badge/.NET_MAUI-10.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?logo=c-sharp)

Aplicación integral para la gestión de vehículos y su mantenimiento. El proyecto consta de un backend desarrollado con ASP.NET Core (Web API) y un cliente multiplataforma desarrollado con .NET MAUI utilizando el patrón MVVM.

## 🚀 Características Principales

*   **Gestión de Vehículos**: Operaciones CRUD completas (Crear, Leer, Actualizar, Eliminar) para el inventario de vehículos.
*   **Mantenimientos e Incidencias**: Registro del historial de mantenimientos, reporte de fallas y servicios realizados a cada vehículo.
*   **Catálogos de Sistema**: Administración de catálogos para una clasificación estandarizada.
*   **UI/UX Moderna**: Diseño atractivo e intuitivo en la aplicación cliente, ofreciendo una experiencia de usuario fluida y profesional.
*   **Patrón MVVM**: Separación clara de responsabilidades en la aplicación MAUI mediante Model-View-ViewModel.

## 🛠️ Tecnologías Utilizadas

### Backend (`VehiculosAPI`)
*   **.NET 10.0**
*   **ASP.NET Core Web API**
*   **Entity Framework Core** para el acceso a datos.
*   **SQL Server** como base de datos relacional.
*   **OpenAPI/Swagger** para documentación y prueba de la API.

### Frontend (`VehiculosMaui`)
*   **.NET MAUI** (.NET Multi-platform App UI) apuntando a .NET 10.0.
*   **XAML** para el diseño de interfaces de usuario.
*   Soporte multiplataforma: Windows, Android, iOS y MacCatalyst.

## 📁 Estructura del Proyecto

La solución contiene dos proyectos principales:

1.  **`VehiculosAPI`**: Proyecto backend que expone los endpoints RESTful para la lógica de negocio y persistencia de datos.
2.  **`VehiculosMaui`**: Proyecto cliente MAUI con las vistas (Views), modelos de vista (ViewModels) y la lógica de presentación para consumir la API.

## ⚙️ Configuración y Ejecución

### Requisitos Previos
*   [Visual Studio 2022](https://visualstudio.microsoft.com/) (versión compatible con .NET 10 y cargas de trabajo de MAUI y ASP.NET).
*   [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
*   SQL Server LocalDB o una instancia de SQL Server configurada.

### Pasos para ejecutar localmente

1.  **Clonar el repositorio**:
    ```bash
    git clone https://github.com/ChriZStormy/Vehiculos-App.git
    cd VehiculosApp
    ```

2.  **Configurar la Base de Datos (`VehiculosAPI`)**:
    *   Verifica la cadena de conexión en el archivo `appsettings.json` del proyecto `VehiculosAPI`.
    *   Abre la Consola del Administrador de Paquetes en Visual Studio, selecciona el proyecto `VehiculosAPI` y ejecuta:
        ```powershell
        Update-Database
        ```
    *   Alternativamente, puedes usar la CLI de .NET en el directorio de la API:
        ```bash
        dotnet ef database update
        ```

3.  **Configurar la URL de la API (`VehiculosMaui`)**:
    *   Asegúrate de que los servicios en la app MAUI (ej. `VehiculoService.cs`) apunten a la URL local o remota correcta donde se esté ejecutando `VehiculosAPI` (por defecto suele ser `https://localhost:port`).

4.  **Ejecutar la Solución**:
    *   Abre `VehiculosApp.sln` en Visual Studio.
    *   Para ejecutar ambos proyectos simultáneamente, puedes configurar Visual Studio para "Proyectos de inicio múltiples" e iniciar ambos (`VehiculosAPI` y `VehiculosMaui`).

## 📝 Licencia
Este proyecto se distribuye bajo los términos especificados en el repositorio.
