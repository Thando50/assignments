using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace Assignment_6
{ 
    public partial class MainPage : ContentPage
    {
        Bank fnb;
        Customer NewCustomer;
        BankAccount account;

        public MainPage()
        {
            InitializeComponent();
            fnb = new Bank("First National Bank", 4324, "steve becham road");
            NewCustomer = new Customer("57773880807", "7750 fikizolo street", "Nyanga East", "Thando");
            fnb.AddCustomer(NewCustomer);
            account = NewCustomer.ApplyForBankAccount();

        }
        private async void ButtonToDeposit_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(amountDeposit.Text.ToString());
            string reason = reasonDeposit.Text.ToString();
            account.DepositMoney(amount, DateTime.Now, reason);
            await DisplayAlert("Information", $"You have deposited R{amount}", "OK");
        }

        private async void ButtonToWithdraw_Clicked(object sender, EventArgs e)
        {
            decimal amount = Decimal.Parse(amountDeposit.Text.ToString());
            string reason = reasonWithdraw.Text.ToString();
            account.WithdrawMoney(amount, DateTime.Now, reason);
            await DisplayAlert("Information", $"You have Withdrawn R{amount}", "OK");
        }
        private  void ButtonForHistory_Clicked(object sender ,EventArgs e)
        {
            string history = account.GetTransactionHistory();
            TransactionHistory.Text = history;
        }

       
    }
}
