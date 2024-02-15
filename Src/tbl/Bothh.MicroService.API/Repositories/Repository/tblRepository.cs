using System.Collections.Generic;
using Bothh.MicroService.API.Factory;
using Bothh.MicroService.API.BaseRepository;
using Bothh.MicroService.API.Interfaces;
using Bothh.MicroService.API;

using proj.Model.Bothh;
using Dapper;
using System.Data;
namespace Bothh.MicroService.API.Repository
{
	public class tblRepository:WizardUpdateRepositoryBase,ItblRepository
	{
		public tblRepository(IWizardUpdateConnectionFactory WizardUpdateConnectionFactory) : base(WizardUpdateConnectionFactory)
        {

        }
		 public async Task<int> Insert_Bothh(Bothh_Model TBL)
	{
		var p = new DynamicParameters();
		if(TBL.DistId == 0 )
		{
			p.Add("@P_Action", "I");
			p.Add("@P_DistId",0);
		}
		else
		{
			p.Add("@P_Action", "U");
			p.Add("@P_DistId",TBL.DistId);
		}
		p.Add("@P_StateName",TBL.StateName);
		p.Add("@P_DistName",TBL.DistName);
		var results = await Connection.ExecuteAsync("USP_Bothh_Copy_2 ", p, commandType: CommandType.StoredProcedure);		
return 1;

		} 
	public async Task<int> Delete_Bothh(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "D");
			p.Add("@P_DistId",Id);
		
		var results = await Connection.ExecuteAsync("USP_Bothh_Copy_2 ", p, commandType: CommandType.StoredProcedure);
		return results;

		} 
	public async Task<Bothh_Model> GetBothhById(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "E");
			p.Add("@P_DistId",Id);
		
		var results = await Connection.QueryAsync<Bothh_Model>("USP_Bothh_Copy_2 ", p, commandType: CommandType.StoredProcedure);
		return results.FirstOrDefault();

		} 
	public async Task<List<Bothh_Model>> Getall_Bothh(Bothh_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "V");
		var results = await Connection.QueryAsync<Bothh_Model>("USP_Bothh_Copy_2 ",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	public async Task<List<Bothh_Model>> Search_Bothh(Bothh_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "S");
			p.Add("@P_DistId",TBL.DistId);
		
		p.Add("@P_StateName",TBL.StateName);
		p.Add("@P_DistName",TBL.DistName);
		var results = await Connection.QueryAsync<Bothh_Model>("USP_Bothh_Copy_2 ",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	
}
}
