using System.Net.Http.Json;
using ChimithequeLib.Models.Storage;
using Newtonsoft.Json;

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

    /// <summary>
    /// Méthode pour Mettre à jour un stockage
    /// </summary>
    /// <param name="storage"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<string> PutStorageAsync(Product_Storage_Location storage,int id)
    {
        try
        {
            if (httpClient.DefaultRequestHeaders.Authorization != null)
            {
                var content = JsonConvert.SerializeObject(storage);
                content = @"{""Storage_quantity"": {""Float64"": 50.62,""Valid"": true},""Product"": {""product_id"": 5217},""Storelocation"": {""Storelocation_id"": {""Int64"": 1,""Valid"": true}}}";
                //return await PutAsync("storages/" + id, new StringContent(content, Encoding.UTF8, "application/json"));
                var response= httpClient.PutAsJsonAsync("storages/" + id, content).Result;

                var detail = response.ReasonPhrase;
                return detail;
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
