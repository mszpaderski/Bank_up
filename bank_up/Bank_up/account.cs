using System;
 

namespace Bank_up
{
    public class account
    {
        public int acc_nr { get; set; }
        public string owner { get; set; }
        public string currency { get; set; }
        public double interest_type { get; set; }
        public double balance { get; set; }

        //Wypłata
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
            this.balance = Math.Round(this.balance - amount, 2);
        }
        //Koniec wypłaty

        // Wpłata
        public void deposit(double amount, string d_currency) // Polecenie wypłaty które sprawdza zgodność waluty i przelicza w przypadku innej waluty.
        {
            if (string.Equals(this.currency, d_currency)) // Jeśli ta sama waluta, zrób przelew
            {
                do_deposit(amount);
            }
            else // Jeśli inna waluta to przelicz na poprawną
            {
                do_deposit(recalculate(amount, d_currency));
            }
        }

        public void do_deposit(double amount) // Wpłata po sprawdzeniu i przeliczeniu waluty
        {
            this.balance = Math.Round(this.balance + amount, 2);
        }
        // Koniec wpłaty


        // Funkcja przeliczająca walutę, bierze kwotę, dzieli przez walutę przelewu i mnoży przez walutę konta. Z założenia PLN jest równy przelicznikowi 1.
        public double recalculate(double amount, string o_currency)
        {
            MainWindow mw = new MainWindow();
            return Math.Round(amount * mw.currency_list.Find(x => x.name == o_currency).value / mw.currency_list.Find(x => x.name == this.currency).value, 2);
        }



        // Funkcja doliczająca odsetki albo odejmująca oprocentowanie.
        public void bring_interests()
        {
            this.balance = Math.Round(this.balance * (1 + this.interest_type), 2);
        }

    }
}
