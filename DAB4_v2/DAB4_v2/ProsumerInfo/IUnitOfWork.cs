using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerInfo.Repositories;

namespace ProsumerInfo
{
    interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        IExpectedDataRepository ExpectedDatas { get; }
        ISmartMeterDataRepository SmartMeterDatas { get; }
        int Complete();
    }
}
