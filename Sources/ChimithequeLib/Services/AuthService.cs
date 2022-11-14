namespace ChimithequeLib;

public class AuthService:Services
{
    /// <summary>
    /// Méthode pour se connecter
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task GetTokenAsync(string login, string password)
    {
        var content = "{\"person_email\":\"" + login + "\"," +
                          "\"person_password\":\"" + password + "\"}";
        var token = await PostAsync("get-token", new StringContent(content, Encoding.UTF8, "application/json"));
        if (token != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
        }
    }

    //logout
    public void Logout()
    {
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}
