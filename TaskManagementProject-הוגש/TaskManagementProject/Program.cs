// See https://aka.ms/new-console-template for more information
using TaskManagementProject.interfaces;
using TaskManagementProject.models.task;
using TaskManagementProject.models.notifications;
using TaskManagementProject.models.status;
using TaskManagementProject.models.user;
using TaskManagementProject.enums;
using System.Reflection;
using TaskManagementProject.models.sorter_and_filter_task;
using TaskManagementProject.models;
using TaskManagementProject.models.sorter_and_filter_task.sorter;
using System.Threading.Tasks;
using TaskManagementProject.models.sorter_and_filter_task.filter;

var manager = new Manager("Yossi Cohen", "yossi@email.com");
var qa = new TaskManagementProject.models.user.QA("Rivka Levy", "rivka@email.com");
User developer = new Developer("Dani Peretz", "dani@email.com");

// Create task builder with the required assignee and reporter
TaskBuilder taskBuilder = new TaskBuilder("Develop System", developer, manager);

// Set task details using builder methods
taskBuilder.BuildDescription("Task to develop a project management system")
           .BuildPriority(TaskPriority.High)
           .BuildEstimationTime(8);

// Build the task
TaskManagementProject.models.task.Task task = taskBuilder.build();
// Printing task details.
Console.WriteLine("----- Task Details -----");
Console.WriteLine($"Title: {task.Title}");
Console.WriteLine($"Description: {task.Description}");
Console.WriteLine($"Assignee: {task.Assignee.name} ({task.Assignee.email})");
Console.WriteLine($"Reporter: {task.Reporter.name} ({task.Reporter.email})");
Console.WriteLine($"Priority: {task.Priority}");
Console.WriteLine($"Estimation Time: {task.EstimationTime} hours");
Console.WriteLine($"Logged Time: {task.LoggedTime} hours");
Console.WriteLine($"Creation Date: {task.CreationDate}");


// Changing priority and verifying that the notification is sent.
Console.WriteLine("\n--- Changing Priority ---");
task.ChangePriority(TaskPriority.Medium);

// Add logged time
Console.WriteLine("\n--- Logging Time ---");
task.AddLoggedTime(3);
task.AddLoggedTime(5);
Console.WriteLine($"Updated Logged Time: {task.LoggedTime} hours");

// Creating subtask and adding it
Console.WriteLine("\n--- Adding Subtask ---");
SubTaskBuilder taskBuilder2 = new SubTaskBuilder("Write Documentation", developer, manager);
taskBuilder2.BuildDescription("Task to develop a project management system")
            .BuildPriority(TaskPriority.High)
            .BuildEstimationTime(2);
Subtask subTask = taskBuilder2.build();
task.AddSubtask(subTask);
Console.WriteLine($"Subtasks Count: {task.SubTasks.Count}");
Console.WriteLine($"Updated Estimation Time: {task.EstimationTime} hours");
Console.WriteLine($"Updated Logged Time: {task.LoggedTime} hours");

subTask.AddLoggedTime(33);
subTask.AddLoggedTime(5);
Console.WriteLine($"Updated Logged Time: {task.LoggedTime} hours");

// Creating subtask 2 and adding it
Console.WriteLine("\n--- Adding Subtask2 ---");
SubTaskBuilder taskBuilder3 = new SubTaskBuilder("Write Documentation", developer, manager);
taskBuilder3.BuildDescription("Task to develop a project management system")
            .BuildPriority(TaskPriority.High)
            .BuildEstimationTime(2);
Subtask subTask2 = taskBuilder3.build();
task.AddSubtask(subTask2);
Console.WriteLine($"Subtasks Count: {task.SubTasks.Count}");
Console.WriteLine($"Updated Estimation Time: {task.EstimationTime} hours");
subTask.AddLoggedTime(5);
Console.WriteLine($"Updated Logged Time: {task.LoggedTime} hours");
//Print task status
Console.WriteLine("\n--- Task status ---");
Console.WriteLine($"Task status: {task.Status}");
task.Status.NextStatus();
// Change status of the task
Console.WriteLine("\n--- Task status after change---");
task.Status.NextStatus();
Console.WriteLine($"Status after change: {task.Status}");

// Change status again
Console.WriteLine("\n--- Task status after change---");
task.Status.NextStatus(task.Reporter);
Console.WriteLine($"Status after another change: {task.Status}");

// Creating a list of tasks
List<TaskManagementProject.models.task.Task> tasks = new List<TaskManagementProject.models.task.Task>
{
    new TaskManagementProject.models.task.Task { Title = "Task 1", Priority = TaskPriority.Low, LoggedTime = 3, EstimationTime = 5, Status = new Todo(null) },
    new TaskManagementProject.models.task.Task { Title = "Task 2", Priority = TaskPriority.High, LoggedTime = 7, EstimationTime = 4, Status = new InProgress(null) },
    new TaskManagementProject.models.task.Task { Title = "Task 3", Priority = TaskPriority.Medium, LoggedTime = 5, EstimationTime = 3, Status = new Done(null) },
    new TaskManagementProject.models.task.Task { Title = "Task 4", Priority = TaskPriority.High, LoggedTime = 2, EstimationTime = 6, Status = new Todo(null) },
    new TaskManagementProject.models.task.Task { Title = "Task 5", Priority = TaskPriority.Medium, LoggedTime = 8, EstimationTime = 4, Status = new InProgress(null) }
};

// Creating Context instance
Context context = new Context();

// Applying filter by status "To Do"
Console.WriteLine("\n--- Filtering Tasks by Status: To Do ---");
IFilter filterByStatus = new FilterByStatus(new Todo(null));
context.SetFilter(filterByStatus);
var filteredTasks = context.SortAndFilter(tasks);
PrintTasks(filteredTasks);
context.SetFilter(null);

// Sorting by Priority
Console.WriteLine("\n--- Sorting Tasks by Priority ---");
ISorter sorter = new SortByPriority();
context.SetSorter(sorter);
List<TaskManagementProject.models.task.Task> sortedTasks = context.SortAndFilter(tasks);
PrintTasks(sortedTasks);

// Sorting by Logged Time
Console.WriteLine("\n--- Sorting Tasks by Logged Time ---");
context.SetSorter(new SortByLoggedTime());
PrintTasks(context.SortAndFilter(tasks));

// Sorting by Estimation Time
Console.WriteLine("\n--- Sorting Tasks by Estimation Time ---");
context.SetSorter(new SortByEstimationTime());
PrintTasks(context.SortAndFilter(tasks));

// Sorting by Status
Console.WriteLine("\n--- Sorting Tasks by Status ---");
context.SetSorter(new SortByStatus());
PrintTasks(context.SortAndFilter(tasks));

static void PrintTasks(List<TaskManagementProject.models.task.Task> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks match the filter criteria.");
        return;
    }
    foreach (var task in tasks)
    {
        Console.WriteLine($" Task Title: {task.Title}, Priority: {task.Priority}, Logged Time: {task.LoggedTime}, Estimation Time: {task.EstimationTime}, Status: {task.Status}");
    }
    Console.WriteLine(); 
}