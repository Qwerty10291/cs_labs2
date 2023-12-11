namespace cs_labs.lab7;

using System;

public enum AccountType
{
    Savings,
    Checking,
    Credit
}

public class BankAccount
{
    private static int lastAccountNumber = 1000; // Последний использованный номер счета
    private string accountNumber; // Номер счета
    private decimal balance; // Баланс
    private AccountType accountType; // Тип банковского счета

    // Конструктор класса
    public BankAccount(decimal balance, AccountType accountType)
    {
        this.accountNumber = GenerateAccountNumber();
        this.balance = balance;
        this.accountType = accountType;
    }

    // Метод для генерации уникального номера счета
    private static string GenerateAccountNumber()
    {
        lastAccountNumber++;
        return $"ACCT-{lastAccountNumber}";
    }

    // Метод для получения информации о счете
    public void PrintAccountInfo()
    {
        Console.WriteLine("Информация о банковском счете:");
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Баланс: {balance:C}");
        Console.WriteLine($"Тип счета: {accountType}");
    }

    // Метод для снятия средств со счета
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Со счета снято: {amount:C}. Новый баланс: {balance:C}");
        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Недостаточно средств или введена некорректная сумма.");
        }
    }

    // Метод для внесения средств на счет
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"На счет поступило: {amount:C}. Новый баланс: {balance:C}");
        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Введена некорректная сумма.");
        }
    }
}
