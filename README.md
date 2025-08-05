# 🛒 E-Commerce Web API Demo

This is a demo **RESTful API** for a simple e-commerce application built using **ASP.NET Core**, **Entity Framework Core**, **FluentValidation**, and **CQRS with MediatR**.

## 📌 Features

- Manage **Customers**, **Orders**, and **Products**
- Create and retrieve customers
- Place orders and update their status
- Retrieve order details including associated products
- Seeded initial product data
- Proper HTTP status code handling
- FluentValidation for input validation
- Clean architecture using CQRS

---

## 🧱 Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (Code-First)
- FluentValidation
- MediatR (CQRS Pattern)
- SQL Server
- Swagger / OpenAPI

---

## 🗃️ Database Setup

1. Make sure you have a local SQL Server instance running.
2. Update your connection string in `appsettings.json`.

  "DefaultConnection": "Server=.;Database=ECommerceDemoDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
