# ✅ Todos — Task Management System  

This is a **fullstack web application** built with **ASP.NET Core MVC** in C#.  
The project simulates a **task management system**, where users can register, log in, and manage their personal todo lists.  

## 🚀 Features  

- 👤 **User Authentication** — registration, login, logout  
- 📝 **Todo Management** — create, edit, delete, and mark tasks as completed  
- 🔍 Filtering and searching tasks  
- 📊 Separation of tasks per user (only your tasks are visible)  
- ⚡ Automatic UI refresh after actions (MVC views)  

## 🛠 Tech Stack  

### Backend  
- ASP.NET Core MVC  
- C#  
- Entity Framework Core  
- LINQ  

### Frontend  
- Razor Views (MVC)  
- Bootstrap / CSS  
- JavaScript  

## 📦 Installation  

> 1. Download and extract the ZIP file of the project  
> 2. Open the solution file `Todos.sln` in **Visual Studio 2022**  
> 3. Restore NuGet packages (automatic during build)  
> 4. Configure your SQL Server connection string in `appsettings.json`  
> 5. Apply migrations and create the database:  
>    ```bash
>    dotnet ef database update
>    ```  
> 6. Run the project with **F5** or the **Run** button in Visual Studio  

---

## 📂 Modules  

### 👤 Authentication  
- User registration  
- User login/logout  

### 📝 Todos  
- Create new tasks  
- Edit task details  
- Delete tasks  
- Mark tasks as completed/incomplete  
- View all tasks for the logged-in user  

---

## ✅ Requirements  
- .NET 9 SDK  
- SQL Server 2022 (or LocalDB)  
- Visual Studio 2022 with ASP.NET Core development tools  

---

## 🔄 Updates  
This project is **in active development** and will be regularly updated with new features and improvements.  
