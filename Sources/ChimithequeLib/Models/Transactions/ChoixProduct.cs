using System;
using ChimithequeLib.Models.Storage;

namespace ChimithequeLib.Models.Transactions;

public class ChoixProduct :IEquatable<ChoixProduct>
{
	private Product_Storage_Location produit;
	private double quantity;

	public ChoixProduct(Product_Storage_Location product_stored, double quantity)
	{
		this.produit = product_stored;
		this.quantity = quantity;
	}

	public ChoixProduct() { }

   

    public override bool Equals(Object other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Equals(other as ChoixProduct);
    }

    public bool Equals(ChoixProduct obj)
    {
        return produit.Equals(obj.produit);
    }
}

