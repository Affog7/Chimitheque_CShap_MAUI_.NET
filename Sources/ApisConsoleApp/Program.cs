using ChimithequeLib;
using ChimithequeLib.APisManagers;
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
        Console.WriteLine("1. Afficher un entrepot");
        Console.WriteLine("11. Afficher la liste des entrepots");
        
        Console.WriteLine("2. Afficher un produit par ID");

        Console.WriteLine("3. Afficher un Stock par ID");
        Console.WriteLine("4. Afficher les Stoks");
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

                    Console.WriteLine("veillez entrer l'ID de l'entrepôt");

                    int id = int.Parse(Console.ReadLine());

                    var data = new StoreLocationsManager().GetLocationById(id, authentication);

                    Console.WriteLine(data);
                    break;


                case 11:                    

                    var data11 = new StoreLocationsManager().GetAllLocations(authentication);

                    foreach(var location in data11.Rows)
                    {
                        Console.WriteLine(location);
                    }

                    break;

                case 2:
                 
                    Console.WriteLine("veillez entrer l'ID du produit");

                    int id2 = int.Parse(Console.ReadLine());

                    var data2 = new ProductsManager().GetProductsById(id2, authentication);

                    Console.WriteLine(data2);

                    break;
                case 3:
                    Console.WriteLine("veillez entrer l'ID du stockage");

                    int id3 = int.Parse(Console.ReadLine());

                    var data3 = new Product_Storage_LocationManager().GetStorageLocationById(id3, authentication);

                    Console.WriteLine(data3);
                    break;
                case 4:
                    var data4 = new Product_Storage_LocationManager().GetAllStorage(authentication);

                    foreach (var location in data4.Rows)
                    {
                        Console.WriteLine(location);
                    }
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
                    int id6 = int.Parse(Console.ReadLine());
                    Console.WriteLine(await lieuStock1.GetStoreLocationByIdAsync(id6));
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