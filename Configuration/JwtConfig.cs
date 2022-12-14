using System;
namespace ConsumptionAPI
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
