/*
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
}
class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.Deposit(1000);
        account.Withdraw(100);
    }
}
*/