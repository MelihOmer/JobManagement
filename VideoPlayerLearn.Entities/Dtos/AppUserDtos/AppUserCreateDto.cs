namespace VideoPlayerLearn.Entities.Dtos
{
    public class AppUserCreateDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string? ExtensionNo { get; set; }
        public string ImagePath { get; set; } = "/defaultUser.jpg";
    }
}
