using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Ordenes;

namespace WisenetBackOfficeApp.Services
{
    class WisenetWebServices : IWisenetWebServices {
        HttpClient client;

        public WisenetWebServices() {
            client = new HttpClient();   
        }

        public async Task<ResponseDistributor> FindDatosDistribuidorById(long idDistributor, string password) {
            ResponseDistributor responseVO = new ResponseDistributor();
            try
            {
                string url = WebServicesKeys.URL_VALIDATE_DISTRIBUTOR_AND_FIND_INFORMATION + idDistributor + Keys.SLASH + password;
                Debug.WriteLine("URL = " + url);
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)));
                if (response.IsSuccessStatusCode) {

                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseDistributor>(content);
                }
            }
            catch (Exception e) {
                Debug.WriteLine("ERROR = " + e.Message);
                responseVO.Success = false;
                responseVO.Message = e.Message;
            }
            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseTO> UpdateShippingInformation(DistributorTO distributorTO) {
            ResponseTO responseVO = new ResponseTO();
            try
            {

                string url = WebServicesKeys.URL_UPDATE_SHIPPING_INFORMATION;
                Debug.WriteLine("URL REST SERVICE = " + url);

                var objJson = JsonConvert.SerializeObject(distributorTO);
                var content = new StringContent(objJson, Encoding.UTF8, Keys.CONTENT_TYPE_APPLICATION_JSON);

                HttpResponseMessage response = null;

                response = await client.PutAsync(new Uri(string.Format(url, string.Empty)), content);
                if (response.IsSuccessStatusCode) {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);
                }
            }
            catch (Exception e)
            {
                responseVO.Success = false;
                responseVO.Message = e.Message;
                Debug.WriteLine("An error has ocurred " + e.Message);
            }

            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseTO> UpdateBirthDateDistributor(long idDistributor, string birthDate)
        {
            ResponseTO responseTO = new ResponseTO();
            Debug.WriteLine(" ", idDistributor, birthDate);
            try
            {

                string url = WebServicesKeys.URL_UPDATE_BIRTH_DATE;
                Debug.WriteLine("URL REST SERVICE = " + url);

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("idDistributor", idDistributor.ToString()));
                postData.Add(new KeyValuePair<string, string>("birthDate", birthDate));

                var content = new FormUrlEncodedContent(postData);

                HttpResponseMessage response = null;

                response = await client.PostAsync(new Uri(string.Format(url, string.Empty)), content); // PENDIENTE POR CAMBIO EN OBJETOS, SE VA A PROBAR NUEVAMENTE LOGIN PARA VER SI FUNCIONA EL NUEVO CAMBIO
                Debug.WriteLine("4");
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("CONTENT = " + contentResponse);
                    responseTO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);

                }
            }
            catch (Exception e)
            {
                responseTO.Success = false;
                responseTO.Message = e.Message;
                Debug.WriteLine("An error has ocurred " + e.Message);
            }
            return await Task.Run(() => responseTO);
        }

        public async Task<ResponseVenta> FindOrdersByDistributor(long idDistributor) {
            
            ResponseVenta responseVO = new ResponseVenta();
            
            try {
                string url = WebServicesKeys.URL_FIND_ORDERS_BY_DISTRIBUTOR + idDistributor;
                Debug.WriteLine("URL = " + url);
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)));
                if (response.IsSuccessStatusCode) {
                    Debug.WriteLine("----------------------------------------------------------------------------------------");
                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseVenta>(content);
                    Debug.WriteLine("CONTENT = " + content);
                }
            } catch (Exception e) {
                responseVO.Success = false;
                responseVO.Message = e.Message;
            }
            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseVentaDetalle> FindVentaById(long idVenta) {
            ResponseVentaDetalle responseVO = new ResponseVentaDetalle();
            try {
                string url = WebServicesKeys.URL_FIND_ORDER_BY_ID + idVenta;
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)));
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseVentaDetalle>(content);
                }
            }
            catch (Exception e) {
                Debug.WriteLine("ERROR: " + e.Message);
                responseVO.Success = false;
                responseVO.Message = e.Message;
            }
            return await Task.Run(() => responseVO);
        }

        public async Task<List<CatalogoTO>> FindUbicaciones(string url)
        {
            Debug.WriteLine("Url de la peticion = " + url);
            var ubicaciones = new List<CatalogoTO>();
            try
            {
                Debug.WriteLine("1");
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)));
                Debug.WriteLine("2");
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("3");
                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("4");
                    ubicaciones = JsonConvert.DeserializeObject<List<CatalogoTO>>(content);
                    Debug.WriteLine("5");
                }
                Debug.WriteLine("6");
            }
            catch (Exception e)
            {
                Debug.WriteLine("An exception has ocurred: " + e.Message);
            }
            return await Task.Run(() => ubicaciones);
        }
    }
}
