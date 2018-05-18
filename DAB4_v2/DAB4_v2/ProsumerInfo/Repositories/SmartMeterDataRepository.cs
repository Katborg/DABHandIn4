using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models.Persistence;
using DAB4.Models;

namespace ProsumerInfo.Repositories
{
    class SmartMeterDataRepository:Repository<SmartMeterData>, ISmartMeterDataRepository
    {
        public SmartMeterDataRepository(DbContext context) : base(context)
        {

        }

        public ProsumerInfoContext ProsumerInfoContext
        {
            get { return Context as ProsumerInfoContext; }
        }
    }
}
