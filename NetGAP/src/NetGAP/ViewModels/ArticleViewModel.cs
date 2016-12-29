using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGAP.ViewModels
{
    public class ArticleViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long TotalInShelf { get; set; }
        public long TotalInVault { get; set; }
        public string Store { get; set; }
                public long StoreId { get; set; }
    }
}
