using ConsommiTounsi.Helper;
using ConsommiTounsi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ConsommiTounsi.Service
{
    public class CategoryService
    {


        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("");




        //***********ListCategory******/

        public IEnumerable<Category> ListCategory()
        {


            HttpResponseMessage response = client.GetAsync(springMvcUrl + "/category/get-all-category").Result;

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Category> categories = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                return categories;
            }
            else
                return null;

        }






        /******Create Category ****************/
        public bool createCategory(Category catJson)
        {

            try
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var APIResponse = client.PostAsJsonAsync<Category>(springMvcUrl + "/category/add-category", catJson).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                if (APIResponse.Result.IsSuccessStatusCode)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }

        }


        //Delete category

        /*****************Delete Category ****************************/
        public bool deleteCategoryById(int idCategory)
        {
            try
            {

                var APIResponse = client.DeleteAsync(springMvcUrl + "/category/delete-category/" + idCategory.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }


        /************Find By ID *************************************/
        public Category getCategoryById(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/category/find-category-byid/" + id.ToString()).Result;
            Category category = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                category = httpResponseMessage.Content.ReadAsAsync<Category>().Result;


            }
            else
            {
                category = null;
            }
            return category;
        }



        /*****************Update category*****************/

        public bool Update(Category c, int id)
        {
            try
            {
                var APIResponse = client.PutAsJsonAsync<Category>(springMvcUrl + "/category/update-category/" + id, c);

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
    }
}