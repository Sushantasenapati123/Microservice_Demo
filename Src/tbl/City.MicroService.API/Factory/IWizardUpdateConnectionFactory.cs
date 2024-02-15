using System.Data;

namespace City.MicroService.API.Factory
{
     public interface IWizardUpdateConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
