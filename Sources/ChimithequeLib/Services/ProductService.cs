﻿namespace ChimithequeLib;

public class ProductService : Services
{
    /// <summary>
    /// Méthode pour obtenir tous les produits
    /// </summary>
    /// <returns></returns>
    public async Task<String?> GetProductsAsync()
    {
        try
        {
            return await GetAsync("products");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    /// <summary>
    /// Methode pour obtenir un produit en fonction de son id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<String?> GetProductByIdAsync(int id)
    {
        try
        {
            var value = await GetAsync("products/" + id);
            return value == null ? null : value.ToString();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
