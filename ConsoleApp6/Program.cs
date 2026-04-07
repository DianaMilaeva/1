/*using System;
using System.Security.Cryptography;

// абстрактный класс нельзя инстанциировать. Является основой для других классов
abstract class User // var user = new User(); так делать нельзя будет ошибка
{
    public Guid id { get; } = Guid.NewGuid(); // глобальный идентификатор объекта
    public string Name { get; set; }
    public string Email { get; set; }
    protected string PasswordHash { get; private set; }
    public abstract void PerformAction(string src);

    protected User (string Name, string Email, string Password)
    {
        Console.WriteLine($"Пользователь {Name} | {GetType().Name} вошёл в систему");
        this.Name = Name;
        this.Email = Email;
        this.PasswordHash = HashPassword(Password);
    }

    public bool Login(string Password)
    {
        var inputHash = HashPassword(Password);
        if (inputHash == PasswordHash) return true;
        return false;
    }
    private string HashPassword(string password)
    {
        using (SHA256 sha =  SHA256.Create())
        {
            byte[] PasswordBytes = System.Text.Encoding.UTF8.GetBytes(password); // превратить строку пароля в байты
            byte[] HashBytes = sha.ComputeHash(PasswordBytes); // передать байты в хеш-функцию, получить байты хеша
            return Convert.ToBase64String(HashBytes); // конвертировать хеш в строковое представление
        }
    }
}
class AdminUser(string Name, String Email, string Password) : User(Name, Email, Password)
{
    public override void PerformAction(string src)
    {
        Console.WriteLine($"Пользователь {Name} с правами {GetType().Name} удалил ресурс {src}");
    }
}

class CustomerUser(string Name, String Email, string Password) : User(Name, Email, Password)
{
    public override void PerformAction(string src)
    {
        Console.WriteLine($"Пользователь {Name} с правами {GetType().Name} прочитал ресурс {src}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        User[] users =
        {
            new AdminUser("Admin", "asrffh@pf.org", "adminpass"),
            new CustomerUser("User1", "dfrgf", "user1pass"),
            new CustomerUser("User2", "dfrgghjhjf", "user2pass"),
            new CustomerUser("User3", "djiookhhf", "user3pass")
        };
        foreach (var user in users)
        {
            if (user.Login("adminpass")) user.PerformAction("пост 1");
            if (user.Login("user3pass")) user.PerformAction("пост 3");
        }
    }
}*/