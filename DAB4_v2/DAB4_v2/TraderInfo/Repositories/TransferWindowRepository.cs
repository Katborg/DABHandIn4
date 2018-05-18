using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models;
using DAB4.Models.Persistence;

namespace TraderInfo.Repositories
{
    class TransferWindowRepository : Repository<TransferWindow>, ITransferWindowRepository
    {
        public TransferWindowRepository(DbContext context) : base(context)
        {
        }

        public TraderInfoContext ContactBookContext
        {
            get { return Context as TraderInfoContext; }
        }
    }
}
