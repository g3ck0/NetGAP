using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;

namespace NetGAP.DataLayer
{
    public interface IStoreRepository : IDisposable
    {
        IEnumerable<Stores> GetStores();

        Stores GetStore(long id);

        Stores AddStore(Stores entity);

        Stores UpdateStore(long id, Stores changes);

        Stores DeleteStore(long id);
    }
}
