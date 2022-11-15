using Chimitheque_Mobile_App.Model;
using ChimithequeLib;
using Newtonsoft.Json;

namespace Chimitheque_Mobile_App.APisManagers
{
    public class ProductsManager
    {
       private ProductService service = new ProductService();

        /// <summary>
        /// Méthode pour convertir une donnée de produit en objet Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Products GetProductsById(int id)
        {
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
        public List<Products> GetAllProducts()
        {

           List<Products> products;
            try
            {
                var responseString =  service.GetProductsAsync().Result;
           
                products = JsonConvert.DeserializeObject<List<Products>>(responseString);

            }catch(Exception)
            {
                products = new List<Products>();
            }
           

            return products;
        }
 
    }
}
