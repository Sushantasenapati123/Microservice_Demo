using System.Collections.Generic;
using Company.MicroService.API.Factory;
using Company.MicroService.API.BaseRepository;
using Company.MicroService.API.Interfaces;
using Company.MicroService.API;

using proj.Model.Company;
using Dapper;
using System.Data;
namespace Company.MicroService.API.Repository
{
	public class spRepository:WizardUpdateRepositoryBase,IspRepository
	{
		public spRepository(IWizardUpdateConnectionFactory WizardUpdateConnectionFactory) : base(WizardUpdateConnectionFactory)
        {

        }
		 public async Task<int> Insert_Company(Company_Model TBL)
	{
		var p = new DynamicParameters();
		if(TBL.CompanyID == 0 )
		{
			p.Add("@P_Action", "I");
			p.Add("@P_CompanyID",0);
		}
		else
		{
			p.Add("@P_Action", "U");
			p.Add("@P_CompanyID",TBL.CompanyID);
		}
		p.Add("@P_ComanyName",TBL.ComanyName);
		p.Add("@P_CompanyAddress",TBL.CompanyAddress);
		p.Add("@P_CompanyBranch",TBL.CompanyBranch);
		p.Add("@P_CompanyDocument",TBL.CompanyDocument);
		var results = await Connection.ExecuteAsync("USP_Company", p, commandType: CommandType.StoredProcedure);		
return 1;

		} 
	public async Task<int> Delete_Company(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "D");
			p.Add("@P_CompanyID",Id);
		
		var results = await Connection.ExecuteAsync("USP_Company", p, commandType: CommandType.StoredProcedure);
		return results;

		} 
	public async Task<Company_Model> GetCompanyById(int Id)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "E");
			p.Add("@P_CompanyID",Id);
		
		var results = await Connection.QueryAsync<Company_Model>("USP_Company", p, commandType: CommandType.StoredProcedure);
		return results.FirstOrDefault();

		} 
	public async Task<List<Company_Model>> Getall_Company(Company_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "V");
		var results = await Connection.QueryAsync<Company_Model>("USP_Company",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	public async Task<List<Company_Model>> Search_Company(Company_Model TBL)
	{
				var p = new DynamicParameters();
		p.Add("@P_Action", "S");
			p.Add("@P_CompanyID",TBL.CompanyID);
		
		p.Add("@P_ComanyName",TBL.ComanyName);
		p.Add("@P_CompanyAddress",TBL.CompanyAddress);
		p.Add("@P_CompanyBranch",TBL.CompanyBranch);
		p.Add("@P_CompanyDocument",TBL.CompanyDocument);
		var results = await Connection.QueryAsync<Company_Model>("USP_Company",p, commandType: CommandType.StoredProcedure);
		return results.ToList();

		} 
	
}
}
