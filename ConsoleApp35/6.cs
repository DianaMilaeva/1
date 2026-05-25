/*
class User
{
    private string _password;
    public string Login { get; set; }
    public User(string password, string login)
    {
        _password = password;
        Login = login;
    }
    public bool CheckPassword(string input)
    {
        if (input == _password) return true;
        return false;
    }
}
class Program
{
    static void Main(string[] args)
    {
        User user = new User("12345", "Иван");
        Console.WriteLine("Введите пароль: ");
        string input = Console.ReadLine();
        if (user.CheckPassword(input))
        {
            Console.WriteLine("Пароль верный");
        }
        else Console.WriteLine("Пароль неверный");
    }
}
*/