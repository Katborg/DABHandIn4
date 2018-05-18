using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraderInfo.Repositories;

namespace TraderInfo
{
    public interface ITraderInfoUnitOfWork : IDisposable
    {
        ITransferWindowRepository TransferWindows { get; }
        ITradeRepository Trades { get; }
        int Complete();
    }
}
