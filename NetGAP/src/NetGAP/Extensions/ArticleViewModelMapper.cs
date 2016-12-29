using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;
using NetGAP.ViewModels;

namespace NetGAP.Extensions
{
    public static class ArticleViewModelMapper
    {
            public static ArticleViewModel ToViewModel(this Articles entity)
        {
            return entity == null ? null : new ArticleViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                TotalInShelf = entity.TotalInShelf,
                TotalInVault = entity.TotalInVault,
                Store = entity.Store == null ? null : entity.Store.Name,
                StoreId = entity.StoreId
            };
        }

        public static Articles ToEntity(this ArticleViewModel viewModel)
        {
            return viewModel == null ? null : new Articles
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                TotalInShelf = viewModel.TotalInShelf,
                TotalInVault = viewModel.TotalInVault,
                StoreId = viewModel.StoreId
            };
        }
    }
}
