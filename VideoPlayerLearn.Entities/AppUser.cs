using Microsoft.AspNetCore.Identity;

namespace VideoPlayerLearn.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string ImagePath { get; set; }
        public Department Department { get; set; }
        public List<Todo> Todos { get; set; }
        public List<Todo> AssignedTodos { get; set; }
        public List<TodoComment> TodoComments { get; set; }
        public List<Education> Educations{ get; set; }
        public List<TodoViewsUser> TodoViewsUsers { get; set; }
        public List<ClientNotification> ClientNotifications { get; set; }
        public List<ClientNotification> NotifyAssignedToUser { get; set; }
        public string? ExtensionNo { get; set; }

    }
}
