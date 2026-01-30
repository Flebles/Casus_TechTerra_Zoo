# TechTerra-Zoo

-----

[Team Subway Surfers]
- Tim
- Noah
- Milan
- Lucas

-----

## Technische details

```cs
📦 Casus_TechTerra_Zoo/
├── 📁 Code/
│	├── 📄 TechTerra_Zoo.sln			# Visual Studio Solution
│	├── 📁 TechTerra_Zoo/				# Folder voor de applicatie
│	│	├── 📄 Program.cs				# Service
│	│	├── 📁 Models/					# Hier bevinden zich alle classes
│	│	│	├── 📄 Dier.cs
│	│	│	├── 📄 Verblijf.cs
│	│	│	├── 📄 VoedingScema.cs
│	│   │	└── 📁 Pages/				# Alle paginas in het programma
│	│   │		├── 📄 IPage.cs			# De base class van alle paginas
│	│   │		├── 📄 MainMenu.cs
│	│   │		├── 📄 PageDieren.cs
│	│   │		├── 📄 PageDierRegistreren.cs
│	│   │		├── 📄 PageDierOverzicht.cs
│	│   │		├── 📄 PageDierMenu.cs
│	│   │		├── 📄 PageDierBewerken.cs
│	│   │		├── 📄 PageDierAanVerblijfToevoegen.cs
│	│   │		├── 📄 PageVerblijven.cs
│	│   │		├── 📄 PageVerblijfOverzicht.cs
│	│   │		├── 📄 PageVerblijfToevoegen.cs
│	│   │		├── 📄 PageVerblijfVerwijderen.cs
│	│   │		└── 📄 PageVerzorgers.cs
│	│   ├── 📁 DataAccess/				# Data Access Layer
│	│	│	├── 📄 DALSQL.cs			# Afhandeling SQL
│	│	│	├── 📄 DierRepository.cs
│	│	│	└── 📁 Interfaces/
│	│	│		└── 📄 IDierRepository.cs
│	│	└── 📁 Exceptions/				# Custom Exceptions
├── 📁 DatabaseScripts/					# SQL Database Scripts
│	├── 📄 create_all_if_not_exists.sql
│	├── 📄 create_dier.sql
│	├── 📄 create_diervoeding.sql
│	├── 📄 create_verblijf.sql
│	├── 📄 create_verblijfdier.sql
│	└── 📄 create_voedingschema.sql
├── 📁 Design/							# UML Design Files
├── .gitignore
└── 📄 readme.md						# Dit bestand
```

## Technologiestack

- **Framework**: .NET Core 9.0
- **UI**: Console applicatie
- **Database**: Microsoft SQL Server Management Studio 22
- **Modellering**: UMLet, DrawIO, Mermaid, PlantUML

## Ontwikkelomgeving

- **IDE**: Visual Studio 2026
- **Vereisten**: .NET Core SDK, SQL Server
- **Nuget package**: Microsoft.Data.SqlClient