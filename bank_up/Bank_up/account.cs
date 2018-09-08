using System;
 

namespace Bank_up
{
    public class account
    {
        public string owner;
        public string currency;
        public double interest_type;
        public double balance;

        public account(string owner, string currency, double interest_type, double balance)
        {
            this.owner = owner;
            this.currency = currency;
            this.interest_type = interest_type;
            this.balance = balance;
        }


        public double get_balance
        {
            get { return balance; }
        }

        public void withdraw(double amount, string w_currency) // Polecenie wypłaty które sprawdza zgodność waluty i przelicza w przypadku innej waluty.
        {
            if (string.Equals(this.currency, w_currency)) // Jeśli ta sama waluta, zrób przelew
            {
                do_withdraw(amount);
            }
            else // Jeśli inna waluta to przelicz na poprawną
            {
                do_withdraw(recalculate(amount, w_currency));
            }
        }

        public void do_withdraw(double amount) // Wypłata po sprawdzeniu i przeliczeniu waluty
        {
            this.balance -= amount;
        }

        public void deposit(double amount, string d_currency) // Polecenie wypłaty które sprawdza zgodność waluty i przelicza w przypadku innej waluty.
        {
            if (string.Equals(this.currency, d_currency)) // Jeśli ta sama waluta, zrób przelew
            {
                do_withdraw(amount);
            }
            else // Jeśli inna waluta to przelicz na poprawną
            {
                do_withdraw(recalculate(amount, d_currency));
            }
        }

        public void do_deposit(double amount) // Wpłata po sprawdzeniu i przeliczeniu waluty
        {
            this.balance += amount;
        }



        public double recalculate(double amount, string w_currency)
        {
            return (amount / currency_table.currency_value(w_currency)) * currency_table.currency_value(this.currency);
        }




        public void bring_interests() // Funkcja doliczająca odsetki albo odejmująca oprocentowanie.
        {

        }

        public override string ToString()
        {
            return owner + "'s account holds " +
                  +balance + " kroner";


        }
    }
}
