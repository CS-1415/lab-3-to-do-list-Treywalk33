//Treu Walker, 2/1/25, to do list
using System;
using System.Collections.Generic;
using System.Linq;

public class Task
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }

    public Task(int id, string title, string description)
    {
        ID = id;
        Title = title;
        Description = description;
        IsComplete = false;
    }

    public void DisplayTask()
    {
        Console.WriteLine($"{ID}. {Title} {(IsComplete ? "[Complete]" : "[Pending]")}");
    }

    public void DisplayDescription()
    {
        Console.WriteLine($"Description: {Description}");
    }

    public void MarkAsCompleted()
    {
        IsComplete = !IsComplete; 
    }
}

public class ToDoList
{
    private List<Task> taskList;

    public ToDoList()
    {
        taskList = new List<Task>();
    }

    public void Run()
    {
        while (true)
        {
            
            DisplayAllTasks();

            Console.Write("Enter command (i for info, + to add, x to toggle, q to quit): ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "i":
                    DisplayTaskInfo();
                    break;
                case "+":
                    AddTask();
                    break;
                case "x":
                    ToggleTaskCompletion();
                    break;
                case "q":
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }


    private void DisplayAllTasks()
    {
        Console.WriteLine("\n--- ToDo List ---");
        if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
        }
        else
        {
            foreach (var task in taskList)
            {
                task.DisplayTask();
            }
        }
        Console.WriteLine("------------------\n");
    }

    private void DisplayTaskInfo()
    {
        Console.Write("Enter task number for details: ");
        if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0 && taskId <= taskList.Count)
        {
            taskList[taskId - 1].DisplayDescription();
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    private void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();

        int newTaskId = taskList.Count + 1; // Simple ID assignment
        taskList.Add(new Task(newTaskId, title, description));
        Console.WriteLine("Task added.");
    }

    private void ToggleTaskCompletion()
    {
        Console.Write("Enter task number to toggle: ");
        if (int.TryParse(Console.ReadLine(), out int taskId) && taskId > 0 && taskId <= taskList.Count)
        {
            taskList[taskId - 1].MarkAsCompleted();
            Console.WriteLine($"Task {taskId} completion toggled.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }


    public static void Main(string[] args)
    {
        ToDoList todo = new ToDoList();
        todo.Run();
    }
}