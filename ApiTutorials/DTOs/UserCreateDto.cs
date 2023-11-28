using ApiTutorials.Enums;

namespace ApiTutorials.DTOs
{
    public class UserCreateDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Age { get; set; } = default!;
        public Role Role { get; set; } = default!;
    }
}
