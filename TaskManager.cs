abstract class Task
{
    private string title;
    private string description;
    private DateTime deadline;
    private bool isCompleted;
    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Название задачи не может быть пустым!");
            title = value;
        }
    }
    public string Description
    {
        get { return description; }
        set
        {
            if (value == null)
            {
                description = "";
            }
            else
            {
                description = value;
            }
        }
    }
    public DateTime Deadline
    {
        get { return deadline; }
        set
        {
            if (value < DateTime.Now) throw new Exception("Крайний срок не может быть в прошлом");
            deadline = value;
        }
    }
    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }
    protected Task(string title, string description, DateTime deadline)
    {
        Title = title;
        Description = description;
        Deadline = deadline;
        IsCompleted = false;
    }
    public abstract bool IsOverdue();
    public virtual string GetInfo()
    {
        string status;
        if (IsCompleted == true)
        {
            status = "[ВЫПОЛНЕНО]";
        }
        else
        {
            status = "[НЕ ВЫПОЛНЕНО]";
        }
        string deadlineText = Deadline.ToString("dd.MM.yyyy HH:mm");
        string timeLeftText = GetTimeLeft();
        string result = status + " " + Title + " | Дедлайн: " + deadlineText + " | " + timeLeftText;
        return result;
    }
    protected string GetTimeLeft()
    {
        if (IsCompleted) return "Выполнено";
        if (IsOverdue()) return "ПРОСРОЧЕНО!";

        TimeSpan left = Deadline - DateTime.Now;
        if (left.TotalHours < 24)
        {
            return "Осталось: " + left.Hours + "ч " + left.Minutes + "мин";
        }
        else
        {
            return "Осталось: " + left.Days + "д";
        }
    }
}
class SimpleTask : Task
{
    public SimpleTask(string title, string description, DateTime deadline): base(title, description, deadline)
    {
    }
    public override bool IsOverdue()
    {
        if (IsCompleted) return false;
        if (DateTime.Now > Deadline) return true;
        return false;
    }
}
class RecurringTask : Task
{
    private int intervalDays;

