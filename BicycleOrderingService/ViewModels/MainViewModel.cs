using System.Collections.Generic;
using System.Linq;
using BicycleOrderingService.Data;
using BicycleOrderingService.Models;
using BicycleOrderingService.ViewModels.Base;

namespace BicycleOrderingService.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel(){}

        public MainViewModel(UserModel activeUser)
        {
            _productList = DataManager.Product.GetAll().ToList();
        }

        #region Properties

        #region Collections

        public List<ProductModel> ProductList
        {
            get => _productList;
            set => _productList = value;
        }

        private List<ProductModel> _productList;

        #endregion

        #region Selected Items

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set => _selectedProduct = value;
        }

        private ProductModel _selectedProduct;

        #endregion

        #endregion
    }
}
