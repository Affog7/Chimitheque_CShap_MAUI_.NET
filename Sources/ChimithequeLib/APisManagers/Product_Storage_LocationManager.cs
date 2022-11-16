using ChimithequeLib.Model;
using ChimithequeLib.Model.Storage;
using ChimithequeLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.APisManagers
{
    public class Product_Storage_LocationManager
    {
        private StorageService service = new StorageService();

        /// <summary>
        /// Méthode pour convertir une donnée de storage en objet Product_Storage_Location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product_Storage_Location GetStorageLocationById(int id, HttpClient client)
        {
            service.httpClient = client;
            Product_Storage_Location storage;
            try
            {
                var responseString = service.GetStorageByIdAsync(id).Result;

                storage = JsonConvert.DeserializeObject<Product_Storage_Location>(responseString);

            }
            catch (Exception)
            {
                storage = new Product_Storage_Location();
            }


            return storage;
        }


        /// <summary>
        /// Méthode pour convertir une list de donnée de storage en Storage
        /// </summary>
        /// <returns></returns>
        public Storages GetAllStorage(HttpClient client)
        {
            service.httpClient = client;

            Storages storage;
            try
            {
                var responseString = service.GetStoragesAsync().Result;

                storage = JsonConvert.DeserializeObject<Storages>(responseString);

            }
            catch (Exception)
            {
                storage = new Storages();
            }


            return storage;
        }
    }
}
