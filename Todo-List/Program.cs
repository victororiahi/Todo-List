using System;
using System.Collections.Generic;

List<Task> tasks = new List<Task>();

while (true)
{
    Console.WriteLine("\nTo-Do List Menu:");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. Remove Task");
    Console.WriteLine("3. Mark Task as Done");
    Console.WriteLine("4. View Tasks");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask();
            break;
        case "2":
            RemoveTask();
            break;
        case "3":
            MarkTaskAsDone();
            break;
        case "4":
            ViewTasks();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            break;
    }
}

void AddTask()
{
    Console.Write("Enter the task description: ");
    string description = Console.ReadLine();
    tasks.Add(new Task(description));
    Console.WriteLine("Task added.");
}

void RemoveTask()
{
    ViewTasks();
    Console.Write("Enter the number of the task to remove: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
    {
        tasks.RemoveAt(taskNumber - 1);
        Console.WriteLine("Task removed.");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

void MarkTaskAsDone()
{
    ViewTasks();
    Console.Write("Enter the number of the task to mark as done: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
    {
        tasks[taskNumber - 1].IsDone = true;
        Console.WriteLine("Task marked as done.");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

void ViewTasks()
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks to display.");
    }
    else
    {
        Console.WriteLine("\nTasks:");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsDone ? "[Done]" : "[Not Done]";
            Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
        }
    }
}

class Task
{
    public string Description { get; }
    public bool IsDone { get; set; }

    public Task(string description)
    {
        Description = description;
        IsDone = false;
    }
}
