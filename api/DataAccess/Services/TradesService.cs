using System.Collections.Generic;
using System.Threading.Tasks;
using Marqueone.TimeAndMaterials.Api.Entities;
using Marqueone.TimeAndMaterials.Api.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Transform = Marqueone.TimeAndMaterials.Api.Models.Transforms;
using Marqueone.TimeAndMaterials.Api.Extentions;
using System;

namespace Marqueone.TimeAndMaterials.Api.DataAccess.Services
{
    public class TradeService
    {
        private TamContext _context { get; set; }

        private DbSet<Trade> Trades => _context.Trades;
        private DbSet<EmployeeTrade> EmployeeTrades => _context.EmployeeTrades;

        public TradeService(TamContext context)
        {
            _context = context;
        }

        internal async Task<IList<Transform.Trade>> GetTrades()
        {
            var trades = new List<Transform.Trade>();

            foreach(Trade trade in await Trades.ToListAsync())
            {
                trades.Add(trade.ToTrade());
            }

            return trades;
        }

        internal async Task<bool> Add(string name, decimal rate, bool isActive)
        {
            Trades.Add(new Trade
            { 
                Name = name, 
                PayRate = rate, 
                IsActive = isActive 
            });

            return await _context.SaveChangesAsync() >= 0;
        }

        internal async Task<bool> Update(int id, string name, decimal rate, bool isActive)
        {
            var trade = await Trades.SingleOrDefaultAsync(s => s.Id == id);

            if (trade != null)
            {
                trade.Name = name;
                trade.PayRate = rate;
                trade.IsActive = isActive;

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }

        internal async Task<bool> Delete(int id)
        {
            var trade = await Trades.SingleOrDefaultAsync(m => m.Id == id);
            if (trade != null)
            {
                Trades.Remove(trade);

                return await _context.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}