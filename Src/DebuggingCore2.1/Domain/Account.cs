
using System.Diagnostics;
using System.Text;

namespace Domain
{
    public class Account
    {
        public int Number { get; set; }
        public int Balance { get; set; }
        public AccountHolder Holder { get; set; }

        public void  ChangeHolder(AccountHolder newHolder)
        {
            newHolder.Name = "Jack Hughes";
        }

        public void IncreaseBalance(int amount)
        {
            Balance += amount;
        }

        public void DecreaseBalance(int amount)
        {
            Balance -= amount;
        }

    }
}
