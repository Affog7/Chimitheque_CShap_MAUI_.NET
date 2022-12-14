using System;
namespace ChimithequeLib.Models.Transactions
{
	public class Transaction
	{
		private IList<ChoixProduct> panier;
		private DateTime date;

		public Transaction()
		{
			panier = new List<ChoixProduct>();
		}

		public void AddProduit(ChoixProduct p)
		{
			if (panier.Contains(p)) return;
			panier.Add(p);
		}

		public IEnumerable<ChoixProduct> GetChoixProduct()
		{
			return panier.AsEnumerable<ChoixProduct>();
		}
	}
}

