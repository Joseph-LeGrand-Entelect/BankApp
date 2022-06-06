using Bank.Domain;
using Bank.Domain.Service;

namespace Bank.Admin
{
    public partial class ATM : Form
    {
        string customerName = "Mr. Bryan Walton";
        int balance = 78620;
        BankService service = new BankService();
        double interestRate;
        double transactionFee;

        public ATM()
        {
            InitializeComponent();
            interestRate = service.GetInterestRate().Result;
            transactionFee = service.GetTransactionFee().Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var customerName = "Mr. Bryan Walton";
            //var balance = 78620;
            //var service = new BankService();
            //var interestRate = service.GetInterestRate().Result;
            //var transactionFee = service.GetTransactionFee().Result;

            //Acounts
            var account = new Account(customerName, balance);
            var checkingAccount = new CheckingAccount(customerName, balance, transactionFee);
            var savingsAccount = new SavingsAccount(customerName, balance, interestRate);

            Console.WriteLine("Interest earned: ${0}", savingsAccount.CalculateInterestEarned());

            account.Deposit(5.77);
            account.Withdraw(11.22);
            Console.WriteLine("Current balance is ${0}", account.Balance);
            Console.WriteLine("");

            // Test withdraw amount exceeds balance
            double excessWithdraw = 1000;
            account.Withdraw(excessWithdraw);
            Console.WriteLine("Try to withdraw {0:C} from account. Unchanged balance is {1:C}",
                excessWithdraw, account.Balance);
            Console.WriteLine("");
        }
    }
}