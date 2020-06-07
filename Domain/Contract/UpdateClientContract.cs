using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract
{
    public class UpdateClientContract
    {
        public string ID { get; set; }

        public string TIN { get; set; }

        public string Name { get; set; }

        public string ClientType { get; set; }

        public string CreateDate { get; set; }

    }
}
