using System;
using System.Collections.Generic;
using System.Text;

namespace OwnFramework.DataReader
{
    public class Servers
    {
        private static T getServers<T>() where T : new()
        {
            var servers = new T();
            return servers;
        }
        public static DataReader general
        {
            get { return getServers<DataReader>(); }
        }
    }
}
