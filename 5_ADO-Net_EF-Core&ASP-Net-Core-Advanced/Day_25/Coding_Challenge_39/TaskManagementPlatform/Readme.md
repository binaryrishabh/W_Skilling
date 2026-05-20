# 🔐 Coding Challenge 39: Secure Authentication & Authorization in ASP.NET Core MVC

## 📋 Problem Statement

Build a secure **ASP.NET Core MVC** web application for a task management platform. The application allows users to register, log in, manage tasks, and access different features based on their roles.

### 🛡️ Security Focus

- Protect against **CSRF**, **XSS**, and **SQL Injection**
- Implement secure **session management**
- Use **role-based** and **claims-based** authorization

---

## 📌 User Stories & Acceptance Criteria

### 1. Secure Forms Authentication

| # | Acceptance Criteria |
|---|---------------------|
| ✅ | Implement forms-based authentication using ASP.NET Core Identity or custom cookie-based authentication |
| ✅ | Ensure user credentials (passwords) are hashed and salted before database storage |
| ✅ | Implement secure login/registration forms with input validation and sanitization |
| ✅ | Redirect users to **Dashboard** page after successful login |
| ✅ | Protect restricted pages — authentication required before access |

---

### 2. Secure Authorization with Roles & Claims

| # | Acceptance Criteria |
|---|---------------------|
| ✅ | Implement two roles: **Admin** and **User** |
| ✅ | **Admin** → Access `/Admin/ManageTasks` page |
| ✅ | **User** → Access `/User/TaskList` page |
| ✅ | Use claims-based authorization (e.g., `CanEditTask` claim for users to edit their own tasks) |
| ✅ | Configure authorization policies to control access based on roles and claims |

---

### 3. Protecting Against CSRF & XSS

| # | Acceptance Criteria |
|---|---------------------|
| ✅ | All forms (login, registration, task management) protected by **anti-forgery tokens** |
| ✅ | Use ASP.NET Core's built-in anti-forgery token mechanism for all form submissions |
| ✅ | Encode all user-generated content (task descriptions, comments) to prevent XSS |
| ✅ | Apply proper **input validation** and **output encoding** on all text input fields |

---

### 4. Secure Session Management

| # | Acceptance Criteria |
|---|---------------------|
| ✅ | Secure cookies with **HttpOnly** and **Secure** flags |
| ✅ | Set session expiration — auto logout after **inactivity (e.g., 15 minutes)** |
| ✅ | Enforce **HTTPS** for all cookies using Secure cookie attribute |
| ✅ | Use secure session tokens (JWTs or ASP.NET Core cookies) |
| ✅ | Protect session information from unauthorized access |

---

### ⭐ Bonus: Secure Logout Implementation

| # | Acceptance Criteria |
|---|---------------------|
| ✅ | Invalidate session/authentication token on logout |
| ✅ | Clear authentication cookies upon successful logout |
| ✅ | Redirect user to **login page** after logout |
| ✅ | Prevent access to restricted pages after logout |

---

## 📁 Additional Requirements

- ✅ ASP.NET Core MVC application with **clear MVC structure**
- ✅ Use **Dependency Injection** for authentication & authorization services
- ✅ Store user data in **in-memory database** or **SQL database**
- ✅ Follow best practices for:
  - Secure input validation
  - Output encoding
  - Session management

---

## 🛠️ Tech Stack (Suggested)

| Layer | Technology |
|-------|-------------|
| Framework | ASP.NET Core MVC (.NET 6/7/8) |
| Authentication | ASP.NET Core Identity |
| Database | SQL Server / SQLite / In-Memory |
| Security | Anti-forgery tokens, Data Protection API |
| Session Management | Cookie-based with Secure & HttpOnly flags |

---

## ✅ Deliverables

- [ ] Fully functional ASP.NET Core MVC application
- [ ] All 4 user stories implemented
- [ ] Bonus story implemented (optional)
- [ ] Code following secure coding practices
- [ ] This README file with setup instructions (optional)

---

> 📝 **Note:** This challenge focuses on **security-first development**. Every endpoint, form, and session must follow industry best practices.