using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Shared.EntityMaps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared {
    public static class CsvImporter {
        public static IEnumerable<Order> ImportOrdersFromCsv(string filePath) {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {
                HeaderValidated = null,
                MissingFieldFound = null,
            });

            csv.Context.RegisterClassMap<OrderMap>();

            return csv.GetRecords<Order>().ToList();
        }

        public static IEnumerable<PizzaType> ImportPizzaTypesFromCsv(string filePath) {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {
                HeaderValidated = null,
                MissingFieldFound = null,
            });
            csv.Context.RegisterClassMap<PizzaTypeMap>();

            return csv.GetRecords<PizzaType>().ToList();
        }

        public static IEnumerable<Pizza> ImportPizzasFromCsv(string filePath) {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {
                HeaderValidated = null,
                MissingFieldFound = null,
            });
            csv.Context.RegisterClassMap<PizzaMap>();

            return csv.GetRecords<Pizza>().ToList();
        }

        public static IEnumerable<OrderDetails> ImportOrderDetailsFromCsv(string filePath) {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {
                HeaderValidated = null,
                MissingFieldFound = null,
            });
            csv.Context.RegisterClassMap<OrderDetailsMap>();

            return csv.GetRecords<OrderDetails>().ToList();
        }
    }
}
