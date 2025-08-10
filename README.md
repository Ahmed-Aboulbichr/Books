# Books API

A RESTful API for managing books, built with ASP.NET Core and SQL Server, containerized using Docker.

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 9.0
- **Database**: SQL Server 2022
- **Containerization**: Docker & Docker Compose
- **ORM**: Entity Framework Core

## 🚀 Getting Started

### Prerequisites

Ensure you have the following installed:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Clone the Repository

```bash
git clone https://github.com/Ahmed-Aboulbichr/Books.git
cd Books
```

## Build and Start Containers
```bash
docker-compose up --build
```

This command builds and starts both the API and SQL Server containers.

### Access the Application
API: http://localhost:8080

Swagger UI: http://localhost:8080/swagger

### Stop and Remove Containers
```bash
docker-compose down
```
### 🔧 Configuration
Connection String

The API connects to the SQL Server instance using the following connection string:

```bash
"ConnectionStrings": {
  "BooksDb": "Server=booksdb,1433;Database=BooksDb;User Id=sa;Password=password123!;TrustServerCertificate=true"
}
```

### Environment Variables
ACCEPT_EULA: Set to "Y" to accept the SQL Server EULA.

SA_PASSWORD: Set to "password123!" for the SQL Server system administrator password.

### Docker Compose Configuration
The docker-compose.yml file defines two services:

books.api: The ASP.NET Core API.

booksdb: The SQL Server database.

```bash
services:
  books.api:
    image: booksapi
    build:
      context: .
      dockerfile: src/API/Books.API/Dockerfile
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_HTTP_PORTS=8080
      - ASPNETCORE_HTTPS_PORTS=8081
    ports:
      - "8080:8080"
      - "8081:8081"
    depends_on:
      - booksdb
    networks:
      - booksnetwork

  booksdb:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: booksdb
    environment:
      ACCEPT_EULA: "Y"
      SA_PASSWORD: "password123!"
    ports:
      - "1433:1433"
    networks:
      - booksnetwork

networks:
  booksnetwork:
    driver: bridge

```

🧪 Running Tests
To run tests within the container:

```bash
docker-compose exec books.api dotnet test
```


## Swagger Screen Shot

<img width="1686" height="647" alt="image" src="https://github.com/user-attachments/assets/9d76f6ca-8e8e-44c8-be2a-821cd3640ecf" />


