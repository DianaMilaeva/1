class Student 
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("Иван", 5);
        Console.WriteLine($"Имя: {student.Name} Оценка: {student.Grade}");
    }
}
