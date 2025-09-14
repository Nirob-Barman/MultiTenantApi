# MultiTenantApi

**MultiTenantApi** is a lightweight, multi-tenant RESTful API built with ASP.NET Core, designed to handle multiple clients (tenants) based on their request host/domain. Each tenant is mapped to its own SQL Server database, allowing for clean data separation and scalability.

## Features

🔁 Multi-Tenant Architecture using host-based tenant identification (client1.contacts.com, etc.)

💾 Dynamic Connection Strings per tenant

📄 CRUD API for Contacts

⚙️ Configurable via appsettings.json and environment variables

🔐 Supports HTTPS and environment-safe secrets handling

📖 Integrated Swagger UI for API testing


## Project Structure
```
MultiTenantApi/
│
├── Controllers/
│   └── ContactsController.cs       // API controller for contact management
│
├── Data/
│   └── ContactContext.cs          // EF Core DbContext with multi-tenant setup
│
├── Models/
│   └── Contact.cs                 // Data model for Contact
│
├── Services/
│   └── ITenantService.cs         // Interface for tenant resolution
│   └── HostTenantService.cs      // Host-based tenant resolver
│
├── appsettings.json              // Tenant mappings and connection strings
├── Program.cs                    // App startup and configuration
└── README.md                     // Project documentation
```

## Prerequisites

* .NET 6 SDK or later
* SQL Server (LocalDB or SQL Server Express recommended)
* Visual Studio 2022 or Visual Studio Code

## Getting Started

1. **Clone the Repository**

```bash
git clone https://github.com/nirob-barman/MultiTenantApi.git
cd MultiTenantApi
```

2. **Configure appsettings.json**

   Update the  `appsettings.json` file with your SQL Server configuration:

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "Server=ServerName;Database=Contacts_Default;User Id=UserName;Password=Password;TrustServerCertificate=True;",
        "Client1Connection": "Server=ServerName;Database=Contacts_Client1;User Id=UserName;Password=Password;TrustServerCertificate=True;"
    },
    "AllowedHosts": "*"
}
```

3. **Apply Migrations & Create Databases**

    Use Entity Framework Core to create your tenant databases:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

4. **Run the Application**

```bash
dotnet run
```

5. **Access the Application**
   Visit `http://localhost:<port>` in your browser. Swagger UI is available at `http://localhost:<port>/swagger`


## Sample Host Header Testing (Local Dev)

To simulate tenant domains locally, you can update your hosts file

    (C:\Windows\System32\drivers\etc\hosts):

Add entries like:

    127.0.0.1 client1.contacts.com
    127.0.0.1 client2.contacts.com


## Security Note

* Never store real credentials in appsettings.json for production.
* Always use TrustServerCertificate=True only in development unless using a trusted SSL certificate

## Contributions

* Feel free to fork the project, open issues, or submit PRs to improve the multi-tenant architecture or add features like:
* Role-based authentication
* Tenant registration and provisioning
* Admin UI per tenant

## License

This project is open for educational and non-commercial use.

## Contact

For any queries, reach out to the project owner at [nirob.barman@gmail.com](mailto:nirob.barman@gmail.com).


## ✍️ Author

- 👤 **Nirob Barman**  
- [![Medium](https://img.shields.io/badge/Medium-Blog-black?logo=medium)](https://nirob-barman.medium.com/)
- [![LinkedIn](https://img.shields.io/badge/LinkedIn-Connect-blue?logo=linkedin)](https://www.linkedin.com/in/nirob-barman/)
- [![Portfolio](https://img.shields.io/badge/Portfolio-Visit-brightgreen?logo=firefox-browser)](https://nirob-barman-19.web.app/)
- [![Email](https://img.shields.io/badge/Email-Contact-orange?logo=gmail)](mailto:nirob.barman.19@gmail.com)

---