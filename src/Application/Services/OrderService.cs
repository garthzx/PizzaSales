using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services {
    public class OrderService : IOrderService {
        private readonly PizzaSalesDbContext _context;

        public OrderService(PizzaSalesDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() {
            //return await _context.Orders.ToListAsync();
            return await _context
                            .Orders
                            .Include(o => o.OrderDetails)
                            .ThenInclude(od => od.Pizza)
                            .ThenInclude(p => p.PizzaType)
                            .Take(20)
                            .ToListAsync();
        }
        public async Task<IEnumerable<PeakTime>> GetPeakTimeDataAsync() {
            var ordersByHour = await _context
                .Orders
                .GroupBy(o => o.OrderTime.Hours)
                .Select(g => new PeakTime {
                    Hour = g.Key,
                    TotalSales = g.Count()
                })
                .OrderBy(x => x.Hour)
                .ToListAsync();

            return ordersByHour;
        }

        public async Task<IEnumerable<BestSeller>> GetTop10BestSellersAsync() {

            var top10BestSellers = await _context
                .OrderDetails
                .Include(od => od.Pizza)
                .ThenInclude(od => od.PizzaType)
                .GroupBy(od => od.Pizza.Id)
                .Select(g => new BestSeller {
                    PizzaId = g.Key,
                    SalesCount = g.Sum(od => od.Quantity)
                })
                .OrderByDescending(bs => bs.SalesCount)
                .Take(10)
                .ToListAsync();
            return top10BestSellers;
        }
    }
}
