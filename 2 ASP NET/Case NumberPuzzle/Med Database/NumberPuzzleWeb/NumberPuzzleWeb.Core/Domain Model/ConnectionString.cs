using System;
using System.Collections.Generic;
using System.Text;

namespace NumberPuzzleWeb.Core.Domain_Model
{
  public  class ConnectionString
    {
        public string Value { get; }

        public ConnectionString(string value)
        {
            Value = value;
        }
    }
}
