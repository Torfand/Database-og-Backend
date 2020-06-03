using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLetter.Core._3_Domain_Model
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity(Guid id)
        {
            Id = Guid.NewGuid();
        }
    }
}
