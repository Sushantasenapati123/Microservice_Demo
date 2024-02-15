using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using proj.Model.Company;
//using City.MicroService.API.Interfaces;
using Company.MicroService.API.Interfaces;
namespace Company.MicroService.API
{

 [ApiController]
 [Route("Api/[controller]")]
 public class CompanyController : ControllerBase
 {
 	 
		public IConfiguration Configuration;
		private readonly IspRepository _spRepository;
        private IWebHostEnvironment _hostingEnvironment;
		public CompanyController(IConfiguration configuration,IspRepository spRepository,IWebHostEnvironment hostingEnvironment)
		{
		Configuration = configuration;
	_spRepository = spRepository;
		
            _hostingEnvironment = hostingEnvironment;}
		[HttpPost("CreateCompany")]
		public IActionResult Company(Company_Model TBL)
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
				if (TBL.CompanyID == 0 || TBL.CompanyID == null)
				{
                    var data = _spRepository.Insert_Company(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
				else
				{
                    var data = _spRepository.Insert_Company(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            
		}}
	
		[HttpGet("GetCompany")]
		public async Task<IActionResult> Get_Company()
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
			List<Company_Model> lst =await  _spRepository.Getall_Company(new Company_Model());
		var jsonres = JsonConvert.SerializeObject(lst);
		
		return Ok(jsonres);
		
}
		
}[HttpPost("SearchCompany")]
        public async Task<IActionResult> Search_Company([FromBody]Company_Model BL)
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
                List<Company_Model> lst = await _spRepository.Search_Company(BL);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpDelete("DeleteCompany")]
       
        public async Task<IActionResult> Delete_Company(int Id)
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
                var data =_spRepository.Delete_Company(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

		[HttpGet("GetByIDCompany")]
       
        public async Task<IActionResult> GetByID_Company(int Id)
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
Company_Model lst = await _spRepository.GetCompanyById(Id);
              var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
         }
        }

}
}
