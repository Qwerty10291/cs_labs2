namespace cs_labs.lab8;

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
        return $"ACCT-{lastAccountNumber:D6}";
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

    // Метод для перевода денег с одного счета на другой
    public static void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
    {
        if (fromAccount != null && toAccount != null && amount > 0 && amount <= fromAccount.balance)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
            Console.WriteLine($"Переведено {amount:C} со счета {fromAccount.accountNumber} на счет {toAccount.accountNumber}");
        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Некорректные данные или недостаточно средств.");
        }
    }
}
