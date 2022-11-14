namespace ChimithequeLib;

public class Services
{
    protected HttpClient httpClient = new HttpClient();

    //Constructor
    public Services()
    {
        httpClient.BaseAddress = new System.Uri("https://imost.iut-clermont.uca.fr/chimithequedev/");
    }

    protected async Task<string?> GetAsync(string url)
    {
        var response = httpClient.GetAsync(url).Result;
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            return null;
        }
    }

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
