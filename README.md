# ChimithequeMobile 👨‍🔬
## Mobile application for Chimitheque 📱

Application mobile de gestion des stocks de produits chimiques pour les laboratoires de chimie , de biologie, de mathématiques et de physique.
à l'origine développée pour le laboratoire de l'IUT clermont-Auvergne, le but est de pouvoir être utilisé par plusieurs autres laboratoires.
Elle est développée en .Net et utilise le framework .Net MAUI pour l'interface utilisateur et consomme une API REST développée en ... pour la partie web. le but est de fournir une application multiplateforme (Android, iOS, Windows, MacOS, Linux, ...) et multi-langue qui permetra de gérer(emprunter, rendre, ajouter, supprimer, ...) les produits chimiques du laboratoire. 
on devrait pouvoir aussi gérer les stocks de produits chimiques et les commandes de produits chimiques.
l'application auras les fonctionnalités suivantes:
- authentification (login, mot de passe, qr code, ...): permet de s'authentifier sur l'application
- gestion des produits chimiques (ajouter, supprimer, modifier, ...): nom, description, stock, emplacement, ...
- gestion des stocks (ajouter, supprimer, modifier, ...): 
    - ajouter un produit au stock: nom, description, stock, emplacement, ...
    - supprimer un produit du stock: nom, description, stock, emplacement, ...
    - modifier la quantité d'un produit dans le stock: nom, description, stock, emplacement, ...
    - ajouter un produit à la commande: nom, description, stock, emplacement, ...
    - supprimer un produit de la commande: nom, description, stock, emplacement, ...
    - modifier la quantité d'un produit dans la commande: nom, description, stock, emplacement, ...
- gestion des commandes (ajouter, supprimer, modifier, ...): 
    - ajouter un produit à la commande: ajoute un produit à la commande et le retire du stock
    - supprimer un produit de la commande: supprime un produit de la commande et le remet dans le stock
    - modifier la quantité d'un produit dans la commande: modifie la quantité d'un produit dans la commande et modifie la quantité du produit dans le stock
- gestion des emprunts (ajouter, supprimer, modifier, ...): emprunter, rendre, ...
- gestion des utilisateurs (ajouter, supprimer, modifier, ...): les utilisateurs auront des droits différents (admin, utilisateur, ...)
- gestion des favoris (ajouter, supprimer, modifier, ...): permet de mettre en favoris les produits les plus Commandés
- gestion des wishlist (ajouter, supprimer, modifier, ...): permet de mettre en wishlist les produits les plus empruntés
- partage des emprrunts (ajouter, supprimer, modifier, ...): permettre à un utilisateur de partager un emprunt avec un autre utilisateur
- gestion des statistiques : nombre de produits chimiques, nombre d'emprunts, nombre de commandes, nombre d'utilisateurs, nombre de favoris, nombre de wishlist, nombre de partages, ...
- gestion du mode hors connexion: permet d'effectuer des empruns hors connexion et de les synchroniser avec le serveur une fois la connexion rétablie
- gestion du mode anonyme: permet d'effectuer des emprunts sans s'authentifier et de les synchroniser avec le serveur une fois l'authentification rétablie
- gestion des paramètres: permet de modifier les paramètres de l'application (langue, ...)
- gestion des notifications: permet d'envoyer des notifications aux utilisateurs (emprunt, retour, commande, ...)
- gestion des alertes: permet d'envoyer des alertes aux utilisateurs (stock bas, stock vide, ...)
- gestion des rapports: permet de générer des rapports (pdf, excel, ...)
- gestion des logs: permet de générer des logs (pdf, excel, ...)
- gestion des erreurs: permet de gérer les erreurs (envoyer un mail, ...)
- gestion des mises à jour: permet de mettre à jour l'application


## Outillage 🛠️
- Visual Studio 2022 community: https://visualstudio.microsoft.com/fr/vs/
- .Net MAUI
- .Net 6: https://dotnet.microsoft.com/download/dotnet/6.0
- codefirst: https://codefirst.iut.uca.fr/

## Utilisation 📋
- cloner le projet
- ouvrir le projet dans Visual Studio 2022 community avec le SDK .Net 6 et la charge de travail .Net MAUI
- lancer le projet

## Installation 📦
- installer Visual Studio 2022 community avec le SDK .Net 6 et la charge de travail .Net MAUI
- installer le projet
- lancer le projet


L'application sera disponible sur le store de l'OS de votre choix (Android, iOS, Windows, MacOS, Linux, ...)

L'application sera utilisable par les utilisateurs du laboratoire de l'IUT clermont-Auvergne et par les utilisateurs des autres laboratoires.

## Roadmap 🚀

## Auteurs ✒️


## Support

Please hit a like to plugin on pub if you used it and love it. put a ⭐️ my GitHub [repo](https://github.com/Affog7/Web_Radio_Flutter_App) and show me some ♥️ so i can keep working on this.

### Found a bug ?

Please feel free to throw in a pull request. Any support is warmly welcome.

## Contributor
* [Augustin AFFOGNON](https://www.linkedin.com/in/augustin-affognon-54a867248/)

## License
* [MIT](https://github.com/Affog7/Web_Radio_Flutter_App/blob/main/LICENSE)
