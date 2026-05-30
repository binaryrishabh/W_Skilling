
## Assignment 1: Applying SOLID Principles

### Objective
Refactor a given codebase to adhere to SOLID principles and ensure it is well-structured and maintainable.

### Problem Statement
You have been provided with a basic implementation of a reporting system. The current code does not adhere to SOLID principles, making it difficult to maintain and extend. Your task is to refactor the code to follow SOLID principles.

### User Stories & Acceptance Criteria

#### User Story 1: Implement Single Responsibility Principle (SRP)
**As a** developer, you need to refactor the existing code to ensure that each class has a single responsibility.

**Acceptance Criteria:**
- Refactor the `ReportManager` class, which currently handles both report generation and file saving, into separate classes
- Create a `ReportGenerator` class responsible for generating reports
- Create a `ReportSaver` class responsible for saving reports

#### User Story 2: Apply Open/Closed Principle (OCP)
**As a** developer, you need to refactor the code to ensure that it is open for extension but closed for modification.

**Acceptance Criteria:**
- Refactor the `ReportFormatter` class to use an interface for formatting
- Implement different formatting strategies (e.g., PDF, Excel) without modifying the existing `ReportFormatter` code

#### User Story 3: Implement Liskov Substitution Principle (LSP)
**As a** developer, you need to ensure that subclasses can be substituted for their base classes without affecting the correctness of the program.

**Acceptance Criteria:**
- Refactor the `Report` class hierarchy to ensure that derived classes correctly override base class methods
- Ensure derived classes can be used interchangeably with the base class

#### User Story 4: Apply Interface Segregation Principle (ISP)
**As a** developer, you need to ensure that clients are not forced to depend on interfaces they do not use.

**Acceptance Criteria:**
- Refactor the `IReport` interface to split it into smaller, more focused interfaces
- Ensure that classes implementing the interfaces only need to implement methods that are relevant to them

#### User Story 5: Implement Dependency Inversion Principle (DIP)
**As a** developer, you need to refactor the code to ensure that high-level modules are not dependent on low-level modules, but both depend on abstractions.

**Acceptance Criteria:**
- Refactor the `ReportService` class to depend on abstractions rather than concrete implementations
- Use dependency injection to provide the necessary dependencies

### Expected Outcome
A well-structured, maintainable, and extensible codebase that adheres to SOLID principles. The code should be easier to test, extend, and maintain due to separation of concerns.
