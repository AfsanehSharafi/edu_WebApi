using Application.Dtos.Common;

namespace Application.Dtos
{
    public class UserDto:BaseDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
