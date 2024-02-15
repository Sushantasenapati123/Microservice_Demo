using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using Bothh.MicroService.API.Factory;
using Bothh.MicroService.API.Repository;
using Bothh.MicroService.API.Interfaces;
namespace Bothh.MicroService.API.Container
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
