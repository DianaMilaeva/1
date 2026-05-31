class BankAccount
{
    private decimal balance;
    public void Deposit(decimal amount)
    {
        if (amount > 0) balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance) balance -= amount;
    }
    public decimal GetBalance()
    {
        return _balance;
    }
}
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.Deposit(1000);
        account.Withdraw(100);
        Console.WriteLine(account.GetBalance());
    }
}
