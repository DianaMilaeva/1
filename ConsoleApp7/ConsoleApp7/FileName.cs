/*
 Hash1.cs - Реализация хеширования с передачей алгоритма через конструктор
 В данной версии используется один класс HashKit, который получает конкретный алгоритм через конструктор
 Принципы ООП:
 Инкапсуляция: детали преобразований скрыты внутри класса
 */

using System.Security.Cryptography;
using System.Text;

// Класс-обёртка для алгоритма хеширования
// Получает готовый алгоритм через конструктор
// Все вспомогательные методы защищены - это инкапсуляция
class HashKit(HashAlgorithm algo)
{
    // Защищённое свойство хранит экземпляр алгоритма
    // protected означает доступ только из этого класса и наследников
    // Это элемент инкапсуляции - внешний код не может напрямую изменить алгоритм
    protected HashAlgorithm Algo { get; set; } = algo;

    // Преобразует строку в массив байт в кодировке UTF-8
    // Защищённый метод - скрыт от внешнего использования
    protected byte[] getBytes(string word) => Encoding.UTF8.GetBytes(word);

    // Преобразует массив байт в строку Base64 для удобного отображения
    // Base64 выбран потому, что хеш - это бинарные данные
    protected string getString(byte[] bytes) => Convert.ToBase64String(bytes);

    // Вычисляет хеш с помощью текущего алгоритма
    protected byte[] getHash(byte[] bytes) => Algo.ComputeHash(bytes);

    // Единственный публичный метод - точка входа для внешнего кода
    // Инкапсулирует всю цепочку преобразований: строка -> байты -> хеш -> Base64
    public string GetHashWord(string word) => getString(getHash(getBytes(word)));
}

// Фабричный класс - создаёт объекты HashKit с нужным алгоритмом
// Реализует паттерн "Фабричный метод"
class HashManager
{
    // Возвращает настроенный экземпляр HashKit в зависимости от выбора пользователя
    // choice: 1 - MD5, 2 - SHA1, 3 - SHA256
    public HashKit GetHashAlgorithm(int choice)
    {
        // Используем switch expression для лаконичности
        return choice switch
        {
            1 => new HashKit(MD5.Create()),      // Передаём фабрику MD5
            2 => new HashKit(SHA1.Create()),     // Передаём фабрику SHA1
            3 => new HashKit(SHA256.Create()),   // Передаём фабрику SHA256
            _ => throw new ArgumentException("Неверный выбор алгоритма")
        };
    }
}

// Главный класс приложения
class Program
{
    // Точка входа в программу
    static void Main()
    {
        // Этап 1: запрос выбора алгоритма у пользователя
        Console.WriteLine("Выберите:\n\n1. MD5\n2. SHA1\n3. SHA256");
        int choice = Convert.ToInt32(Console.ReadLine());

        // Этап 2: запрос исходной строки
        Console.Write("Введите строку: ");
        string word = Console.ReadLine();

        // Этап 3: создание фабрики и получение хешировщика
        HashManager manager = new HashManager();
        HashKit newHashAlgorithm = manager.GetHashAlgorithm(choice);

        // Этап 4: вычисление и вывод хеша
        string hash = newHashAlgorithm.GetHashWord(word);
        Console.WriteLine(hash);
    }
}