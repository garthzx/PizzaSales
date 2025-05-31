using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces {
    public interface IOrderService {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<PeakTime>> GetPeakTimeDataAsync();
        Task<IEnumerable<BestSeller>> GetTop10BestSellersAsync();
    }
}
