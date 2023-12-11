namespace cs_labs.lab14;

using System;
using System.Collections;
using System.IO;
using System.Diagnostics;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class OrgInfoAttribute : Attribute
{
    public string DeveloperName { get; }
    public string OrgName { get; }

    public OrgInfoAttribute(string developerName, string orgName)
    {
        DeveloperName = developerName;
        OrgName = orgName;
    }

}

public enum AccountType
{
    Savings,
    Checking,
    Credit
}

[OrgInfo("Andrey Tazetdinov", "Company")]
public class BankTransaction
{
    public readonly DateTime TransactionDate;
    public readonly decimal Amount;

    public BankTransaction(decimal amount)
    {
        TransactionDate = DateTime.Now;
        Amount = amount;
    }
}

public class BankAccount : IDisposable
{
    private static int lastAccountNumber = 1000;
    private readonly string accountNumber;
    public string AccountNumber {
        get => accountNumber;
    }
    private decimal balance;

    public decimal Balance {
        get => balance;
    }
    private readonly AccountType accountType;
    private readonly Queue transactions;

    public BankAccount(decimal initialBalance, AccountType type)
    {
        accountNumber = GenerateAccountNumber();
        balance = initialBalance;
        accountType = type;
        transactions = new Queue();
    }

    private static string GenerateAccountNumber()
    {
        lastAccountNumber++;
        return $"ACCT-{lastAccountNumber:D6}";
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine("Информация о банковском счете:");
        Console.WriteLine($"Номер счета: {accountNumber}");
        Console.WriteLine($"Баланс: {balance:C}");
        Console.WriteLine($"Тип счета: {accountType}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            RecordTransaction(-amount);
            Console.WriteLine($"Со счета снято: {amount:C}. Новый баланс: {balance:C}");
        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Недостаточно средств или введена некорректная сумма.");
        }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            RecordTransaction(amount);
            Console.WriteLine($"На счет поступило: {amount:C}. Новый баланс: {balance:C}");
        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Введена некорректная сумма.");
        }
    }

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

    private void RecordTransaction(decimal amount)
    {
        BankTransaction transaction = new BankTransaction(amount);
        transactions.Enqueue(transaction);
    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine($"История транзакций для счета {accountNumber}:");

        foreach (BankTransaction transaction in transactions)
        {
            Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount:C}");
        }
    }

    public void Dispose()
    {
        WriteTransactionsToFile();
        GC.SuppressFinalize(this);
    }

    private void WriteTransactionsToFile()
    {
        string fileName = $"TransactionHistory_{accountNumber}.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"История транзакций для счета {accountNumber}:");

                foreach (BankTransaction transaction in transactions)
                {
                    writer.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Amount:C}");
                }

                Console.WriteLine($"История транзакций записана в файл: {fileName}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
        }
    }

    public static bool operator==(BankAccount b1, BankAccount b2) {
        return b1.accountNumber == b2.accountNumber;
    }
    
    public static bool operator!=(BankAccount b1, BankAccount b2) {
        return b1.accountNumber != b2.accountNumber;
    }

    public override int GetHashCode() {
        return HashCode.Combine(accountNumber);
    }

    public override string ToString()
    {
        return $"{accountType}-{accountNumber}: {balance}";
    }

    public BankTransaction this[int index] {
        get {
            return transactions.Cast<BankTransaction>().Skip(index).First();
        }
    }

    [Conditional("DEBUG_ACCOUNT")]
    public void DumpToScreen()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}
