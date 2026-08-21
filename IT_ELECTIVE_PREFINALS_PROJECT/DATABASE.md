# Database Documentation

## Database Overview
- **Database Engine**: SQLite
- **Database File**: `lycevm.db`
- **ORM**: Entity Framework Core (Database-First, Manually mapped without scaffolding)

---

## Core Entities & Schema Description

### 1. `Departments`
Stores the departments within the organization.
- `DepartmentId` (INTEGER, Primary Key, Auto Increment)
- `Name` (TEXT, Required, Unique, MaxLength 50)
- `Code` (TEXT, Required, Unique, MaxLength 10)
- `IsActive` (INTEGER, Default 1)
- `CreatedAt` (TEXT, Default CURRENT_TIMESTAMP)

### 2. `Employees`
Stores staff members handling support tickets and team assignments.
- `EmployeeId` (INTEGER, Primary Key, Auto Increment)
- `FirstName` (TEXT, Required, MaxLength 50)
- `LastName` (TEXT, Required, MaxLength 50)
- `Email` (TEXT, Required, Unique, MaxLength 100)
- `Phone` (TEXT, Nullable, MaxLength 20)
- `DepartmentId` (INTEGER, Foreign Key referencing `Departments(DepartmentId)`)
- `JobTitle` (TEXT, Nullable, MaxLength 50)
- `IsActive` (INTEGER, Default 1)
- `HireDate` (TEXT, Nullable)

### 3. `Teams`
Groups employees into functional support teams.
- `TeamId` (INTEGER, Primary Key, Auto Increment)
- `Name` (TEXT, Required, Unique, MaxLength 50)
- `Description` (TEXT, Nullable, MaxLength 255)
- `DepartmentId` (INTEGER, Foreign Key referencing `Departments(DepartmentId)`)
- `IsActive` (INTEGER, Default 1)

### 4. `TeamMembers` (Composite Key: `TeamId` + `EmployeeId`)
Join table associating employees with teams and their specific roles.
- `TeamId` (INTEGER, Foreign Key referencing `Teams(TeamId)`)
- `EmployeeId` (INTEGER, Foreign Key referencing `Employees(EmployeeId)`)
- `RoleInTeam` (TEXT, Nullable, MaxLength 30)
- `JoinedAt` (TEXT, Default CURRENT_TIMESTAMP)

### 5. `Customers`
Stores client details who submit support tickets.
- `CustomerId` (INTEGER, Primary Key, Auto Increment)
- `Name` (TEXT, Required, MaxLength 100)
- `Email` (TEXT, Required, Unique, MaxLength 100)
- `Phone` (TEXT, Nullable, MaxLength 20)
- `Company` (TEXT, Nullable, MaxLength 100)
- `CreatedAt` (TEXT, Default CURRENT_TIMESTAMP)
- `IsActive` (INTEGER, Default 1)