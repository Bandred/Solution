using System;
using System.IdentityModel.Tokens.Jwt;

namespace CrossCutting.Helpers
{
    public class ResponseTokenHelper
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public static ResponseTokenHelper Add(JwtSecurityToken token)
        {
            return new ResponseTokenHelper()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
