using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendCase.DAO;
using LinqToDB;
using LinqToDB.Configuration;

namespace BackendCase.DataAccess
{
    public class DataContext : LinqToDB.Data.DataConnection
    {
        public DataContext() : base("db") { }
        public ITable<FilmDAO> Films => this.GetTable<FilmDAO>();
        public ITable<SalonDAO> Salons => this.GetTable<SalonDAO>();
        public ITable<GosterimDAO> Shows => this.GetTable<GosterimDAO>();


        public class DBContextSettings : LinqToDB.Configuration.ILinqToDBSettings
        {
            public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<LinqToDB.Configuration.IDataProviderSettings>();

            public string DefaultConfiguration => "SqlServer";

            public string DefaultDataProvider => "SqlServer";

            public IEnumerable<IConnectionStringSettings> ConnectionStrings
            {
                get
                {
                    yield return
                        new ConnectionStringSettings
                        {
                            Name = "db",
                            ProviderName = LinqToDB.ProviderName.SqlServer2019,
                            ConnectionString = @"Data Source=localhost;Initial Catalog=moviedb;Integrated Security=True;TrustServerCertificate=True"
                        };
                }
            }

            public class ConnectionStringSettings : LinqToDB.Configuration.IConnectionStringSettings
            {
                public string ConnectionString { get; set; }
                public string Name { get; set; }
                public string ProviderName { get; set; }
                public bool IsGlobal => false;
            }
        }
    }
}
