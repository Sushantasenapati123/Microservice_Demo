using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using proj.Model.Bothh;
using Bothh.MicroService.API.Interfaces;
namespace Bothh.MicroService.API
{

 [ApiController]
 [Route("Api/[controller]")]
 public class BothhController : ControllerBase
 {
 	 
		public IConfiguration Configuration;
		private readonly ItblRepository _tblRepository;
        private IWebHostEnvironment _hostingEnvironment;
		public BothhController(IConfiguration configuration,ItblRepository tblRepository,IWebHostEnvironment hostingEnvironment)
		{
		Configuration = configuration;
	_tblRepository = tblRepository;
		
            _hostingEnvironment = hostingEnvironment;}
		[HttpPost("CreateBothh")]
		public IActionResult Bothh(Bothh_Model TBL)
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
				if (TBL.DistId == 0 || TBL.DistId == null)
				{
                    var data = _tblRepository.Insert_Bothh(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
				else
				{
                    var data = _tblRepository.Insert_Bothh(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            
		}}
	
		[HttpGet("GetBothh")]
		public async Task<IActionResult> Get_Bothh()
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
			List<Bothh_Model> lst =await  _tblRepository.Getall_Bothh(new Bothh_Model());
		var jsonres = JsonConvert.SerializeObject(lst);
		
		return Ok(jsonres);
		
}
		
}[HttpPost("SearchBothh")]
        public async Task<IActionResult> Search_Bothh([FromBody]Bothh_Model BL)
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
                List<Bothh_Model> lst = await _tblRepository.Search_Bothh(BL);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpDelete("DeleteBothh")]
       
        public async Task<IActionResult> Delete_Bothh(int Id)
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
                var data =_tblRepository.Delete_Bothh(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

		[HttpGet("GetByIDBothh")]
       
        public async Task<IActionResult> GetByID_Bothh(int Id)
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
Bothh_Model lst = await _tblRepository.GetBothhById(Id);
              var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
         }
        }

}
}
