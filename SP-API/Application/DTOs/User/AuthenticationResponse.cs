using System.Text.Json.Serialization;

namespace Application.DTOs.User
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWTToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
