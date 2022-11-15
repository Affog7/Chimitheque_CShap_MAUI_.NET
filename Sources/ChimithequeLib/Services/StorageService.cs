namespace ChimithequeLib;

/// <summary>
/// Classe de service pour les stockages
/// </summary>
public class StorageService:Services
{
    /// <summary>
    /// Méthode pour obtenir tous les stockages
    /// </summary>
    /// <returns></returns>
    public async Task<String?> GetStoragesAsync()
    {
        try
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                 var value = await GetAsync("storages");
                return value;
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
    /// Méthode pour obtenir un stockage en fonction de son id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<String?> GetStorageByIdAsync(int id)
    {
        try
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                return await GetAsync("storages/" + id);
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
