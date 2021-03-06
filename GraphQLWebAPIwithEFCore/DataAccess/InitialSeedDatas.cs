using System;
using System.Collections.Generic;
using System.Linq;
using GraphQLWebAPIwithEFCore.Entity;

namespace GraphQLWebAPIwithEFCore.DataAccess
{
    public static class InitialSeedDatas
    {
        public static void Initial(this DatabaseContext dbContext)
        {
            if (dbContext.Properties.Any() || dbContext.Payments.Any()) return;

            dbContext.Properties.AddRange(
                new Property
                {
                    City = "Shanghai",
                    Owner = "Leon",
                    Value = 15_000_000,
                    Payments = new List<Payment>
                    {
                        new Payment{ Date=DateTime.Now, HasPaid=true, Value=5_000_000 },
                        new Payment{ Date=DateTime.Now, HasPaid=true, Value=10_000_000 }
                    }
                },
                new Property
                {
                    City = "Zhengzhou",
                    Owner = "Leon",
                    Value = 2_000_000,
                    Payments = new List<Payment>
                    {
                        new Payment{ Date=DateTime.Now, HasPaid=true, Value=500_000 },
                        new Payment{ Date=DateTime.Now, HasPaid=true, Value=1_500_000 }
                    }
                });
            dbContext.SaveChanges();
        }
    }
}
