using System;

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Crypto Wallet] Sent {transaction.Amount:C} for {transaction.Category}");
    }
}
