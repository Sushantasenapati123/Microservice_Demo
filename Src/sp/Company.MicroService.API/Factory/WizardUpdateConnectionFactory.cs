using System.Data;
using System.Data.SqlClient ;
namespace Company.MicroService.API.Factory
{
    public class WizardUpdateConnectionFactory:IWizardUpdateConnectionFactory
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public WizardUpdateConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        public IDbConnection GetConnection => new SqlConnection(_connectionString);
    }
}
