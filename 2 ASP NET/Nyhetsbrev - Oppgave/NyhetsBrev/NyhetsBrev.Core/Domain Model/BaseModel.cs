using System;
using System.Collections.Generic;
using System.Text;

namespace NyhetsBrev.Core.Domain_Model
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public BaseModel()
        {
            Id = new Guid();
        }
    }
}



