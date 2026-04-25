# 📚 Library Management System — Console App

A C# console application that simulates a library management system, built with a focus on clean OOP design.

## ✨ Features

- 📋 View branch information and all registered users
- 📖 Browse all book copies and available ones
- 🔄 Borrow and return book copies
- 💰 Automatic fine calculation for late returns (10 EGP/day)
- 👤 Register new members with validation
- 📜 View full borrowing history per member

## 🏗️ OOP Concepts Applied

| Concept | Where |
|---|---|
| **Inheritance** | `Librarian` and `Member` both inherit from `LibraryUser` |
| **Polymorphism** | `ToDisplay()` behaves differently per class |
| **Encapsulation** | Private lists exposed as `IReadOnlyList` |
| **Interfaces** | `IBorrowable`, `IDisplayable` |
| **Abstract Class** | `LibraryUser` shared base for all users |

## 🗂️ Project Structure
LibrarySystem/
├── Contracts/          # IBorrowable, IDisplayable
├── Extensions/         # StringExtensions
├── Helpers/            # ConsoleHelper, DataSeeder
├── Models/
│   ├── Enums/          # CopyStatus
│   ├── Book.cs
│   ├── BookCopy.cs
│   ├── BorrowTransaction.cs
│   ├── Librarian.cs
│   ├── LibraryBranch.cs
│   ├── LibraryUser.cs
│   └── Member.cs
├── Services/           # LibraryServices, DisplayServices
└── Program.cs

## ⚙️ How to Run

1. Clone the repository
2. Open `LibrarySystemSolution.sln` in Visual Studio
3. Press `F5` to run

## 🛠️ Tech Stack

- **Language:** C# (.NET 8)
- **Type:** Console Application

## 🔜 Next Step

This project was converted to a full **ASP.NET Core Web API** → [View API Project](https://github.com/EslamMagdy33/LibrarySystem-API)
