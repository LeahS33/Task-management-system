# Task Management Project

## Description
The Task Management Project is a system designed to manage tasks and subtasks efficiently. It allows users to create tasks, assign them to team members, transition tasks through various statuses, and sort/filter tasks based on specific criteria. The project is built with a focus on scalability, maintainability, and flexibility, leveraging several design patterns.

## Features

- Task creation with optional subtasks
- State transitions for tasks (e.g., Todo → InProgress → CodeReview → QA → Done)
- Notifications for task status changes
- Sorting tasks by estimation time
- Flexible object creation using the Builder pattern

## Folder Structure

The project is organized into the following directories:

- **`TaskManagementProject/Program.cs`**  
  The entry point of the application, where all components are brought together to execute the task management logic.

- **`TaskManagementProject/models/`**  
  Contains core models used throughout the project, including tasks, subtasks, and notifications.

  - **`models/status/`**  
    Includes classes representing task states, such as `Todo`, `InProgress`, `CodeReview`, `QA`, and `Done`. Each class encapsulates the logic for transitioning between states.

  - **`models/task/`**  
    Contains the `Task` and `SubTask` classes, as well as the `SubTaskBuilder` class, which implements the Builder pattern for flexible object creation.

  - **`models/sorter and filter task/`**  
    - **`sorter/`**: Contains sorting logic, such as the `SortByEstimationTime` class, which sorts tasks based on their estimated completion time.  
    - **`filter/`**: Includes filtering logic, such as the `IFilter` interface, for tasks.

- **`TaskManagementProject/interfaces/`**  
  Defines interfaces used across the project, such as `ISorter` and `IFilter`, to ensure consistent implementation of sorting and filtering functionality.

- **`TaskManagementProject/enums/`**  
  Contains enumerations used in the project, such as task priorities or statuses.

## Design Patterns Used

This project incorporates the following design patterns:

### State Pattern
- **Purpose**: Allows an object to change its behavior when its internal state changes.
- **Usage**: 
  - The `Task` class transitions through various statuses (`Todo`, `InProgress`, `CodeReview`, `QA`, `Done`) using the `NextStatus` method. Each state class encapsulates the logic for transitioning to the next state.

### Builder Pattern
- **Purpose**: Simplifies the creation of complex objects by providing a step-by-step construction process.
- **Usage**: 
  - The `SubTaskBuilder` class is used to construct `SubTask` objects with optional properties, ensuring flexibility in object creation.

### Observer Pattern
- **Purpose**: Enables objects to notify other objects about changes in their state.
- **Usage**: 
  - The `Task` class uses the `Notify` method to send notifications to receivers when the task's status changes.

### Strategy Pattern
- **Purpose**: Defines a family of algorithms and makes them interchangeable at runtime.
- **Usage**: 
  - The `SortByEstimationTime` class implements sorting logic for tasks based on their estimated completion time.

## Solution Context

The project is organized into several files and classes:

### Key Files:
- **`TaskManagementProject/models/status/CodeReview.cs`**: Handles the transition logic for tasks in the "Code Review" state.
- **`TaskManagementProject/models/status/QA.cs`**: Manages the transition logic for tasks in the "QA" state.
- **`TaskManagementProject/models/status/InProgress.cs`**: Defines the behavior for tasks in the "In Progress" state.
- **`TaskManagementProject/models/status/Todo.cs`**: Represents tasks in the "To Do" state.
- **`TaskManagementProject/models/status/Done.cs`**: Represents tasks that are completed.
- **`TaskManagementProject/models/task/SubTaskBuilder.cs`**: Implements the Builder pattern for creating subtasks.
- **`TaskManagementProject/models/sorter and filter task/sorter/SortByEstimationTime.cs`**: Implements the Strategy pattern for sorting tasks.

### Key Classes:
- **`Task`**: Represents a task and manages its state transitions.
- **`SubTaskBuilder`**: Provides a flexible way to construct subtasks.
- **`SortByEstimationTime`**: Implements sorting logic for tasks.

## Getting Started

1. Clone the repository.
2. Build the project using `dotnet build`.
3. Run the project using `dotnet run`.
4. Create tasks, assign subtasks, and manage their statuses.

## Technologies Used

- C#
- .NET Core

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
