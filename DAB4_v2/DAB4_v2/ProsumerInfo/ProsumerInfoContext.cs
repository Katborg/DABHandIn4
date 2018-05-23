using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models;

namespace ProsumerInfo
{
    public class ProsumerInfoContext:DbContext
    {
        public ProsumerInfoContext():base("name=production_I4DABGr13")
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<SmartMeterData> SmartMeterDatas { get; set; }
        public DbSet<ExpectedData> ExpectedDatas { get; set; }
        public DbSet<Prosumer> Prosumers { get; set; }
    }
}
