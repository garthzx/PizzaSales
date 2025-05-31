using CsvHelper.Configuration;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EntityMaps {
    public class PizzaMap : ClassMap<Pizza> {
        
        public PizzaMap() {
            Map(m => m.Id).Name("pizza_id");
            Map(m => m.PizzaTypeId).Name("pizza_type_id");
            Map(m => m.Size).Name("size");
            Map(m => m.Price).Name("price");
        }
    }
}
