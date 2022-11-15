namespace ChimithequeLib;

/// <summary>
/// Classe de service pour les produits
/// </summary>
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
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                return await GetAsync("products");
            }
            else
                return fail;
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
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                return await GetAsync("products/" + id);
            }
            else
                return fail;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
