using CsvHelper.Configuration;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityMaps {
    public sealed class OrderMap : ClassMap<Order> {
        public OrderMap() {
            Map(m => m.Id).Name("order_id");
            Map(m => m.OrderDate).Name("date").TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.OrderTime).Name("time").Convert(row => TimeSpan.Parse(row.Row.GetField("time")));
        }
    }
}
