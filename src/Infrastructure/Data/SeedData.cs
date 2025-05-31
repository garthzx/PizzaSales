using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data {
    public class SeedData {
        public static void Initialize(PizzaSalesDbContext context, string csvPath) {
            // order matters here
            AddOrders(context, csvPath);
            AddPizzaTypes(context, csvPath);
            AddPizzas(context, csvPath);
            AddOrderDetails(context, csvPath);
        }

        public static void AddOrders(PizzaSalesDbContext context, string csvPath) {
            context.Database.OpenConnection();
            try {
                if (context.Orders.Any()) return; // Avoid duplicate seed
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Orders ON");

                var orders = CsvImporter.ImportOrdersFromCsv(csvPath + "\\SeedData\\orders.csv");
                context.Orders.AddRange(orders);

                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Orders OFF");
            }
            catch (Exception) {
                throw;
            }
            finally {
                context.Database.CloseConnection();
            }
        }

        public static void AddOrderDetails(PizzaSalesDbContext context, string csvPath) {
            context.Database.OpenConnection();
            try {
                if (context.OrderDetails.Any()) return; // Avoid duplicate seed
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OrderDetails ON");

                var orderDetails = CsvImporter.ImportOrderDetailsFromCsv(csvPath + "\\SeedData\\order_details.csv");
                context.OrderDetails.AddRange(orderDetails);

                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT OrderDetails OFF");
            }
            catch (Exception) {
                throw;
            }
            finally {
                context.Database.CloseConnection();
            }
        }

        public static void AddPizzaTypes(PizzaSalesDbContext context, string csvPath) {
            context.Database.OpenConnection();
            try {
                if (context.PizzaTypes.Any()) return; // Avoid duplicate seed

                var pizzaTypes = CsvImporter.ImportPizzaTypesFromCsv(csvPath + "\\SeedData\\pizza_types.csv");
                context.PizzaTypes.AddRange(pizzaTypes);

                context.SaveChanges();

            }
            catch (Exception) {
                throw;
            }
            finally {
                context.Database.CloseConnection();
            }
        }

        public static void AddPizzas(PizzaSalesDbContext context, string csvPath) {
            context.Database.OpenConnection();
            try {
                if (context.Pizzas.Any()) return; // Avoid duplicate

                var pizzas = CsvImporter.ImportPizzasFromCsv(csvPath + "\\SeedData\\pizzas.csv");
                context.Pizzas.AddRange(pizzas);

                context.SaveChanges();
            }
            catch (Exception) {
                throw;
            }
            finally {
                context.Database.CloseConnection();
            }
        }
    }
}
