using Samples.Linq2Sql.NetFramework.Implementations;
using System;
using System.Configuration;

namespace Samples.Linq2Sql.NetFramework
{

    internal class Program
    {
        static void Main(string[] args)
        {

            var connectionString = ConfigurationSettings.AppSettings["ConnectionString"];

            //var builder = new SqlConnectionStringBuilder();
            //builder.DataSource = @"AA7\SQL22";
            //builder.InitialCatalog = "Linq2SqlTest";
            //builder.UserID = "sa";
            //builder.Password = "XXXX";

            using (var context = new DbContext(connectionString))
            {
                if (!context.DatabaseExists())
                {
                    context.CreateDatabase();
                }

                var commandInvoker = new CommandInvoker(context, new CommandParcer());
                commandInvoker.Run();
            }


            Console.WriteLine("Application is exit");
            Console.ReadKey();
        }
    }
}