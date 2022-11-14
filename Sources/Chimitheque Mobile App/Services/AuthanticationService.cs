namespace Chimitheque_Mobile_App.Services;

internal class AuthanticationService:Services
{
    /// <summary>
    /// Méthode pour se connecter
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private async Task GetTokenAsync(string login, string password)
    {
        var content = "{\"person_email\":\"" + login + "\"," +
                          "\"person_password\":\"" + password + "\"}";
        var token = await PostAsync("get-token", new StringContent(content, Encoding.UTF8, "application/json"));
        if (token != null)
        {
            //save token to preferences
            Preferences.Set("token", token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", ""));
            
        }
    }

    //logout
    public void Logout()
    {
        Preferences.Set("token", "");
        httpClient.DefaultRequestHeaders.Authorization = null;
    }
}
