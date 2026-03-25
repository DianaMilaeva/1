/*class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[5];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 51);
        }
        try
        {
            Console.Write("Введите индекс: ");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine(array[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Индекс вне диапазона");
            Console.WriteLine("Весь массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Введите целое число");
            Console.WriteLine("Весь массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}*/

/*
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Число: " + number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Введите корректное целое число");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Число выходит за пределы int");
        }
    }
}
*/

/*
class Program
{
    static void Str(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException("Строка не может быть null");
        }
        if (str == "")
        {
            throw new ArgumentException("Строка не может быть пустой");
        }
        Console.WriteLine("Длина: " + str.Length);
    }
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Str(str);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
*/



class PasswordException(string msg) : Exception(msg) { }
class isLetterPassException(string msg) : PasswordException(msg) { }
class isUpperPassException(string msg) : PasswordException(msg) { }
class isLowerPassException(string msg) : PasswordException(msg) { }
class isDigitPassException(string msg) : PasswordException(msg) { }
class isSumbolPassException(string msg) : PasswordException(msg) { }
class isSixlPassException(string msg) : PasswordException(msg) { }

class CheckPassword
{
    public CheckPassword(string pass)
    {
        Password = pass;
    }
    private string password;
    public string Password
    {
        get { return password; }
        set
        {
            // в пароле должна быть буква
            // в пароле должна быть буква высокого регистра
            // в пароле должна быть буква низкого регистра
            // в пароле должно быть число
            // в пароле должен быть спецальный символ
            // пароль должен быть больше6-ти символов в длину
            // запретить использовать подстроки admin, qwerty, 123456
            // проверить строку на критерии выше если хотя бы один критерий не прошел - сообщить об этом

            List<PasswordException> errors = new List<PasswordException>();
            if (value.Length <= 6)
            {
                errors.Add(new isSixlPassException("Пароль должен быть длиннее 6 символов"));
            }
            string prohibitedStr = value.ToLower();
            if (prohibitedStr.Contains("admin"))
            {
                errors.Add(new PasswordException("Пароль не должен содержать подстроку 'admin'"));
            }
            if (prohibitedStr.Contains("qwerty"))
            {
                errors.Add(new PasswordException("Пароль не должен содержать подстроку 'qwerty'"));
            }
            if (prohibitedStr.Contains("123456"))
            {
                errors.Add(new PasswordException("Пароль не должен содержать подстроку '123456'"));
            }

            bool issumbol = false;
            bool isletter = false;
            bool isupper = false;
            bool islower = false;
            bool isdigit = false;

            foreach (char ch in value)
            {
                if (char.IsSymbol(ch) || char.IsPunctuation(ch)) { issumbol = true; }
                if (char.IsLetter(ch)) { isletter = true; }
                if (char.IsUpper(ch)) { isupper = true; }
                if (char.IsLower(ch)) { islower = true; }
                if (char.IsDigit(ch)) { isdigit = true; }
            }

            if (!issumbol) errors.Add(new isSumbolPassException("В пароле отсутствует специальный символ"));
            if (!isletter) errors.Add(new isLetterPassException("В пароле отсутствует буква"));
            if (!isupper) errors.Add(new isUpperPassException("В пароле отсутствует буква верхнего регистра"));
            if (!islower) errors.Add(new isLowerPassException("В пароле отсутствует буква нижнего регистра"));
            if (!isdigit) errors.Add(new isDigitPassException("В пароле отсутствует число"));

            if (errors.Any()) throw new AggregateException("Пароль не прошел проверку", errors);

            password = value;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var pass = new CheckPassword("");
        } catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}




/*class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());
            int result = num1 / num2;
            Console.WriteLine($"Результат: {result}");
        } catch(DivideByZeroException exc)
        {
            Console.WriteLine(exc.Message);
        } finally
        {
            Console.WriteLine("Сработал блок Finally");
        }
        Console.WriteLine("Программа успешно завершена");
    }
}*/
