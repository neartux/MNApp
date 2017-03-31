using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WisenetBackOfficeApp.Helpers.Keys;
using WisenetBackOfficeApp.Models.Common;
using WisenetBackOfficeApp.Models.Distributor;

namespace WisenetBackOfficeApp.Services
{
    class WisenetWebServices : IWisenetWebServices
    {
        HttpClient client;

        public WisenetWebServices()
        {
            client = new HttpClient();
        }

        public async Task<ResponseDistributor> FindDatosDistribuidorById(long idDistributor, string password)
        {
            ResponseDistributor responseVO = new ResponseDistributor();
            Debug.WriteLine("A buscar datos y validar");
            try
            {
                string url = WebServicesKeys.URL_VALIDATE_DISTRIBUTOR_AND_FIND_INFORMATION + idDistributor + Keys.SLASH + password;
                var response = await client.GetAsync(new Uri(string.Format(url, string.Empty)));
                Debug.WriteLine("RESPONSE = " + response);
                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("CONTENT = " + content);
                    responseVO = JsonConvert.DeserializeObject<ResponseDistributor>(content);
                    Debug.WriteLine("Final OBJ Response response VO = " + responseVO.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("An exception has ocurred: " + e.Message);
                responseVO.Success = false;
                responseVO.Message = e.Message;
            }
            return await Task.Run(() => responseVO);
        }

        public async Task<ResponseTO> UpdateShippingInformation(DistributorTO distributorTO)
        {
            Debug.WriteLine("**********************************************************************");
            ResponseTO responseVO = new ResponseTO();
            try
            {

                string url = WebServicesKeys.URL_UPDATE_SHIPPING_INFORMATION;
                Debug.WriteLine("URL REST SERVICE = " + url);

                var objJson = JsonConvert.SerializeObject(distributorTO);
                Debug.WriteLine("2");
                var content = new StringContent(objJson, Encoding.UTF8, Keys.CONTENT_TYPE_APPLICATION_JSON);
                Debug.WriteLine("3");

                HttpResponseMessage response = null;

                response = await client.PutAsync(new Uri(string.Format(url, string.Empty)), content);
                Debug.WriteLine("4");
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("contentResponse = " + contentResponse);
                    responseVO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);
                    Debug.WriteLine("OBJECT RESPONSE = " + responseVO);

                }
                else
                {
                    Debug.WriteLine("ERROR");
                }
                Debug.WriteLine("5");
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
            Debug.WriteLine("**********************************************************************");
            Debug.WriteLine(" ", idDistributor, birthDate);
            try
            {

                string url = WebServicesKeys.URL_UPDATE_BIRTH_DATE;
                Debug.WriteLine("URL REST SERVICE = " + url);

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("idDistributor", idDistributor.ToString()));
                postData.Add(new KeyValuePair<string, string>("birthDate", birthDate));


                Debug.WriteLine("2");
                //var content = new StringContent(objJson, Encoding.UTF8, Keys.CONTENT_TYPE_APPLICATION_JSON);
                var content = new FormUrlEncodedContent(postData);
                Debug.WriteLine("3");

                HttpResponseMessage response = null;

                response = await client.PostAsync(new Uri(string.Format(url, string.Empty)), content); // PENDIENTE POR CAMBIO EN OBJETOS, SE VA A PROBAR NUEVAMENTE LOGIN PARA VER SI FUNCIONA EL NUEVO CAMBIO
                Debug.WriteLine("4");
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("CONTENT = " + contentResponse);
                    responseTO = JsonConvert.DeserializeObject<ResponseTO>(contentResponse);

                }
                else
                {
                    Debug.WriteLine("ERROR");
                }
                Debug.WriteLine("5");
            }
            catch (Exception e)
            {
                responseTO.Success = false;
                responseTO.Message = e.Message;
                Debug.WriteLine("An error has ocurred " + e.Message);
            }
            return await Task.Run(() => responseTO);
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
