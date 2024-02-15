using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;

using Company.MicroService.API.Factory;
using Company.MicroService.API.Repository;
using Company.MicroService.API.Interfaces;
namespace Company.MicroService.API.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
		IWizardUpdateConnectionFactory WizardUpdateconnectionFactory=new WizardUpdateConnectionFactory(configuration.GetConnectionString("DBconnectionWizardUpdate"));
		services.AddSingleton<IWizardUpdateConnectionFactory> (WizardUpdateconnectionFactory);

		services.AddScoped<IspRepository, spRepository>();
			//Write code here
		}
	}
}
