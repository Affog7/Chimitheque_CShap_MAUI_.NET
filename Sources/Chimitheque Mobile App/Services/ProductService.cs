using System.Diagnostics;

namespace Chimitheque_Mobile_App.Services;

internal class ProductService : Services
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
            return await GetAsync("products/" + id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
