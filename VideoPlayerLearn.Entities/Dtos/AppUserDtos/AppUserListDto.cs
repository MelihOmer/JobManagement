using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string? ExtensionNo { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
