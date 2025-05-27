# Task Management Project

A system designed to manage tasks and subtasks efficiently. The project includes task creation, assignment, state transitions, and sorting/filtering functionality, all implemented with a focus on scalability and maintainability.

## Features

- Task creation with optional subtasks
- State transitions for tasks (e.g., Todo → InProgress → CodeReview → QA → Done)
- Notifications for task status changes
- Sorting tasks by estimation time
- Flexible object creation using the Builder pattern

## Folder Structure

models/ ├── status/                # Classes for task states (Todo, InProgress, CodeReview, QA, Done) ├── task/                  # Task and SubTask classes, including the Builder pattern ├── sorter and filter task/ │   ├── sorter/            # Sorting logic (e.g., SortByEstimationTime) │   └── filter/            # Filtering logic (if applicable)

## Getting Started

1. Clone the repository.
2. Build the project using `dotnet build`.
3. Run the project using `dotnet run`.
4. Create tasks, assign subtasks, and manage their statuses.

## Design Patterns Used

### State Pattern
- **Purpose**: Allows tasks to transition through different states (e.g., Todo → InProgress → CodeReview → QA → Done).
- **Implementation**: Each state class encapsulates the logic for transitioning to the next state.

### Builder Pattern
- **Purpose**: Simplifies the creation of complex objects like tasks and subtasks.
- **Implementation**: The `SubTaskBuilder` class provides a step-by-step construction process.

### Observer Pattern
- **Purpose**: Sends notifications when a task's status changes.
- **Implementation**: The `Notify` method in the `Task` class alerts observers of state changes.

### Strategy Pattern
- **Purpose**: Enables interchangeable sorting algorithms.
- **Implementation**: The `SortByEstimationTime` class sorts tasks based on their estimated completion time.

## Technologies Used

- C#
- .NET Core

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
