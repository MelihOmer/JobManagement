using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Models
{
    public class UserRoleWithRoles
    {
        public List<RoleAssignListModel> Roles { get; set; }
        public int UserId { get; set; }
        public AppUser User{ get; set; }
    }
}
