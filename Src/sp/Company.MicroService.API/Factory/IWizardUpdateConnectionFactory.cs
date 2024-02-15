using System.Data;

namespace Company.MicroService.API.Factory
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
