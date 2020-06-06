using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Client
    {
        public Guid Id { get; set; }
        public virtual long TIN { get; set; }

        public virtual string Name { get; set; }

        public virtual ClientType ClientType { get; set; }
        
        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime UpdateDate { get; set; }

        public virtual ICollection<Constitutor> Constitutors { get; set; }

    }
}
