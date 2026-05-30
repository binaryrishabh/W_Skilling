# Secure & Reliable .NET Application

## Task 1: User Authentication
- Create User model (Username, HashedPassword)
- Implement Register() and Authenticate() methods
- Hash passwords using SHA-256 before storing
- Verify hashed password on login

## Task 2: Data Encryption
- Encrypt sensitive user data using AES (System.Security.Cryptography)
- Implement decryption method

## Task 3: Error Handling & Logging
- Use try-catch blocks
- Set up logging framework (NLog/Serilog/log4net)
- Log errors with timestamps, messages, stack traces
- Do NOT expose sensitive info in error messages

## Task 4: Unit Tests
- Test User Authentication (register, login, hashing)
- Test Data Encryption (encrypt & decrypt)
- Test Error Handling (simulate errors)
- Test Logging (verify log content)

## Submission
- Single project (application + unit tests)
- Include comments and documentation