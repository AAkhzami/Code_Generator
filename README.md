# 🚀 C# Code Generator Project

# 👋 Hello!

This is a project I built to solve a problem I faced while learning and do some project. I noticed that writing the same code over and over for Data Access and Business layers takes a lot of time, so I decided to build this tool to do it for me!

## 🎯 Overview

A tool designed to automate the creation of **Multi-Tier Architecture** layers for C# applications. This generator connects directly to **SQL Server**, analyzes database metadata, and instantly produces production-ready code for both **Data Access** and **Business Logic** layers.

---

## 📸 How it looks (Screenshots)

### 🔐 1. Login Screen

![Login](/screenshots/login_screen.png)

I made this screen to connect securely to the SQL Server.

### 🗄️ 2. Database Selection

![Database](/screenshots/select_database.png)

Once connected, you can see all your databases and choose the one you want to work on.

### 📊 3. Table & Code Generation

![Tables](/screenshots/select_tables.png)

This is the heart of the project! You select a table, and the tool shows you the columns and generates the `Data Layer` and `Business Layer` files for you.

---

## ✨ Key Features

- 🔍 **Dynamic Metadata Extraction:** Automatically fetches databases, tables, and column details using SQL System Views.
- 🛠 **Smart Type Mapping:** Seamlessly maps SQL data types to their corresponding C# types.
- ⚡ **Identity Column Intelligence:** Automatically detects `IsIdentity` columns to handle primary keys and auto-increment.
- 🏗 **Layered Architecture:** Generates clean, decoupled code following the **N-Tier** pattern (Data Access & Business Layers).
- 📂 **File Exporting:** Exports generated code directly into `.cs` files with a single click.

## 🏗 System Architecture

The tool generates a robust architecture based on:

1. **Data Access Layer (DAL):** Uses `ADO.NET` with optimized `SqlClient` commands for CRUD operations.
2. **Business Logic Layer (BLL):** Creates object-oriented representations of database entities with integrated validation logic.
3. **UI Layer:** A user-friendly **Windows Forms** interface for managing the generation process.

## 🚀 How to Use

1. **Connect:** Enter your SQL Server credentials and select your target database.
2. **Select:** Choose the table you want to generate code for.
3. **Generate:** The engine uses `StringBuilder` and predefined templates to construct the logic.
4. **Export:** Save your professional `.cs` files and include them in your project immediately.

## 🛠 Tech Stack

- **Language:** C# (.NET Framework)
- **Database:** Microsoft SQL Server
- **Logic:** Advanced String Manipulation & Metadata Analysis
