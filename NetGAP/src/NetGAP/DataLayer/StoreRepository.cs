using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;

namespace NetGAP.DataLayer
{
    public class StoreRepository : IStoreRepository
    {
        private readonly TiendaContext DbContext;
        private Boolean Disposed;

        public StoreRepository(TiendaContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }
        public IEnumerable<Stores> GetStores()
        {
            var query = DbContext.Set<Stores>().AsQueryable();

            return query;
        }

        public Stores GetStore(long id)
        {
            return DbContext.Set<Stores>().FirstOrDefault(item => item.Id == id);
        }

        public Stores AddStore(Stores entity)
        {
            DbContext.Set<Stores>().Add(entity);

            DbContext.SaveChanges();

            return entity;
        }

        public Stores UpdateStore(long id, Stores changes)
        {
            var entity = GetStore(id);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Address = changes.Address;

                DbContext.SaveChanges();
            }

            return entity;
        }

        public Stores DeleteStore(long id)
        {
            var entity = GetStore(id);

            if (entity != null)
            {
                DbContext.Set<Stores>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }
    }
}
