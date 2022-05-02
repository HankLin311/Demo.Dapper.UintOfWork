using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Base
{
    public abstract class OracleConnBase
    {
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transction { get; set; }

        public OracleConnBase(IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:OracleConnectionString"].ToString();
            Connection = new OracleConnection(connectionString);
            Connection.Open();
            Transction = Connection.BeginTransaction();
        }
    }
}
