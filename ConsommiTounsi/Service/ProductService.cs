using ConsommiTounsi.Helper;
using ConsommiTounsi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Service
{
    public class ProductService
    {
        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("");




        public IEnumerable<Product> getAllProducts()
        {

            IEnumerable<Product> products;
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/product/get-all-product").Result;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                products = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Product>>().Result;

            }
            else
                products  = null;

            return products;
        }





            /**************Display Product By Id (Detail)**************/

            public Product getProductById(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/product/get-productbyId/" + id.ToString()).Result;
            Product products = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                products = httpResponseMessage.Content.ReadAsAsync<Product>().Result;


            }
            else
            {
                products = null;
            }
            return products;
        }






        /***************Add Product ***************************/


        public async Task<string> addProduct(FormCollection formCollection)
        {


            MultipartFormDataContent m = new MultipartFormDataContent();
 


            //Desrialize 

            var list = new Dictionary<string, string>();
            list.Add("prJson", formCollection["prJson"]);
            string toJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

            var filestream = new FileStream("C:/Users/USER/Desktop/imageevent/" + formCollection["picture"], FileMode.Open);
            var fileName = System.IO.Path.GetFileName(formCollection["picture"]);


            var stringContent = new StringContent(formCollection["prJson"]);
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>" + stringContent);






            //Convert JSON into Model




            m.Add(stringContent, "prJson");


            m.Add(new StreamContent(filestream), "picture", fileName);

            var response = await client.PostAsync(springMvcUrl + "/product/add-product",
                m);
            var contents = await response.Content.ReadAsStringAsync();

           


            return contents;

        }



        /*****************Delete Product ****************************/
        public bool deleteProducttById(int id)
        {
            try
            {
                var APIResponse = client.DeleteAsync(springMvcUrl + "/product/delete-product/" + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }



        /*********************Update Product*************************/

        public bool Update(Product e, int id)
        {
            try
            {
                var APIResponse = client.PutAsJsonAsync<Product>(springMvcUrl + "/product/update-product/" + id,e);

                APIResponse.Wait();
                var result = APIResponse.Result;
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                if (result.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }



        /**************************Affecter  Category Product*******************************/
        [HttpPost]
        public bool AffecterCategoryProduct(int idp, int idc)
        {

            client.PutAsync("/category/affecter-category-product/" + idp + "/" + idc, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return true;
        }
    }



}

    