    public RecurringTask(string title, string description, DateTime startDeadline, int intervalDays): base(title, description, startDeadline)
    {
        this.intervalDays = intervalDays;
    }
    public override bool IsOverdue()
    {
        if (IsCompleted) return false;
        DateTime nextDeadline = Deadline;
        while (nextDeadline < DateTime.Now)
        {
            nextDeadline = nextDeadline.AddDays(intervalDays);
        }
        if (nextDeadline == Deadline) return true;
        return false;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + " (повтор каждые " + intervalDays + " дня)";
    }
}
class ImportantTask : Task
{
    private bool confirmationReceived;
    public ImportantTask(string title, string description, DateTime deadline)
        : base(title, description, deadline)
    {
        confirmationReceived = false;
    }
    public void ConfirmCompletion()
    {
        confirmationReceived = true;
        Console.WriteLine("Важная задача \"" + Title + "\": подтверждение получено");
    }
    public override bool IsOverdue()
    {
        if (IsCompleted) return false;
        if (!confirmationReceived && DateTime.Now > Deadline) return true;
        return false;
    }
    public override string GetInfo()
    {
        string status;
        if (IsCompleted)
        {
            if (confirmationReceived) status = "Выполнена";
            else status = "Ждет подтверждения";
        }
        else
        {
            if (IsOverdue()) status = "ПРОСРОЧЕНА";
            else status = "В работе";
        }
        return "[ВАЖНО] " + base.GetInfo() + " | Статус: " + status;
    }
}
interface INotifiable
{
    void SendNotification();
}
class TaskManager : INotifiable
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
        Console.WriteLine("Задача \"" + task.Title + "\" добавлена");
    }
    public void ShowAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст");
            return;
        }
        Console.WriteLine("\nВсе задачи");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + tasks[i].GetInfo());
        }
    }
    public void SendNotification()
    {
        Console.WriteLine("\nПроверка уведомлений");
        bool hasNotifications = false;

        for (int i = 0; i < tasks.Count; i++)
        {
            Task task = tasks[i];

            if (!task.IsCompleted && task.IsOverdue())
            {
                Console.WriteLine("УВЕДОМЛЕНИЕ: Задача \"" + task.Title + "\" ПРОСРОЧЕНА (Дедлайн был " + task.Deadline.ToString("dd.MM.yyyy HH:mm") + ")");
                hasNotifications = true;
            }
            else if (!task.IsCompleted)
            {
                TimeSpan timeLeft = task.Deadline - DateTime.Now;
                if (timeLeft.TotalHours < 2 && timeLeft.TotalHours > 0)
                {
                    Console.WriteLine("НАПОМИНАНИЕ: Задача \"" + task.Title + "\" будет просрочена через " + timeLeft.Hours + "ч " + timeLeft.Minutes + "мин");
                    hasNotifications = true;
                }
            }
        }

        if (!hasNotifications)
        {
            Console.WriteLine("Все задачи в порядке просрочек нет");
        }
    }
    public void CompleteTask(int index)
    {
        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("Ошибка: неверный номер задачи");
            return;
        }
        Task task = tasks[index];
        if (task is ImportantTask)
        {
            ImportantTask importantTask = task as ImportantTask;
            Console.WriteLine("Важная задача \"" + task.Title + "\" требует подтверждения завершения!");
            Console.Write("Введите 'ПОДТВЕРЖДАЮ', чтобы завершить: ");
            string confirm = Console.ReadLine();
            if (confirm == "ПОДТВЕРЖДАЮ")
            {
                importantTask.ConfirmCompletion();
                task.IsCompleted = true;
                Console.WriteLine("Задача \"" + task.Title + "\" отмечена как выполненная");
            }
            else
            {
                Console.WriteLine("Задача не завершена (подтверждение не получено)");
            }
        }
        else
        {
            task.IsCompleted = true;
            Console.WriteLine("Задача \"" + task.Title + "\" отмечена как выполненная");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        TaskManager manager = new TaskManager();
        while (true)
        {
            Console.WriteLine("\nМеню");
            Console.WriteLine("1. Добавить обычную задачу");
            Console.WriteLine("2. Добавить повторяющуюся задачу");
            Console.WriteLine("3. Добавить важную задачу");
            Console.WriteLine("4. Показать все задачи");
            Console.WriteLine("5. Отметить задачу как выполненную");
            Console.WriteLine("6. Проверить уведомления");
            Console.WriteLine("7. Выход");
            Console.Write(">_: ");
            string choice = Console.ReadLine();
            try
            {
                if (choice == "1")
                {
                    AddSimpleTask(manager);
                }
                else if (choice == "2")
                {
                    AddRecurringTask(manager);
                }
                else if (choice == "3")
                {
                    AddImportantTask(manager);
                }
                else if (choice == "4")
                {
                    manager.ShowAllTasks();
                }
                else if (choice == "5")
                {
                    Console.Write("Введите номер задачи для завершения: ");
                    string input = Console.ReadLine();
                    int taskIndex;
                    if (int.TryParse(input, out taskIndex))
                    {
                        manager.CompleteTask(taskIndex - 1);
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод");
                    }
                }
                else if (choice == "6")
                {
                    manager.SendNotification();
                }
                else if (choice == "7")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Неверный выбор!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    static void AddSimpleTask(TaskManager manager)
    {
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Описание: ");
        string desc = Console.ReadLine();
        DateTime deadline = GetDateFromUser();

        SimpleTask task = new SimpleTask(title, desc, deadline);
        manager.AddTask(task);
    }

    static void AddRecurringTask(TaskManager manager)
    {
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Описание: ");
        string desc = Console.ReadLine();
        DateTime deadline = GetDateFromUser();
        Console.Write("Интервал повторения (дней, по умолчанию 3): ");
        string intervalInput = Console.ReadLine();
        int interval = 3;
        if (intervalInput != "")
        {
            int.TryParse(intervalInput, out interval);
        }

        RecurringTask task = new RecurringTask(title, desc, deadline, interval);
        manager.AddTask(task);
    }

    static void AddImportantTask(TaskManager manager)
    {
        Console.Write("Название: ");
        string title = Console.ReadLine();
        Console.Write("Описание: ");
        string desc = Console.ReadLine();
        DateTime deadline = GetDateFromUser();

        ImportantTask task = new ImportantTask(title, desc, deadline);
        manager.AddTask(task);
    }

    static DateTime GetDateFromUser()
    {
        while (true)
        {
            try
            {
                Console.Write("Крайний срок (день.месяц.год час:минута, например 25.12.2025 15:30): ");
                string input = Console.ReadLine();
                return DateTime.Parse(input);
            }
            catch
            {
                Console.WriteLine("Неверный формат даты! Попробуйте снова.");
            }
        }
    }
}