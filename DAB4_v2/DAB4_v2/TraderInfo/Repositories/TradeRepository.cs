using System.Data.Entity;
using DAB4.Models;
using DAB4.Models.Persistence;

namespace TraderInfo.Repositories
{
    public class TradeRepository : Repository<Trade>, ITradeRepository
    {
        public TradeRepository(DbContext context) : base(context)
        {
        }

        public TraderInfoContext TraderInfoContext
        {
            get { return Context as TraderInfoContext; }
        }
    }
}
