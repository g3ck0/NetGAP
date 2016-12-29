using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;

namespace NetGAP.DataLayer
{
    public interface IArticleRepository : IDisposable
    {
        IEnumerable<Articles> GetArticlesByStore(long Id);
        Articles GetArticle(long id);

        Articles AddArticle(Articles entity);

        Articles UpdateArticle(long id, Articles changes);

        Articles DeleteArticle(long id);
    }
}
