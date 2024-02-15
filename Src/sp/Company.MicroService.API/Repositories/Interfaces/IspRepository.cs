using System.Collections.Generic;

using proj.Model.Company;
namespace Company.MicroService.API.Interfaces
{
  public interface IspRepository
  {
  	 
        Task<int> Insert_Company(Company_Model TBL);
        Task<int> Delete_Company(int Id);
        Task<Company_Model> GetCompanyById(int Id);
        Task<List<Company_Model>> Search_Company(Company_Model TBL);
        Task<List<Company_Model>> Getall_Company(Company_Model TBL);
}
}
