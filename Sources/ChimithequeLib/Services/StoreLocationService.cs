namespace ChimithequeLib;

/// <summary>
/// Classe de service pour les emplacements de stockage
/// </summary>
public class StoreLocationService:Services
{
    /// <summary>
    /// Méthode pour obtenir tous les lieux de stockage
    /// </summary>
    /// <returns></returns>
    public async Task<String?> GetStoreLocationAsync()
    {
        try
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                return await GetAsync("storelocations");
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
    /// Méthode pour obtenir un lieu de stockage en fonction de son id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<String?> GetStoreLocationByIdAsync(int id)
    {
        try
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                return await GetAsync("storelocations/" + id);
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
