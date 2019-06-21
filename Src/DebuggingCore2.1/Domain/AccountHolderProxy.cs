using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AccountHolderProxy
    {
        private readonly AccountHolder accountHolder;

        public AccountHolderProxy(AccountHolder accountHolder)
        {
            this.accountHolder = accountHolder;
        }
        public string Descriptor => $"{this.accountHolder.Name} {this.accountHolder.Address.Road}";
    }
}
