using System;
using System.Diagnostics;

namespace Domain
{
  
 
    public class AccountHolder
    {
      
        public string Name { get; set; }

    
        public Address Address { get; set; }

        public AccountHolder()
        {

        }
        public void ChangeRoad(string newRoad)
        {
            Address.Road = newRoad;
        }
    }
}
