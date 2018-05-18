using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerInfo.Repositories;

namespace ProsumerInfo
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ProsumerInfoContext _context;

        public UnitOfWork(ProsumerInfoContext context)
        {
            _context = context;
            Addresses = new AddressRepository(_context);
            ExpectedDatas = new ExpectedDataRepository(_context);
            SmartMeterDatas = new SmartMeterDataRepository(_context);
            Prosumers = new ProsumerRepository(_context);

        }
        public IAddressRepository Addresses { get; }
        public IExpectedDataRepository ExpectedDatas { get; }
        public ISmartMeterDataRepository SmartMeterDatas { get; }
        public IProsumerRepository Prosumers { get; }

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
