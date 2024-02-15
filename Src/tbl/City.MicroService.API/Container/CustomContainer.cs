using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using City.MicroService.API.Factory;
using City.MicroService.API.Repository;
using City.MicroService.API.Interfaces;
namespace City.MicroService.API.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
		IWizardUpdateConnectionFactory WizardUpdateconnectionFactory=new WizardUpdateConnectionFactory(configuration.GetConnectionString("DBconnectionWizardUpdate"));
		services.AddSingleton<IWizardUpdateConnectionFactory> (WizardUpdateconnectionFactory);

		services.AddScoped<ItblRepository, tblRepository>();
			//Write code here
		}
	}
}
