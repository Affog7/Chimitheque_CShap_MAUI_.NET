using System;
using ChimithequeLib.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChimithequeLib.ViewModel.Products
{
	public class Product_SymbolVM : ObservableObject
	{

            private Product_Symbol model;

           

            public Product_SymbolVM(Product_Symbol m)
		    {
              model = m;
		    }

        public int Symbol_id { get => model.Symbol_id; }
        public string Symbol_label { get => model.Symbol_label; }
        public string Symbol_image { get => model.Symbol_image; }
    }
}

