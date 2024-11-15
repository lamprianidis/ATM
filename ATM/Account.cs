using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Account
    {
        private string _username;
        private string _pin;
        private int _balance;

        public Account(string username, string pin)
        {
            _username = username;
            _pin = pin;
            _balance = 0;
        }

        public string GetUsername()
            { return _username; }
        public string GetPin()
        {
            return _pin;
        }

        public int GetBalance()
        {
            return _balance;
        }

        public void Deposit(int ammount)
        {
            _balance += ammount;
        }

        public bool Withdraw(int ammount)
        {
            if (_balance >= ammount)
            {
                _balance -= ammount;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
