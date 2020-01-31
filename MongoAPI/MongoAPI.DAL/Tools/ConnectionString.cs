using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.DAL.Tools
{
    public class ConnectionString
    {
        private static ConnectionString instance;

        private ConnectionString() { }

        public static ConnectionString GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionString();
                }
                return instance;
            }
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MongoStringConnection"].ToString();
        }
    }
}
