using System;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel.Products;

namespace ChimithequeLib.ViewModel
{
	public class StoragesViewModel
	{

		private Storages model;
        private List<Product_Storage_LocationViewModel> rows = new List<Product_Storage_LocationViewModel>();
        public IEnumerable<Product_Storage_LocationViewModel> Rows
        {

            get
            {
                return rows.AsReadOnly();
            }


        }
        public StoragesViewModel()
        {
        }

        public StoragesViewModel(Storages m)
		{
			model = m;
			foreach(var e in m.Rows)
			{
				rows.Add(new Product_Storage_LocationViewModel(new Product_Storage_Location
				{
					Product = e.Product,
					Storage_creationdate = e.Storage_creationdate,
					Storage_expirationdate = e.Storage_expirationdate,
					Storage_id = e.Storage_id,
					Storage_modificationdate = e.Storage_modificationdate,
					Storage_openingdate = e.Storage_openingdate,
					Storage_qrcode = e.Storage_qrcode,
					Storage_quantity = e.Storage_quantity,
					Storelocation = e.Storelocation,
					Unit_quantity = e.Unit_quantity,
					Valid = e.Valid,
				})) ;

            }
		}
	}
}

