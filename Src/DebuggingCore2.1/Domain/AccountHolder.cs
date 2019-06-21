using System;
using System.Diagnostics;

namespace Domain
{
    [DebuggerDisplay("Name = {Name}")]
    public class AccountHolder
    {
        public string Name { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
        public Address Address { get; set; }
    }
}
