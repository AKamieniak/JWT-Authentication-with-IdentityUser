using Microsoft.IdentityModel.Tokens;

namespace JWT.Api
{
    public class Constants
    {
        public const string Secret = "TW9zaGVFcmV6UHJpdmF0ZUtleQ==";
        public const int ExpireMinutes = 10080;
        public const string SecurityAlgorithm = SecurityAlgorithms.HmacSha256Signature;
        public const string Admin = "Admin";
        public const string SuperAdmin = "SuperAdmin";
    }
}
