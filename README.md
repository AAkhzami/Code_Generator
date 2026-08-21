# 🚀 C# Code Generator (Enhanced Edition)
# ⚡ C# 3-Tier Code Generator

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Architecture](https://img.shields.io/badge/Architecture-3--Tier-0078D4?style=for-the-badge)
![UI Library](https://img.shields.io/badge/UI-Guna_UI2-6366F1?style=for-the-badge)
![Status](https://img.shields.io/badge/Project-Enhanced_v2.0-success?style=for-the-badge)
## 👋 Hello & Welcome!

This is an enhanced version of the **C# Code Generator** tool. It automates the boilerplate creation of the **3-Tier Architecture** (Data Access Layer & Business Logic Layer) by analyzing SQL Server metadata, saving development time, eliminating manual coding errors, and letting you focus on core application logic.

---

## ⚡ Important Setup Note

> [!IMPORTANT]  
> Before running the solution in Visual Studio, ensure that **`Code_Generator_Desktop_Application`** is set as the **Startup Project**.  
> _Right-click `Code_Generator_Desktop_Application` in the Solution Explorer ➔ Select **Set as Startup Project**._

---

## 🎯 What's New in This Version?

- **⚙️ Core Refactoring (SOLID Principles):** Redesigned backend architecture using interfaces (`iBusinessGenerators`, `iDataAccessGenerator`) and decoupled builders to strictly adhere to the **Single Responsibility Principle (SRP)**.
- **📜 Stored Procedures Support:** Option to generate and automatically execute SQL Stored Procedures on SQL Server, generating seamless DAL wrapper code to call them.
- **🔌 Flexible Connection Management:** Choose between generating connection strings dynamically via `App.config` or through a dedicated Static Connection Class.
- **🎨 Modernized UI & Previews:** Updated user interface featuring real-time code previews (`Data Access Layer`, `Business Layer`, `Connection`, and `TSQL Scripts`), improved warnings, and enhanced export dialogs.
- **🧹 Automatic Code Formatting:** Integrated indentation engine (`clsHelper.FormatCode`) that formats `{ }` block structures automatically for clean, readable code output.

---

## 📸 Screenshots Showcase

### 🔐 1. Login & Connection Setup

Connect securely to your local or remote SQL Server instance.

![Login](/screenshots/login_screen.png)

---

### 🗄️ 2. Main Dashboard & Database Selection

View all available databases and inspect table properties dynamically.

|                     Select Database                     |       Main Interface Overview       |                      Table without Primary Key                       |
| :-----------------------------------------------------: | :---------------------------------: | :------------------------------------------------------------------: |
| ![Database](/screenshots/main_page_select_database.png) | ![Main](/screenshots/main_page.png) | ![Table Warning](/screenshots/main_page_select_table_without_PK.png) |

---

### ⚙️ 3. Engine Settings & Code Configurations

Configure generation options, operation types, and architecture settings.

|                Configuration 1                |                Configuration 2                |
| :-------------------------------------------: | :-------------------------------------------: |
| ![Setups 1](/screenshots/engine_setups_1.png) | ![Setups 2](/screenshots/engine_setups_2.png) |

---

### 👁️ 4. Real-Time Code Previewing

Inspect generated C# code layers and T-SQL scripts before exporting.

|                   Data Access Layer                    |                Business Logic Layer                 |                  Connection Code                  |                   T-SQL Scripts                    |
| :----------------------------------------------------: | :-------------------------------------------------: | :-----------------------------------------------: | :------------------------------------------------: |
| ![DAL](/screenshots/preview_code_DataAccess_Layer.png) | ![BLL](/screenshots/preview_code_Logical_Layer.png) | ![Conn](/screenshots/preview_code_connection.png) | ![SQL](/screenshots/preview_code_TSQL_Scripts.png) |

---

### 💾 5. Exporting Generated Code

Export `.cs` files and SQL scripts directly to your project destination.

|                 Export Form                  |                      Successful Export                       |
| :------------------------------------------: | :----------------------------------------------------------: |
| ![Export Form](/screenshots/Export_Form.png) | ![Export Success](/screenshots/Export_Form_Successfully.png) |

---

## ✨ Key Features

- **🔍 Dynamic Metadata Extraction:** Fetches databases, tables, columns, primary keys, identity columns, foreign keys, and constraints using SQL System Views.
- **🛠️ Smart Type Mapping:** Automatically maps SQL Server data types to equivalent C# data types (`varchar` ➔ `string`, `int` ➔ `int`, `bit` ➔ `bool`, etc.).
- **🏗️ Decoupled 3-Tier Code Generation:** Generates robust, production-ready `Data Access` and `Business Logic` classes.
- **📜 Automatic Stored Procedure Generation:** Generates T-SQL scripts for `Insert`, `Update`, `Delete`, `Select`, and `SelectAll` procedures.
- **⚡ Clean Code Formatter:** Formats generated code indentation automatically using internal helper routines.

---

## 🛠️ Tech Stack & Architecture

- **Language:** C# (.NET Framework)
- **UI Framework:** Windows Forms (WinForms with Guna UI2 / Custom Controls)
- **Database:** Microsoft SQL Server (ADO.NET / `System.Data.SqlClient`)
- **Design Patterns:** Builder Pattern, Facade Pattern (`clsMainBridge`), Interface Segregation (`iBusinessGenerators`, `iDataAccessGenerator`)
