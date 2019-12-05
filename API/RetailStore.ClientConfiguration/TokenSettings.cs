using System;
using System.Collections.Generic;
using System.Text;

namespace RetailStore.ClientConfiguration
{
    public class TokenSettings
    {
        public string Key { get; set; }
        public int Lifetime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public bool Enable { get; set; }
    }
}
