﻿using Microsoft.Data.SqlClient;
using System.Data;


namespace Pusdafi_Dev.Models.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        
        public DapperDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionString = this._configuration.GetConnectionString("DefaultConn");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
