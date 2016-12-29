using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetGAP.DataLayer
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly TiendaContext DbContext;
        private Boolean Disposed;

        public ArticleRepository(TiendaContext dbContext)
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
        public IEnumerable<Articles> GetArticlesByStore(long Id)
        {

            return DbContext.Set<Articles>().Include(item => item.Store).Where(data => data.StoreId == Id).ToList();

        }
        public Articles GetArticle(long id)
        {
            return DbContext.Set<Articles>().Include(item => item.Store).FirstOrDefault(item => item.Id == id);
        }

        public Articles AddArticle(Articles entity)
        {
            DbContext.Set<Articles>().Add(entity);

            DbContext.SaveChanges();

            return entity;

        }

        public Articles UpdateArticle(long id, Articles changes)
        {
            var entity = GetArticle(id);
            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;
                entity.Price = changes.Price;
                entity.TotalInShelf = changes.TotalInShelf;
                entity.TotalInVault = changes.TotalInVault;

                DbContext.SaveChanges();
            }

            return entity;
        }

        public Articles DeleteArticle(long id)
        {
            var entity = GetArticle(id);
            if (entity != null)
            {
                DbContext.Set<Articles>().Remove(entity);

                DbContext.SaveChanges();
            }

            return entity;
        }
    }
}
