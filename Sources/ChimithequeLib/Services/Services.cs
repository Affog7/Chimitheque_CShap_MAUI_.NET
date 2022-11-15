namespace ChimithequeLib;

/// <summary>
/// Classe de base pour les services
/// </summary>
public class Services
{
    public HttpClient httpClient = new HttpClient();
    protected string fail = "Vous n'êtes pas connecté";

    /// <summary>
    /// Extencier un Service
    /// </summary>
    public Services()
    {
        httpClient.BaseAddress = new System.Uri("https://imost.iut-clermont.uca.fr/chimithequedev/");
    }

    /// <summary>
    /// Méthode de base pour les requêtes GET
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    protected async Task<string> GetAsync(string url)
    {
        var response =httpClient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            var value=await response.Content.ReadAsStringAsync();
            return value;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Méthode de base pour les requêtes POST
    /// </summary>
    /// <param name="url"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    protected async Task<string?> PostAsync(string url, HttpContent content)
    {
        var response = httpClient.PostAsync(url, content).Result;
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            return null;
        }
    }
}
