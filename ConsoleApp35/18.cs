class Product
{
    private string _name;
    private decimal _price;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public Product(string name, decimal price = 0)
    {
        Name = name;
        _price = price;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Телефон");
        Product product2 = new Product("Телефон", 50000);
    }
}
