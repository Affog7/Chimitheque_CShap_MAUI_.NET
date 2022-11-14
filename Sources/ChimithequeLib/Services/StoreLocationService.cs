namespace ChimithequeLib;

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
            return await GetAsync("storelocations");
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
            return await GetAsync("storelocations/" + id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}
