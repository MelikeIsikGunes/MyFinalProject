using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{ //Jason Web Token - JWT
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } //bitiş zamanı-Tokenin ne zamana kadar geçerli olduğu bilgisi
    }
}
