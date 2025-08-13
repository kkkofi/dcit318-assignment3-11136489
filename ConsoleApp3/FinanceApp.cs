using System;
using System.Collections.Generic;

public class FinanceApp
{
    private List<Transaction> _transactions = new List<Transaction>();

    public void Run()
    {
        // 1. Create a SavingsAccount
        var account = new SavingsAccount("ACC123", 1000m);

        // 2. Create sample transactions
        var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
        var t2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
        var t3 = new Transaction(3, DateTime.Now, 50m, "Entertainment");

        // 3. Process transactions
        var mobileMoneyProcessor = new MobileMoneyProcessor();
        var bankTransferProcessor = new BankTransferProcessor();
        var cryptoWalletProcessor = new CryptoWalletProcessor();

        mobileMoneyProcessor.Process(t1);
        bankTransferProcessor.Process(t2);
        cryptoWalletProcessor.Process(t3);

        // 4. Apply to account
        account.ApplyTransaction(t1);
        account.ApplyTransaction(t2);
        account.ApplyTransaction(t3);

        // 5. Store transactions
        _transactions.Add(t1);
        _transactions.Add(t2);
        _transactions.Add(t3);
    }
}
