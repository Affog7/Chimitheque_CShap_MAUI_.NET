using ChimithequeLib;
using ChimithequeLib.Model;
using ChimithequeLib.Models;
using Newtonsoft.Json;

namespace ChimithequeLib.APisManagers
{
    public class ProductsManager
    {
       private ProductService service = new ProductService();

        /// <summary>
        /// Méthode pour convertir une donnée de produit en objet Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Products GetProductsById(int id,HttpClient client)
        {
            service.httpClient = client;
            Products products;
            try
            {
                var responseString =  service.GetProductByIdAsync(id).Result;
           
                products = JsonConvert.DeserializeObject<Products>(responseString);

            }catch (Exception)
            {
                products = new Products();
            }
           

            return products;
        }


        /// <summary>
        /// Méthode pour convertir une list de donnée de produit en list d'objet Product
        /// </summary>
        /// <returns></returns>
        public ProductsList GetAllProducts(HttpClient client)
        {
            service.httpClient = client;

            ProductsList products;
            try
            {
                var responseString =  service.GetProductsAsync().Result;
           
                products = JsonConvert.DeserializeObject<ProductsList>(responseString);

            }catch(Exception)
            {
                products = new ProductsList();
            }
           

            return products;
        }
 
    }
}
