using System.Collections.Generic;

using proj.Model.City;
namespace City.MicroService.API.Interfaces
{
  public interface ItblRepository
  {
  	 
        Task<int> Insert_City(City_Model TBL);
        Task<int> Delete_City(int Id);
        Task<City_Model> GetCityById(int Id);
        Task<List<City_Model>> Search_City(City_Model TBL);
        Task<List<City_Model>> Getall_City(City_Model TBL);
}
}
