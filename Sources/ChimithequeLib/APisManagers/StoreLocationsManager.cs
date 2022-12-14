using ChimithequeLib.Model;
using ChimithequeLib.Models;
using ChimithequeLib.Models.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StoreLocation = ChimithequeLib.Models.Storage.StoreLocation;

namespace ChimithequeLib.APisManagers
{
    public class StoreLocationsManager
    {
        private StoreLocationService service = new StoreLocationService();

        /// <summary>
        /// Méthode pour convertir une donnée d' entrepot en objet StoreLocation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StoreLocation GetLocationById(int id,HttpClient client)
        {
            service.httpClient.DefaultRequestHeaders.Clear();
            service.httpClient = client;
            StoreLocation storeLocation;
            try
            {
                var responseString = service.GetStoreLocationByIdAsync(id).Result;

                storeLocation = JsonConvert.DeserializeObject<StoreLocation>(responseString);

            }
            catch (Exception)
            {
                storeLocation = new StoreLocation();
            }


            return storeLocation;
        }


        /// <summary>
        /// Méthode pour convertir une list de donnée d'entrepot en list d'objet StoreLocation
        /// </summary>
        /// <returns></returns>
        public StoreLocationList GetAllLocations(HttpClient client)
        {
            service.httpClient = client;

            StoreLocationList storeLocationList;
            try
            {
                var responseString = service.GetStoreLocationAsync().Result;

                storeLocationList = JsonConvert.DeserializeObject<StoreLocationList>(responseString);

            }
            catch (Exception)
            {
                storeLocationList = new StoreLocationList();
            }


            return storeLocationList;
        }
    }
}
