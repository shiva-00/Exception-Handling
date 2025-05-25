using System;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message, Exception? Ex = null) : base(message, Ex){}
}
public class BankAccount
{
    public string? AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string Acc_Num, decimal balance)
    {
        AccountNumber = Acc_Num;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
      if (amount <= 0)
        {
            throw new InsufficientFundsException($"Cannot deposit {amount}. Deposit amount must be greater than 0.");
        }
        Balance += amount;
        Console.WriteLine($"✅ Deposit successful! Total Balance: ₹{Balance}");
    }
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientFundsException($"❌ Withdrawal failed! ₹{amount} exceeds available balance of ₹{Balance}.");
        }
        Balance -= amount;
        Console.WriteLine($"✅ Withdrawal successful! Current Balance: ₹{Balance}");
    }
}



class Program
{
    static void Main()
    {
        try
        {
            BankAccount bankaccount = new BankAccount("123456123889", 1000);
            bankaccount.Deposit(500);
            Console.WriteLine("Deposit Completed");
            bankaccount.Withdraw(700);
            Console.WriteLine("withdraw Completed");

            bankaccount.Withdraw(2000);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction Ended");
        }
    }
}