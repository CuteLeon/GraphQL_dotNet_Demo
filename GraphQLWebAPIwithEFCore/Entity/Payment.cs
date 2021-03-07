using System;

namespace GraphQLWebAPIwithEFCore.Entity
{
    public class Payment
    {
        public int ID { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        public bool HasPaid { get; set; }

        public int PropertyID { get; set; }
    }
}
