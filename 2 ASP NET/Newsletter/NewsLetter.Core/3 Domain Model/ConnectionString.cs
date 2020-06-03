using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLetter.Core._3_Domain_Model
{
    public class ConnectionString
    {
        public string Value { get; }

        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
