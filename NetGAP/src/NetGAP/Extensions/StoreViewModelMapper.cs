using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetGAP.Models;
using NetGAP.ViewModels;

namespace NetGAP.Extensions
{
    public static class StoreViewModelMapper
    {
        public static StoreViewModel ToViewModel(this Stores entity)
        {
            return entity == null ? null : new StoreViewModel
            {
                id = entity.Id,
                name = entity.Name,
                address = entity.Address
            };
        }

        public static Stores ToEntity(this StoreViewModel viewModel)
        {
            return viewModel == null ? null : new Stores
            {
                Name = viewModel.name,
                Address= viewModel.address
            };
        }
    }
}
