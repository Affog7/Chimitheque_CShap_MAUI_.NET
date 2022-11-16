using ChimithequeLib;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;

internal class Program
{

    private static void Main(string[] args)
    {
        
        Console.WriteLine("veillez entrer votre Email");
        string email = Console.ReadLine();
        Console.WriteLine("veillez entrer votre mot de passe");
        string password = Console.ReadLine();
        AuthService authService = new AuthService();
        var token = authService.GetTokenAsync(email, password);
        var httpClient = authService.httpClient;
        DoChoice(httpClient);
    }

    //Methode Menue
    static void Menu()
    {
        Console.WriteLine("1. Afficher les produit");
        Console.WriteLine("2. Afficher un produit par ID");
        Console.WriteLine("3. Afficher les Stoks");
        Console.WriteLine("4. Afficher un Stock par ID");
        Console.WriteLine("5. Afficher les Lieux de Stock");
        Console.WriteLine("6. Afficher un Lieu de Stock par ID");
        Console.WriteLine("7. Quitter");
    }

    //Methode pour Recuperer le choix de l'utilisateur
    static int GetChoice()
    {
        Menu();
        int choice;
        bool isNumber;
        do
        {
            Console.WriteLine("Choisir une option");
            isNumber = int.TryParse(Console.ReadLine(), out choice);
        } while (!isNumber);
        return choice;
    }

    //Methode pour effectuer le choix de l'utilisateur
    static async void DoChoice(HttpClient authentication)
    {
        while (true)
        {
            int choice = GetChoice();
            switch (choice)
            {
                case 1:
                    ProductService product = new ProductService();
                    product.httpClient = authentication;
                    Console.WriteLine(await product.GetProductsAsync());
                    break;
                case 2:
                    ProductService product1 = new ProductService();
                    product1.httpClient = authentication;
                    Console.WriteLine("veillez entrer l'ID du produit");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine(await product1.GetProductByIdAsync(id));
                    break;
                case 3:
                    StorageService stock = new StorageService();
                    stock.httpClient = authentication;
                    var value = await stock.GetStoragesAsync();
                    Console.WriteLine(value);
                    break;
                case 4:
                    StorageService stock1 = new StorageService();
                    stock1.httpClient = authentication;
                    Console.WriteLine("veillez entrer l'ID du stock");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine(await stock1.GetStorageByIdAsync(id1));
                    break;
                case 5:
                    StoreLocationService lieuStock = new StoreLocationService();
                    lieuStock.httpClient = authentication;
                    Console.WriteLine(await lieuStock.GetStoreLocationAsync());
                    break;
                case 6:
                    StoreLocationService lieuStock1 = new StoreLocationService();
                    lieuStock1.httpClient = authentication;
                    Console.WriteLine("veillez entrer l'ID du lieu de stock");
                    int id2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(await lieuStock1.GetStoreLocationByIdAsync(id2));
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }
    }
}