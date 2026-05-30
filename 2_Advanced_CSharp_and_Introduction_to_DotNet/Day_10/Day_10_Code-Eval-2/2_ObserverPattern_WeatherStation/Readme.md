
## Assignment 2: Design Patterns Implementation

### Objective
Implement a basic example using a common design pattern to demonstrate its application in .NET.

### Problem Statement
Implement a simple example using a common design pattern. Choose one of the following patterns: **Singleton, Factory, or Observer**. Implement the pattern in a .NET application and demonstrate its usage.

### User Stories & Acceptance Criteria

#### Option 1: Singleton Pattern

**User Story:** Implement a Singleton Pattern

**As a** developer, you need to implement the Singleton pattern to ensure that a class has only one instance and provides a global point of access to it.

**Acceptance Criteria:**
- Implement a `Logger` class as a Singleton
- Ensure that only one instance of `Logger` is created and used throughout the application
- Demonstrate the use of this `Logger` class in a sample application

#### Option 2: Factory Pattern

**User Story:** Implement a Factory Pattern

**As a** developer, you need to implement the Factory pattern to create objects without specifying the exact class of object that will be created.

**Acceptance Criteria:**
- Implement a `DocumentFactory` class that creates different types of documents (e.g., `PDFDocument`, `WordDocument`)
- Ensure that the factory method returns the correct type of document based on input parameters

#### Option 3: Observer Pattern

**User Story:** Implement an Observer Pattern

**As a** developer, you need to implement the Observer pattern to allow objects to notify other objects about changes in their state.

