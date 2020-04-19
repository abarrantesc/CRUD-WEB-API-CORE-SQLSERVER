using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Data
{
    public class SQLconnection
    {
        public SqlConnection conectarbd = new SqlConnection();
        public string cadena = "Data Source=.;Initial Catalog=AdventureWorks2017;Integrated Security=True";

     
        public SQLconnection()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            conectarbd.ConnectionString = root.GetConnectionString("DefaultConnection");
        }

        public void ConnOpen()
        {
            try
            {
                conectarbd.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ConnClose()
        {
            try
            {
                conectarbd.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
