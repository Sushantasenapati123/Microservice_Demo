using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using  System.Text;
using proj.Model.Bothh;
using proj.Model.City;
namespace proj.Web
{
 public class tblController : Controller
 {
 	 
		private IWebHostEnvironment _hostingEnvironment;
		Uri url = new Uri("https://localhost:7098/gateway");
		HttpClient client;
		public tblController(IWebHostEnvironment hostingEnvironment)
		{
		 _hostingEnvironment = hostingEnvironment;
		client= new HttpClient();
		 client.BaseAddress = url;
		}
		[HttpGet]
		public IActionResult Bothh()
		{
		return View();
		}

        [HttpPost]
        public async Task<IActionResult> Bothh(Bothh_Model TBL)
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
                HttpResponseMessage resNew = await client.PostAsync(url + "/Bothh/CreateBothh", new StringContent(JsonConvert.SerializeObject(TBL),
Encoding.UTF8, "application/json"));

                if (TBL.DistId == 0)
                {
                    return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                }
                else if (TBL.DistId > 0)
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
		public IActionResult ViewBothh()
		{
		return View();
		}
        [HttpGet]
        public async Task<JsonResult> Get_Bothh()
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
                var data = JsonConvert.DeserializeObject<List<Bothh_Model>>(await client.GetStringAsync(url + "/Bothh/GetBothh"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  }     
        [HttpDelete]

        public async Task<JsonResult> Delete_Bothh(int Id)
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
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Bothh/DeleteBothh?Id=" + Id).Result;
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

        public async Task<JsonResult> GetByID_Bothh(int Id)
        {
           Bothh_Model lst = new Bothh_Model();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Bothh/GetByIDBothh?Id=" + Id).Result;
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<Bothh_Model>(data);
                }
                
                var jsonres = JsonConvert.SerializeObject(lst);
                return Json(jsonres);
            }
        }

	 
		[HttpGet]
		public IActionResult City()
		{
		return View();
		}

        [HttpPost]
        public async Task<IActionResult> City(City_Model TBL)
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
                HttpResponseMessage resNew = await client.PostAsync(url + "/City/CreateCity", new StringContent(JsonConvert.SerializeObject(TBL),
Encoding.UTF8, "application/json"));

                if (TBL.CityId == 0)
                {
                    return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                }
                else if (TBL.CityId > 0)
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
		public IActionResult ViewCity()
		{
		return View();
		}
        [HttpGet]
        public async Task<JsonResult> Get_City()
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
                var data = JsonConvert.DeserializeObject<List<City_Model>>(await client.GetStringAsync(url + "/City/GetCity"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  }     
        [HttpDelete]

        public async Task<JsonResult> Delete_City(int Id)
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
                HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/City/DeleteCity?Id=" + Id).Result;
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

        public async Task<JsonResult> GetByID_City(int Id)
        {
           City_Model lst = new City_Model();
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/City/GetByIDCity?Id=" + Id).Result;
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<City_Model>(data);
                }
                
                var jsonres = JsonConvert.SerializeObject(lst);
                return Json(jsonres);
            }
        }

}
}
