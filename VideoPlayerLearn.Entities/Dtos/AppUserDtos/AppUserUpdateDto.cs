using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Entities.Dtos
{
    public class AppUserUpdateDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public string ImagePath { get; set; }
        public string ExtensionNo { get; set; }

    }
}
