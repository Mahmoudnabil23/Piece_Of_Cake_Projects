namespace Task_Tracker
{
    internal class Program
    {
        const int maxTasks = 100;
        static string[] tasks = new string[maxTasks];
        static int taskIndex = -1;
        static void Main(string[] args)
        {

            do
            { 
                // Welcome user
                displayMenu();


                int userChoice;
                Console.Write("Choose number from 1 to 5: ");
                while (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.Write("Invalid input. Enter a number: ");
                }

                switch (userChoice)
                {
                    // 1.Add Task
                    case 1:
                        addTask();
                        break;

                    // 2.view My tasks
                    case 2:
                        viewTasks();
                        break;

                    // 3.Mark task complete
                    case 3:
                        markCompleted();
                        break;

                    // 4.Remove Task
                    case 4:
                        removeTask();
                        break;

                    // 5.Exit
                    case 5:
                        Console.WriteLine("Good Bye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine();
            }
            while (true);

            
           
        }

        static int getValidInteger()
        {
            int input;
            // Loop until the user provides a valid integer
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
            return input;
        }
        static void addTask()
        {
            if (taskIndex >= tasks.Length - 1)
            {
                Console.WriteLine("You have reached the free limit storage");
                return;
            }
                Console.Write("Enter your Task: ");
                string userTask = Console.ReadLine();
                tasks[++taskIndex] = userTask;
                Console.WriteLine("Task is added");

            
        }

        static void markCompleted()
        {
            if(taskIndex == -1)
            {
                Console.WriteLine("no tasks available");
                return;
            }
            
            viewTasks();
            Console.Write("Choose Task number you need to marked it as complete: ");
            int userTaskIndex = getValidInteger() - 1;
            if (userTaskIndex > taskIndex || userTaskIndex < 0)
            {
                Console.WriteLine($"Invalid task number, choose a number from 1 to {taskIndex + 1}");
                return;
            }
            if (!tasks[userTaskIndex].Contains("---Completed"))
            {
                tasks[userTaskIndex] += " ---Completed";

                Console.WriteLine("Your task is marked as completed");
            }
            else
            {
                Console.WriteLine("Task is already completed.");
            }
        }

        static void removeTask() {
            if (taskIndex == -1)
            {
                Console.WriteLine("no tasks available");
                return;
            }
            
            viewTasks();

            Console.Write("Choose the task number you need to remove: ");
            int userTaskIndex = getValidInteger() - 1;

            if (userTaskIndex > taskIndex || userTaskIndex < 0)
            {
                Console.WriteLine($"Invalid task number, choose a number from 1 to {taskIndex+1}");
                return;
            }

            for (int i = userTaskIndex; i < taskIndex; i++)
            {
                tasks[i] = tasks[i + 1];
            }
            tasks[taskIndex] = null;
            taskIndex--;

            Console.WriteLine("Task is removed");
        }

        static void viewTasks() {
            if (taskIndex == -1)
            {
                Console.WriteLine("no tasks available");
                return;
            }
            Console.WriteLine("----------------");
            for (int i = 0; i <= taskIndex; i++) {
                Console.WriteLine($"{i+1}. {tasks[i]}");
            }
            Console.WriteLine("----------------");
        }

        static void displayMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("Welcoeme to Task Tracker App");
            Console.WriteLine("1.Add a Task");
            Console.WriteLine("2.View my tasks");
            Console.WriteLine("3.Mark Task Complete");
            Console.WriteLine("4.Remove a Task");
            Console.WriteLine("5.Exit");
            Console.WriteLine("==============================");
        }
    }
}
