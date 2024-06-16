# Customer Management Application

This is a simple Customer Management application built using ASP.NET Core 6. The application demonstrates basic CRUD (Create, Read, Update, Delete) operations for managing customer data, including validation and error handling.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Validation](#validation)

## Features

- Add new customers
- Edit existing customers
- Delete customers
- View a list of all customers
- Server-side validation for required fields and valid email format
- Error handling for API requests

## Technologies Used

- ASP.NET Core 6
- Razor Pages
- Bootstrap (for basic styling)
- HttpClient (for API communication)
- Swashbuckle (for API documentation, if enabled)

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/KatruM-Personal/CustomerTest.git
    cd CustomerTest
    ```

2. Restore the dependencies:

    ```sh
    dotnet restore
    ```

### Running the Application

1. Run the API project:

    ```sh
    cd CustomerAPI
    dotnet run
    ```

2. Run the UI project in a separate terminal:

    ```sh
    cd CustomerUI
    dotnet run
    ```

3. Open your browser and navigate to:

    ```
    https://localhost:7087
    ```

## API Endpoints

- `GET /api/Customers`: Retrieve a list of all customers
- `GET /api/Customers/{id}`: Retrieve a specific customer by ID
- `POST /api/Customers`: Create a new customer
- `PUT /api/Customers/{id}`: Update an existing customer
- `DELETE /api/Customers/{id}`: Delete a customer

## Validation

The following validations are implemented:

- `Name`: Required field
- `Email`: Required field, must be a valid email format
- `Phone`: Required field, must be exactly 10 digits

Validation is enforced both on the client-side and server-side using data annotations in the `Customer` model.
