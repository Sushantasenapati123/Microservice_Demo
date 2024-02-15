using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using proj.Model.City;
using City.MicroService.API.Interfaces;
namespace City.MicroService.API
{

 [ApiController]
 [Route("Api/[controller]")]
 public class CityController : ControllerBase
 {
 	 
		public IConfiguration Configuration;
		private readonly ItblRepository _tblRepository;
        private IWebHostEnvironment _hostingEnvironment;
		public CityController(IConfiguration configuration,ItblRepository tblRepository,IWebHostEnvironment hostingEnvironment)
		{
		Configuration = configuration;
	_tblRepository = tblRepository;
		
            _hostingEnvironment = hostingEnvironment;}
		[HttpPost("CreateCity")]
		public IActionResult City(City_Model TBL)
		{
		if (!ModelState.IsValid)
		{
			var message = string.Join(" | ", ModelState.Values
			 .SelectMany(v => v.Errors)
			.Select(e => e.ErrorMessage));
			return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
		}
		else
		{
				if (TBL.CityId == 0 || TBL.CityId == null)
				{
                    var data = _tblRepository.Insert_City(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
				else
				{
                    var data = _tblRepository.Insert_City(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            
		}}
	
		[HttpGet("GetCity")]
		public async Task<IActionResult> Get_City()
		{
		if (!ModelState.IsValid)
		{
			var message = string.Join(" | ", ModelState.Values
 .SelectMany(v => v.Errors)
.Select(e => e.ErrorMessage));
			return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
		}
		else
		{
			List<City_Model> lst =await  _tblRepository.Getall_City(new City_Model());
		var jsonres = JsonConvert.SerializeObject(lst);
		
		return Ok(jsonres);
		
}
		
}[HttpPost("SearchCity")]
        public async Task<IActionResult> Search_City([FromBody]City_Model BL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<City_Model> lst = await _tblRepository.Search_City(BL);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpDelete("DeleteCity")]
       
        public async Task<IActionResult> Delete_City(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data =_tblRepository.Delete_City(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

		[HttpGet("GetByIDCity")]
       
        public async Task<IActionResult> GetByID_City(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
City_Model lst = await _tblRepository.GetCityById(Id);
              var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
         }
        }

}
}
