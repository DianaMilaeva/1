/*
Hash2.cs - Реализация хеширования через иерархию наследования
В данной версии используется классический ООП-подход:
Абстрактный базовый класс HashKit задаёт общий контракт
Конкретные классы MD5Kit, SHA1Kit, SHA256Kit наследуют базовый
Принципы ООП:
Инкапсуляция: внутренние методы защищены, скрыты от внешнего кода
Наследование: каждый алгоритм в отдельном классе-наследнике
Абстракция: базовый класс нельзя инстанциировать напрямую
Полиморфизм: переопределение ToString() даёт разное поведение
 */

using System.Security.Cryptography;
using System.Text;

// Абстрактный базовый класс для всех алгоритмов хеширования
// Не может быть создан напрямую - только через наследников
// Содержит общую логику, которая будет переиспользована
abstract class HashKit
{
    // Защищённое свойство для хранения алгоритма
    // Инициализируется в конструкторах наследников
    protected HashAlgorithm Algo { get; set; }

    // Вспомогательный метод: строка -> байты UTF-8
    // Защищён - доступен только наследникам
    protected byte[] getBytes(string word) => Encoding.UTF8.GetBytes(word);

    // Вспомогательный метод: байты -> Base64 строка
    protected string getString(byte[] bytes) => Convert.ToBase64String(bytes);

    // Вычисление хеша с использованием текущего алгоритма
    protected byte[] getHash(byte[] bytes) => Algo.ComputeHash(bytes);

    // Публичный метод, доступный всем
    // Реализует шаблонный алгоритм: строка -> хеш -> Base64
    // Наследники не должны переопределять этот метод (если только нет особой необходимости)
    public string GetHashWord(string word) => getString(getHash(getBytes(word)));
}

// Реализация MD5 - наследник HashKit
// Принцип наследования: MD5Kit является разновидностью HashKit
class MD5Kit : HashKit
{
    // Конструктор инициализирует унаследованное свойство Algo алгоритмом MD5
    public MD5Kit() => this.Algo = MD5.Create();

    // Переопределение ToString() - пример полиморфизма
    // Базовый класс Object имеет виртуальный метод ToString()
    // Мы даём свою реализацию, специфичную для MD5
    public override string ToString() => "MD5 Algorithm";
}

// Реализация SHA1 - наследник HashKit
class SHA1Kit : HashKit
{
    public SHA1Kit() => this.Algo = SHA1.Create();
    public override string ToString() => "SHA1 Algorithm";
}

// Реализация SHA256 - наследник HashKit
class SHA256Kit : HashKit
{
    public SHA256Kit() => this.Algo = SHA256.Create();
    public override string ToString() => "SHA256 Algorithm";
}

// Фабричный класс - создаёт объекты нужных наследников HashKit
class HashManager
{
    // Возвращает HashKit (но реально возвращает одного из наследников)
    // Это полиморфное поведение: объект дочернего класса возвращается как родительский тип
    public HashKit GetHashAlgorithm(int choice)
    {
        return choice switch
        {
            1 => new MD5Kit(),      // Создаём конкретный объект MD5Kit
            2 => new SHA1Kit(),     // Создаём конкретный объект SHA1Kit
            3 => new SHA256Kit(),   // Создаём конкретный объект SHA256Kit
            _ => throw new ArgumentException("Неверный выбор алгоритма")
        };
    }
}

// Главный класс приложения
class Program
{
    static void Main()
    {
        // Вывод меню
        Console.WriteLine("Выберите:\n\n1. MD5\n2. SHA1\n3. SHA256");
        int choice = Convert.ToInt32(Console.ReadLine());

        // Ввод строки для хеширования
        Console.Write("Введите строку: ");
        string word = Console.ReadLine();

        // Получение хешировщика через фабрику
        HashManager manager = new HashManager();
        HashKit newHashAlgorithm = manager.GetHashAlgorithm(choice);

        // Вычисление хеша (используется унаследованный метод GetHashWord)
        string hash = newHashAlgorithm.GetHashWord(word);
        Console.WriteLine(hash);

        // Дополнительный вывод: печатаем сам объект
        // Благодаря полиморфизму вызывается переопределённый ToString()
        // Если бы не было переопределения, вывелось бы имя типа (HashKit или что-то подобное)
        Console.WriteLine(newHashAlgorithm);
    }
}