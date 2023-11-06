# Car REST API

## Overview

This Car REST API is a simple, yet powerful system designed to manage a car inventory. It allows for operations such as retrieving all cars in the inventory and adding new cars. Built with ASP.NET Core and MongoDB, it provides a robust backend service.

## Features

- **Retrieve All Cars**: Get a list of all cars in the inventory.
- **Add a New Car**: Post a new car entry to the inventory.

## Installation

### Prerequisites

- .NET 6.0 SDK or later
- MongoDB Server

### Setup

1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```

2. Change directory into the project folder:
    ```bash
    cd <project-folder-name>
    ```

3. Restore dependencies:
    ```bash
    dotnet restore
    ```

4. Start the application:
    ```bash
    dotnet run
    ```

### Configuration

Modify the `appsettings.json` to set up your MongoDB connection:

```json

"MongoDB": {
  "ConnectionString": "<your-connection-string>",
  "DatabaseName": "<your-database-name>"
}
```

##API Endpoints

### Retrieve All Cars

Returns a list of all cars in the inventory.

**URL** : `/api/cars`

**Method** : `GET`

**Auth required** : NO

**Permissions required** : None

#### Success Response

**Code** : `200 OK`

**Content examples**

For a request to `/api/cars` with no cars in the inventory:

```json
[]
```



    



