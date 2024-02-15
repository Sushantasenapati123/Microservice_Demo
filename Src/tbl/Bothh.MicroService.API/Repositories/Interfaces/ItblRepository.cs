using System.Collections.Generic;

using proj.Model.Bothh;
namespace Bothh.MicroService.API.Interfaces
{
  public interface ItblRepository
  {
  	 
        Task<int> Insert_Bothh(Bothh_Model TBL);
        Task<int> Delete_Bothh(int Id);
        Task<Bothh_Model> GetBothhById(int Id);
        Task<List<Bothh_Model>> Search_Bothh(Bothh_Model TBL);
        Task<List<Bothh_Model>> Getall_Bothh(Bothh_Model TBL);
}
}
