namespace ChimithequeLib;

/// <summary>
/// Classe de service d'authentification
/// </summary>
public class AuthService:Services
{
    /// <summary>
    /// Méthode pour se connecter
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<string?> GetTokenAsync(string login, string password)
    {
        var content = "{\"person_email\":\"" + login + "\"," +
                          "\"person_password\":\"" + password + "\"}";
        var token = await PostAsync("get-token", new StringContent(content, Encoding.UTF8, "application/json"));
        if (token != null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
        }
        else
            return null;
    }

    //logout
    public void Logout()
    {
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}
