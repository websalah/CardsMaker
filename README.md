# CardsMaker

A web application for creating and managing personal contact cards, built with ASP.NET Core MVC (.NET 8).

## Features

- **Create Cards** — Add personal cards with name, email, phone, website, job title, address, city, and a custom logo
- **View Cards** — Browse all cards in a clean grid layout
- **Card Details** — View detailed information for each card
- **Download as Image** — Export any card as a PNG image
- **Validation** — Server-side validation including a custom `[Website]` attribute for URL validation

## Project Structure

```
PracticingProject/          → Main ASP.NET Core MVC web app
├── Controllers/            → MVC controllers
├── Views/                  → Razor views
├── wwwroot/                → Static files (CSS, JS, images)
Entities/                   → Domain models
ServiceContracts/           → Interfaces and DTOs
├── CustomValidations/      → Custom validation attributes
├── DTO/                    → Request/Response models
Services/                   → Service implementations
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run

```bash
cd PracticingProject
dotnet run
```

## Tech Stack

- **ASP.NET Core MVC** (.NET 8)
- **html2canvas** — Client-side card-to-image export
- **Font Awesome** — Icons
- **Google Fonts (Inter)** — Typography
