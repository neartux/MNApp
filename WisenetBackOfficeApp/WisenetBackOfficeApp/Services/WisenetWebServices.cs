using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers.Keys; 
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;
using WisenetBackOfficeApp.Models.Ordenes;
using WisenetBackOfficeApp.Translations;

namespace WisenetBackOfficeApp.Services
{
    class WisenetWebServices : IWisenetWebServices {
        HttpClient client;
        CancellationTokenSource cts;

        public WisenetWebServices() {
            // Inicia el cliente http
            client = new HttpClient();
            // Inicia evento para cancelar task, en dado caso no se conecte a webservice
            cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(500));
        }

        public async Task<ResponseDistributor> FindDatosDistribuidorById(long idDistributor, string password) {
            ResponseDistributor responseVO = new ResponseDistributor();
            try
            {
                string url = WebServicesKeys.URL_VALIDATE_DISTRIBUTOR_AND_FIND_INFORMATION + idDistributor + Keys.SLASH + password;
                Debug.WriteLine("URL = " + url);
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)), cts.Token);
                if (response.IsSuccessStatusCode) {

                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseDistributor>(content);
                }
                
            } catch (TaskCanceledException ex) {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseVO.Success = false;
                responseVO.Message = AppResources.WebserviceLabelTimeOut;
            } catch (Exception e) {
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

                response = await client.PutAsync(new Uri(string.Format(url, string.Empty)), content, cts.Token);
                if (response.IsSuccessStatusCode) {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);
                }
            } catch (TaskCanceledException ex) {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseVO.Success = false;
                responseVO.Message = AppResources.WebserviceLabelTimeOut;
            } catch (Exception e) {
                responseVO.Success = false;
                responseVO.Message = e.Message;
                Debug.WriteLine("An error has ocurred " + e.Message);
            }

            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseTO> UpdateBillingInformation(DistributorTO distributorTO)
        {
            ResponseTO responseVO = new ResponseTO();
            try
            {

                string url = WebServicesKeys.URL_UPDATE_PERSONAL_INFORMATION;
                Debug.WriteLine("URL REST SERVICE = " + url);

                var objJson = JsonConvert.SerializeObject(distributorTO);
                var content = new StringContent(objJson, Encoding.UTF8, Keys.CONTENT_TYPE_APPLICATION_JSON);

                HttpResponseMessage response = null;

                response = await client.PutAsync(new Uri(string.Format(url, string.Empty)), content, cts.Token);
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);
                }
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseVO.Success = false;
                responseVO.Message = AppResources.WebserviceLabelTimeOut;
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

                response = await client.PostAsync(new Uri(string.Format(url, string.Empty)), content, cts.Token); // PENDIENTE POR CAMBIO EN OBJETOS, SE VA A PROBAR NUEVAMENTE LOGIN PARA VER SI FUNCIONA EL NUEVO CAMBIO
                Debug.WriteLine("4");
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("CONTENT = " + contentResponse);
                    responseTO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);

                }
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseTO.Success = false;
                responseTO.Message = AppResources.WebserviceLabelTimeOut;
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
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)), cts.Token);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseVenta>(content);
                }
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseVO.Success = false;
                responseVO.Message = AppResources.WebserviceLabelTimeOut;
            }
            catch (Exception e) {
                responseVO.Success = false;
                responseVO.Message = e.Message;
            }
            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseVentaDetalle> FindVentaById(long idVenta) {
            ResponseVentaDetalle responseVO = new ResponseVentaDetalle();
            try {
                string url = WebServicesKeys.URL_FIND_ORDER_BY_ID + idVenta;
                Debug.WriteLine(" = " + url);
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)), cts.Token);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    responseVO = JsonConvert.DeserializeObject<ResponseVentaDetalle>(content);
                }
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                responseVO.Success = false;
                responseVO.Message = AppResources.WebserviceLabelTimeOut;
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
            Debug.WriteLine("Url = " + url);
            var ubicaciones = new List<CatalogoTO>();
            try
            {
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)), cts.Token);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    ubicaciones = JsonConvert.DeserializeObject<List<CatalogoTO>>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("An exception has ocurred: " + e.Message);
            }
            return await Task.Run(() => ubicaciones);
        }
    }
}
