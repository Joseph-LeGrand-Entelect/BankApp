using Bank.Domain.Account;
using Bank.Domain.Banking;
using Bank.Domain.CheckingAccount;
using Bank.Domain.SavingsAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Admin
{
    public partial class Dashboard : Form
    {

        string customerName = "Mr. Bryan Walton";
        double balance = 78620;
        double interestRate;
        double transactionFee;
        BankService service = new BankService();

        public Dashboard()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var customerName = "Mr. Bryan Walton";
            //var balance = 78620;
            //var service = new BankService();
            //var interestRate = service.GetInterestRate().Result;
            //var transactionFee = service.GetTransactionFee().Result;



            //interestRate = service.GetInterestRate().Result;
            //transactionFee = service.GetTransactionFee().Result;
            //Acounts
            var account = new Account(customerName, balance);
            //var checkingAccount = new CheckingAccount(customerName, balance, transactionFee);
            //var savingsAccount = new SavingsAccount(customerName, balance, interestRate);
            label2.Text = "Your balance is R" + account.Balance.ToString();
            //Console.WriteLine("Interest earned: ${0}", savingsAccount.CalculateInterestEarned());

            //account.Deposit(5.77);
            //account.Withdraw(11.22);
            //Console.WriteLine("Current balance is ${0}", account.Balance);
            //Console.WriteLine("");

            //// Test withdraw amount exceeds balance
            //double excessWithdraw = 1000;
            //account.Withdraw(excessWithdraw);
            //Console.WriteLine("Try to withdraw {0:C} from account. Unchanged balance is {1:C}",
            //    excessWithdraw, account.Balance);
            //Console.WriteLine("");
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                var account = new Account(customerName, balance);

                double excessWithdraw = double.Parse(textBox1.Text);
                account.Withdraw(excessWithdraw);
                balance = account.Balance;
                label2.Text = "Your balance is R" + account.Balance.ToString();
            }
            catch(Exception eo)
            {
                MessageBox.Show(eo.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var account = new Account(customerName, balance);

                double excessWithdraw = double.Parse(textBox2.Text);
                account.Deposit(excessWithdraw);
                balance = account.Balance;
                label2.Text = "Your balance is R" + account.Balance.ToString();
            }
            catch (Exception eo)
            {
                MessageBox.Show(eo.Message);
            }

        }
    }
}
