# Task Management Project

## 📖 Description
The **Task Management Project** is a system designed to efficiently manage tasks and subtasks. It enables users to:
- Create tasks and assign them to team members.
- Transition tasks through various statuses (e.g., Todo → InProgress → CodeReview → QA → Done).
- Sort and filter tasks based on specific criteria.
- Log time spent on tasks and subtasks.

The project is built with scalability, maintainability, and flexibility in mind, leveraging several design patterns.

---

## ✨ Features
- **Task Creation**: Create tasks with optional subtasks.
- **State Transitions**: Move tasks through statuses like `Todo`, `InProgress`, `CodeReview`, `QA`, and `Done`.
- **Notifications**: Receive updates when task statuses change.
- **Sorting**: Sort tasks by estimation time.
- **Builder Pattern**: Flexible creation of subtasks.
- **Time Logging**: Track time spent on tasks and subtasks.

---

## 📂 Folder Structure

### **Main Files**
- **`Program.cs`**: Entry point of the application.
- **`models/`**: Contains core models like tasks, subtasks, and notifications.
- **`models/status/`**: Includes classes for task states (`Todo`, `InProgress`, `CodeReview`, `QA`, `Done`).
- **`models/task/`**: Contains the `Task`, `SubTask`, and `SubTaskBuilder` classes.
- **`models/sorter and filter task/`**: Implements sorting and filtering logic.
- **`interfaces/`**: Defines interfaces like `ISorter` and `IFilter`.
- **`enums/`**: Contains enumerations for task priorities and statuses.

---

## 🛠️ Design Patterns Used

### **State Pattern**
- **Purpose**: Allows objects to change behavior based on their state.
- **Example**: The `Task` class transitions through states (`Todo`, `InProgress`, etc.) using the `NextStatus()` method.

### **Builder Pattern**
- **Purpose**: Simplifies the creation of complex objects.
- **Example**: The `SubTaskBuilder` class constructs `SubTask` objects with optional properties.

### **Observer Pattern**
- **Purpose**: Enables objects to notify others about state changes.
- **Example**: The `Task` class uses the `Notify()` method to send updates when its status changes.

### **Strategy Pattern**
- **Purpose**: Defines interchangeable algorithms.
- **Example**: The `SortByEstimationTime` class sorts tasks based on their estimated completion time.

---

## 🔑 Key Files and Classes

### **Key Files**
1. **`Task.cs`**  
   - Core class representing tasks.
   - Manages properties like name, description, estimation time, and state transitions.
   - Includes methods like `NextStatus()` and `AddSubTask()`.

2. **`SubTask.cs`**  
   - Represents subtasks tied to a parent task.
   - Includes properties for name, parent task reference, and logged time.
   - Provides methods like `LogTime()`.

3. **`SubTaskBuilder.cs`**  
   - Implements the Builder pattern for creating `SubTask` objects.
   - Allows flexible construction with optional properties.

4. **State Classes (`Todo.cs`, `InProgress.cs`, `CodeReview.cs`, `QA.cs`, `Done.cs`)**  
   - Encapsulate logic for transitioning tasks between statuses.

5. **`SortByEstimationTime.cs`**  
   - Implements sorting logic for tasks based on their estimated completion time.

### **Key Classes**
- **`Task`**: Manages state transitions, subtasks, and notifications.
- **`SubTask`**: Tracks time and links to parent tasks.
- **`SubTaskBuilder`**: Simplifies subtask creation.
- **State Classes**: Handle task state transitions.
- **`SortByEstimationTime`**: Provides sorting functionality.

---

## 🚀 Getting Started

1. **Clone the Repository**  

```sh
git clone
```

2. **Build the Project**
   
   ```sh
dotnet build
```



3. **Run the Project**    
   
   ```sh
dotnet run
```

4. **Start Managing Tasks**  
   - Create tasks and subtasks.
   - Transition tasks through statuses.
   - Sort tasks by estimation time.

---

## 🛠️ Technologies Used
- **C#**
- **.NET Core**

---

## 📜 License
This project is licensed under the **MIT License**. See the `LICENSE` file for details.

---

## 📧 Contact
For questions or feedback, feel free to reach out via email or GitHub issues.

   
