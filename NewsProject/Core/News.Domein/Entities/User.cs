using Microsoft.AspNetCore.Identity;
using News.Domain.Comman;

namespace News.Domain.Entities
{
    public sealed class User : IdentityUser<int>, IEntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
