namespace ChimithequeLib;

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
            return await GetAsync("storages");
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
            return await GetAsync("storages/" + id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
