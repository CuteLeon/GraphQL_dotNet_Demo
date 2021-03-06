using System.Collections.Generic;

namespace GraphQLWebAPIwithEFCore.Entity
{
    public class Property
    {
        public int ID { get; set; }

        public decimal Value { get; set; }

        public string City { get; set; }

        public string Owner { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
