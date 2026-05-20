# 🛡️ ASP.NET Core Secure Application - Coding Challenge

## 📋 Problem Statement

Build a basic **ASP.NET Core MVC** web application for a small online shopping platform. The platform allows users to register, log in, view products, and make purchases.

Due to security concerns, the application must follow best practices for:
- Input validation
- Output encoding
- Secure coding techniques

**Goals:** Prevent common vulnerabilities such as **SQL Injection** and **Cross-Site Scripting (XSS)**. Implement **secure authentication and authorization** to ensure only authorized users can access certain parts of the platform.

---

## 👥 User Stories & Acceptance Criteria

---

### 1. 🔐 Secure Input Validation and Output Encoding

| # | Acceptance Criteria |
|---|---------------------|
| 1.1 | Implement secure input validation for user-provided data (username, email, password) on both client and server sides |
| 1.2 | Validate inputs to prevent SQL Injection using parameterized queries or ORM (Entity Framework) |
| 1.3 | Encode all user-generated content (reviews, comments, product descriptions) when displayed to prevent XSS attacks |
| 1.4 | Enforce strong password rules: minimum 8 characters, at least 1 uppercase letter, 1 number, and 1 special character |
| 1.5 | Display appropriate error messages for invalid form submissions |

---

### 2. 🛡️ Preventing SQL Injection

| # | Acceptance Criteria |
|---|---------------------|
| 2.1 | Ensure all database queries are parameterized |
| 2.2 | Avoid dynamic SQL queries or string concatenation involving user data |
| 2.3 | If raw SQL queries are used, ensure they are properly sanitized and parameterized |
| 2.4 | Use an ORM (e.g., Entity Framework) for all data access to ensure automatic SQL Injection protection |

---

### 3. 🔑 Authentication and Authorization

| # | Acceptance Criteria |
|---|---------------------|
| 3.1 | Implement user authentication using cookie-based or JWT-based authentication |
| 3.2 | Create two roles: **Admin** and **Customer** |
| 3.3 | Admins can access `/Admin/Dashboard` route |
| 3.4 | Customers can only view product listings and place orders |
| 3.5 | Use ASP.NET Core's built-in role-based authorization features |
| 3.6 | Unauthorized access → redirect to login page or show "Access Denied" message |

---

### 4. 📝 Secure User Registration and Login

| # | Acceptance Criteria |
|---|---------------------|
| 4.1 | Registration and login forms must validate and sanitize inputs |
| 4.2 | Store passwords securely (hashed and salted) in the database |
| 4.3 | Implement email validation to ensure valid email address format |
| 4.4 | Prevent brute-force attacks (using CAPTCHA or rate-limiting) |

---

### ⭐ Bonus: Secure Logout

| # | Acceptance Criteria |
|---|---------------------|
| B.1 | Invalidate session or authentication token on logout |
| B.2 | Clear all authentication cookies/tokens upon successful logout |
| B.3 | Redirect user to login page after logout |

---

## 📌 Additional Requirements

- ✅ ASP.NET Core MVC application with basic structure
- ✅ Use **Dependency Injection** for services (e.g., user authentication)
- ✅ Store user data in **in-memory database** or **simple SQL database**
- ✅ Focus only on: secure input validation, output encoding, and authentication/authorization

---

## 🛠️ Tech Stack (Suggested)

| Category | Technology |
|----------|------------|
| Framework | ASP.NET Core MVC |
| Database | In-Memory DB / SQL Server / SQLite |
| ORM | Entity Framework Core |
| Authentication | Cookie-based or JWT |
| Frontend | Razor Views |

---

## 🚀 How to Run

```bash
# Clone the repository
git clone <your-repo-url>

# Navigate to project folder
cd <project-folder>

# Restore dependencies
dotnet restore

# Run the application
dotnet run