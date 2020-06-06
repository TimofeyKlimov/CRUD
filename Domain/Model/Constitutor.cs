using System;
using System.Data;

namespace Domain.Model
{
    public class Constitutor
    {
        public Guid Id { get; set; }
        public virtual long TIN { get; set; }

        public virtual string FullName { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime UpdateDate { get; set; }

        public virtual Client Client { get; set; }
    }
}