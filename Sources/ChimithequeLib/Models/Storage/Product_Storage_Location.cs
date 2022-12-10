using ChimithequeLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChimithequeLib.Models.Storage
{

    public class Product_Storage_LocationViewModel : IEquatable<Product_Storage_LocationViewModel>
    {   

        public Storage_Id Storage_id { set; get; }

        // QrCode
        public string Storage_qrcode { set; get; }

        public Boolean Valid { set; get; }

        // Produit
        public Product Product { set; get; }

        // Entrepôt
        public StoreLocation Storelocation { get;set; }

        // Stockage (Quantité)
        public Storage_quantity Storage_quantity { get;set; }

        // Unité
        public Unit_quantity Unit_quantity { get;set; }

        // Date de création
        public string Storage_creationdate { set; get; }

        // Date de modification
        public string Storage_modificationdate { set; get; }

        // Date d'ouverture
        public StorageOpeningDate Storage_openingdate { set; get; }

        // Date d'expiration
        public StorageExpirationDate Storage_expirationdate { set; get; }


        public override bool Equals(Object other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;
            return Equals((Product_Storage_LocationViewModel)other);
        }

        public bool Equals(Product_Storage_LocationViewModel other) { return Product.Equals(other.Product); }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Product Name : ");
            sb.Append($"{Product.Name.Name_label    }");
            
            sb.Append("\n Qantite : ");
            sb.Append($"{Storage_quantity.Float64} {Unit_quantity.Unit_label.String} \n");
            
            sb.Append("\n Entrepot : ");
            sb.Append($"{Storelocation.StoreLocation_name.String} \n");

            



            return sb.ToString();
        }
    }
}
