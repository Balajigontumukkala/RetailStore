using System;
using System.Collections.Generic;
using System.Text;

namespace RetailStore.ClientConfiguration
{
    public class ClientSettings
    {
        public string CorsOrigins { get; set; }

        public bool RequireHttpsMetadata { get; set; }

        public string AppConnectionString { get; set; }

        public TokenSettings Token { get; set; }

    }
}
