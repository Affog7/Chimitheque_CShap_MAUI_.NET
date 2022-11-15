internal class Program
{
    private static void Main(string[] args)
    {
        //var data = new ProductsManager();
        Console.WriteLine("Hello, World!");
        Console.WriteLine("veillez entrer votre Email");
        string email = Console.ReadLine();
        Console.WriteLine("veillez entrer votre mot de passe");
        string password = Console.ReadLine();
        AuthService authenticationService = new AuthService();
        authenticationService.GetTokenAsync(email, password);

        //Methode Menue
        static void Menu()
        {
            Console.WriteLine("1. Afficher les produit");
            Console.WriteLine("2. Afficher un produit par ID");
            Console.WriteLine("3. Afficher les Stoks");
            Console.WriteLine("4. Afficher un Stock par ID");
            Console.WriteLine("5. Afficher les Lieux de Stock");
            Console.WriteLine("6. Afficher un Lieu de Stock par ID");
            Console.WriteLine("7. Afficher les Personnes");
            Console.WriteLine("8. Afficher une Personne par ID");
            Console.WriteLine("9. Quitter");
        }

        //Methode pour Recuperer le choix de l'utilisateur
        static int GetChoice()
        {
            int choice = 0;
            bool isNumber = false;
            do
            {
                Console.WriteLine("Choisir une option");
                isNumber = int.TryParse(Console.ReadLine(), out choice);
            } while (!isNumber);
            return choice;
        }
        
        //Methode pour effectuer le choix de l'utilisateur
        static void DoChoice(int choice)
        {
            while (true)
            {
                switch (choice)
                {
                    case 1:

                        break;
                    case 2:
                        Console.WriteLine("Afficher un produit par ID");
                        break;
                    case 3:
                        Console.WriteLine("Afficher les Stoks");
                        break;
                    case 4:
                        Console.WriteLine("Afficher un Stock par ID");
                        break;
                    case 5:
                        Console.WriteLine("Afficher les Lieux de Stock");
                        break;
                    case 6:
                        Console.WriteLine("Afficher un Lieu de Stock par ID");
                        break;
                    case 7:
                        Console.WriteLine("Afficher les Personnes");
                        break;
                    case 8:
                        Console.WriteLine("Afficher une Personne par ID");
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }
            }
        }
    }
}