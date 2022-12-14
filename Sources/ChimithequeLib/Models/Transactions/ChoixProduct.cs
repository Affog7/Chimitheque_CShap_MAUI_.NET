using System;
namespace ChimithequeLib.Models.Transactions;

public class ChoixProduct :IEquatable<ChoixProduct>
{
	private int idProduit;
	private double quantity;

	public ChoixProduct(int id, double quantity)
	{
		this.idProduit = id;
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
        return idProduit.Equals(obj.idProduit);
    }
}

