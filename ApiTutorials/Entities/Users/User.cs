using ApiTutorials.Enums;
using System.Text.Json.Serialization;

namespace ApiTutorials.Entities.Users
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Age { get; set; } = default!;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; } = default!;
    }
}