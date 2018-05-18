using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderInfo.Repositories;

namespace TraderInfo
{
    public class TraderInfoUnitOfWork : ITraderInfoUnitOfWork
    {
        private readonly TraderInfoContext _context;

        public ITransferWindowRepository TransferWindows { get; }
        public ITradeRepository Trades { get; }

        public TraderInfoUnitOfWork(TraderInfoContext context)
        {
            _context = context;

            TransferWindows = new TransferWindowRepository(_context);
            Trades = new TradeRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
