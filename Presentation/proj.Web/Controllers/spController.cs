using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using  System.Text;
using proj.Model.Company;
namespace proj.Web
{
 public class spController : Controller
 {
 	 
		private IWebHostEnvironment _hostingEnvironment;
		Uri url = new Uri("https://localhost:7098/gateway");
		HttpClient client;
		public spController(IWebHostEnvironment hostingEnvironment)
		{
		 _hostingEnvironment = hostingEnvironment;
		client= new HttpClient();
		 client.BaseAddress = url;
		}
		[HttpGet]
		public IActionResult Company()
		{
		return View();
		}

        [HttpPost]
        public async Task<IActionResult> Company(Company_Model TBL)
{

 if (!ModelState.IsValid)
		{
			var message = string.Join(" | ", ModelState.Values
			 .SelectMany(v => v.Errors)
			.Select(e => e.ErrorMessage));
			return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
		}
		else
		       {
            try
            {
                HttpResponseMessage resNew = await client.PostAsync(url + "/Company/CreateCompany", new StringContent(JsonConvert.SerializeObject(TBL),
Encoding.UTF8, "application/json"));

                if (TBL.CompanyID == 0)
                {
                    return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                }
                else if (TBL.CompanyID > 0)
                {
                    return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                }
                else
                {
                    return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  }     
		[HttpGet]
		public IActionResult ViewCompany()
		{
		return View();
		}
        [HttpGet]
        public async Task<JsonResult> Get_Company()
		        {
 if (!ModelState.IsValid)
		{
			var message = string.Join(" | ", ModelState.Values
 .SelectMany(v => v.Errors)
.Select(e => e.ErrorMessage));
			return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
		}
		else
		{           try
            {
                var data = JsonConvert.DeserializeObject<List<Company_Model>>(await client.GetStringAsync(url + "/Company/GetCompany"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  }     
        [HttpDelete]

        public async Task<JsonResult> Delete_Company(int Id)
        {
            int x=0;
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Company/DeleteCompany?Id=" + Id).Result;
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    x = JsonConvert.DeserializeObject<int>(data);
                }
                return Json(x);
            }
            
        }

       
        [HttpGet]

        public async Task<JsonResult> GetByID_Company(int Id)
        {
           Company_Model lst = new Company_Model();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Company/GetByIDCompany?Id=" + Id).Result;
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<Company_Model>(data);
                }
                
                var jsonres = JsonConvert.SerializeObject(lst);
                return Json(jsonres);
            }
        }

}
}
