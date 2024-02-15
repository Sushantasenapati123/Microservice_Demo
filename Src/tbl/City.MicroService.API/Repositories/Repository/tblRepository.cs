using System.Collections.Generic;
using City.MicroService.API.Factory;
using City.MicroService.API.BaseRepository;
using City.MicroService.API.Interfaces;
using City.MicroService.API;

using proj.Model.City;
using Dapper;
using System.Data;
namespace City.MicroService.API.Repository
{
	public class tblRepository:WizardUpdateRepositoryBase,ItblRepository
	{
		public tblRepository(IWizardUpdateConnectionFactory WizardUpdateConnectionFactory) : base(WizardUpdateConnectionFactory)
        {

        }
		 public async Task<int> Insert_City(City_Model TBL)
	{
		var p = new DynamicParameters();
		if(TBL.CityId == 0 )
		{
			p.Add("@P_Action", "I");
			p.Add("@P_CityId",0);
		}
		else
		{
			p.Add("@P_Action", "U");
			p.Add("@P_CityId",TBL.CityId);
		}
		p.Add("@P_CityName",TBL.CityName);
		p.Add("@P_Extra",TBL.Extra);
		p.Add("@P_Extra1",TBL.Extra1);
		var results = await Connection.ExecuteAsync("USP_City_Copy_4", p, commandType: CommandType.StoredProcedure);		
return 1;

		} 
	public async Task<int> Delete_City(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "D");
			p.Add("@P_CityId",Id);
		
		var results = await Connection.ExecuteAsync("USP_City_Copy_4", p, commandType: CommandType.StoredProcedure);
		return results;

		} 
	public async Task<City_Model> GetCityById(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "E");
			p.Add("@P_CityId",Id);
		
		var results = await Connection.QueryAsync<City_Model>("USP_City_Copy_4", p, commandType: CommandType.StoredProcedure);
		return results.FirstOrDefault();

		} 
	public async Task<List<City_Model>> Getall_City(City_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "V");
		var results = await Connection.QueryAsync<City_Model>("USP_City_Copy_4",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	public async Task<List<City_Model>> Search_City(City_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "S");
			p.Add("@P_CityId",TBL.CityId);
		
		p.Add("@P_CityName",TBL.CityName);
		p.Add("@P_Extra",TBL.Extra);
		p.Add("@P_Extra1",TBL.Extra1);
		var results = await Connection.QueryAsync<City_Model>("USP_City_Copy_4",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	
}
}
