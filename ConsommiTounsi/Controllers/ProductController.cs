using ConsommiTounsi.Helper;
using ConsommiTounsi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZXing;

namespace ConsommiTounsi.Service
{
    public class ProductController : Controller
    {
        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("");




        ProductService productService = new ProductService();


        [HttpGet]
        public ActionResult ManageProduct()

        {




            if (productService.getAllProducts() != null)
            {
                ViewBag.products = productService.getAllProducts();
            }
            else
                ViewBag.products = null;

            return View();

        }
               



        [HttpGet]
        public ActionResult DetailProduct(int id)

        {
            Product e = productService.getProductById(id);
            if (e != null)
            {
                ViewBag.ImageUrl = "error";
                var str = System.Text.Encoding.UTF8.GetString(e.Picture);

                ViewBag.ImageUrl = "https://localhost:44336/Upload/" + str;
                return PartialView("_DetailProduct", e);

            }
            return View();

        }

        //Generate barecode methode 

        private string GenerateQRCode(string qrcodeText)
        {
            string folderPath = "~/Upload/";
            string imagePath = qrcodeText+".jpg";
         
            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            var result = barcodeWriter.Write(qrcodeText);
            string barcodePath = Server.MapPath("~/Upload/QrCode/"+imagePath);
            var barcodeBitmap = new Bitmap(result);
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(barcodePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return imagePath;
        }




        /***********************************Upload Image*************************************/
        public void uploadImage(FormCollection formCollection)
        {

            string folderPath = Server.MapPath("~/Upload/");  //Create a Folder in your Root directory on your solution.
            string fileName = formCollection["picture"];
            string imagePath = folderPath + fileName;
            byte[] imageArray = System.IO.File.ReadAllBytes(formCollection["picture"]);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            string base64StringData = "data:image/png;base64," + base64ImageRepresentation; // Your base 64 string data
            string cleandata = base64StringData.Replace("data:image/png;base64,", "");
            byte[] data = System.Convert.FromBase64String(cleandata);
            MemoryStream ms = new MemoryStream(data);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        //Add Product Controller
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> CreateProductAsync(FormCollection formCollection)
        {

            //upload function
            uploadImage(formCollection);

            // import function QR CODE GENERATE
            string bareCode = formCollection["BareCodeProduct"];



            ViewBag.qrCodeImagePath = GenerateQRCode(bareCode);
            ViewBag.Message = "QR Code Created successfully";


            /***********************Add product service method with affected category**************************************/

            var finalResult = await productService.addProduct(formCollection);
           var  response = finalResult;

            
            var response1 = false;
            if(response.StartsWith("Duplicated"))
            {
                return new JsonResult
                {
                    Data = new
                    {
                        response = true
                    }
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = new
                    {
                        response1 = true
                    }
                };
            }
            


        }



        //Get Create Product partial view

        [HttpGet]
        public ActionResult CreateProductModal()
        {


            return PartialView("_CreateProduct");
        }

        //Get Create Product partial view

        [HttpGet]
        public ActionResult UpdateProductModal(int id)
        {

            /**********************Get list categories ***************************************************/
            //Get list categories consume web service
            var responseCat = client.GetAsync(springMvcUrl + "/category/get-all-category").Result;

            if (responseCat.IsSuccessStatusCode)
            {
                ViewBag.categories = responseCat.Content.ReadAsAsync<IEnumerable<Category>>().Result;
            }

            Product e = productService.getProductById(id);
            if (e != null)
            {
                // string imageBase64Data = Convert.ToBase64String(e.Image);
                string imageDataURL = string.Format("data:image/png;base64,{0}", e.Picture);
                if (imageDataURL == null)
                    //System.Diagnostics.Debug.WriteLine("Image null");
                    ViewBag.ImageData = "error";
                else
                    ViewBag.ImageData = imageDataURL;
                return PartialView("_UpdateProduct", e);

            }
            return View();
        }

        //Delete Product
        [HttpPost]
        public JsonResult DeleteProdcut(int id)
        {
            var status = false;


            if (productService.deleteProducttById(id))
            {

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }



        //Update Product
        [HttpPost]
        public JsonResult Edit(Product Product)
        {


            int idProduct = Product.IdProduct;

            var response = false;
            if (productService.Update(Product, idProduct))
            {
                response = true;
            }
            return new JsonResult { Data = new { response = response } };
        }


 

    //Affecter Category
    [HttpPost]
    public JsonResult Affecter(int idp, int idc)
    {


        var response = false;
        if (productService.AffecterCategoryProduct(idp, idc))
        {
            response = true;
        }
        return new JsonResult { Data = new { response = response } };
    }
}

}