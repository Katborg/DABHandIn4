﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models;
using DAB4.Models.Persistence;

namespace ProsumerInfo.Repositories
{
    class AddressRepository: Repository<Address>, IAddressRepository
    {
        public AddressRepository(DbContext context) : base(context)
        {
        }

        public ProsumerInfoContext ProsumerInfoContext
        {
            get { return Context as ProsumerInfoContext; }
        }
    }
}
