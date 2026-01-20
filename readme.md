# TechTerra-Zoo

-----

[Team Subway Surfers]

-----

## Technische details

```cs
📦 Casus_TechTerra_Zoo/
├── 📁 Code/
│   ├── 📄 TechTerra_Zoo.sln     	# Visual Studio Solution
│   ├── 📁 TechTerra_Zoo/        	# Folder voor de applicatie
│   │   ├── 📄 Program.cs		# Service
│   │   ├── 📁 Models/        		# Domain Models
|   |   |   └── 📄 Dier.cs    		# Het model product
│   │   ├── 📁 DataAccess/     		# Data Access Layer
|   |   |   ├── 📄 DALSQL.cs	 	# Afhandeling SQL
|   |   |   ├── 📄 DierRepository.cs
|   |   |   └── 📁 Interfaces/
|   |   |   	└── 📄 IDierRepository.cs
│   │   └── 📁 Exceptions/     		# Custom Exceptions
├── 📁 DatabaseScripts/      		# SQL Database Scripts
|   └──📄 create_dier.sql		# SQl create script
├── 📁 Design/           		# UML Design Files
├── .gitignore
└── 📄 readme.md          		# Dit bestand
```

## Technologiestack

- **Framework**: .NET Core 9.0
- **UI**: Console applicatie
- **Database**: Microsoft SQL Server
- **Modellering**: UMLet, DrawIO, Mermaid, PlantUML

## Ontwikkelomgeving

- **IDE**: Visual Studio 2026
- **Vereisten**: .NET Core SDK, SQL Server
- **Nuget package**: Microsoft.Data.SqlClient