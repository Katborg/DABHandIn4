using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAB4.Models.Persistence;

namespace SmartGrid
{
    public interface ISmartGridRepository : IRepository<DAB4.Models.SmartGrid>
    {
        DAB4.Models.SmartGrid ReplaceSmartGridDocument(int id, DAB4.Models.SmartGrid grid);
    }
}
