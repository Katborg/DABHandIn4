using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models;
using DAB4.Models.Persistence;
using ProsumerInfo.Repositories;
using System.Data.Entity;

namespace ProsumerInfo.Repositories
{
    class ExpectedDataRepository:Repository<ExpectedData>, IExpectedDataRepository
    {
        public ExpectedDataRepository(DbContext context) : base(context)
        {

        }

        public ProsumerInfoContext ProsumerInfoContext
        {
            get { return Context as ProsumerInfoContext; }
        }
    }
}
