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
    public class PizzaService : IPizzaService {

        private readonly PizzaSalesDbContext _context;

        public PizzaService(PizzaSalesDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Pizza>> GetAllPizzasAsync() {
            return await _context.Pizzas.Include(p => p.PizzaType).ToListAsync();
        }

        public async Task<Pizza> GetPizzaByIdAsync(string id) {
            return await _context.Pizzas.Include(p => p.PizzaType).FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
