
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hotel
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "http://localhost:52217/"; 
        const string KEY = "RelexPractice1234";   
        public const int LIFETIME = 100; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
