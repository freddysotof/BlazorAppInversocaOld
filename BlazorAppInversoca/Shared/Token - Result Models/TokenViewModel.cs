using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorAppInversoca.Shared.Token___Result_Models
{
    public class TokenViewModel
    {
        // Clave secrera del Token
        public string SecretKey { get; set; } = "7475AmhsaMarina@@";
        // Quien recibe el Token
        public string AudienceToken { get; set; } = "https://localhost:51663/";
        // Quien recibe el Token
        public string IssuerToken { get; set; } = "https://localhost:51663/";
        // Quien recibe el Token
        public string ExpireTime { get; set; } = "2";
    }
}
