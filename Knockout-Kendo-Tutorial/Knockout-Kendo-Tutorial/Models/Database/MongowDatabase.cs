using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout_Kendo_Tutorial.Models.Database
{
    public class MongowDatabase
    {
        public MongoDB.Driver.MongoDatabase Database 
        {
            get 
            {
                string connectionString = "mongodb://localhost";
                MongoDB.Driver.MongoServer server = new MongoDB.Driver.MongoClient(connectionString).GetServer();

                return server.GetDatabase("SES_2015");
            } 
        }
    }
}