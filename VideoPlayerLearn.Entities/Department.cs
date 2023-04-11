using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class Department :BaseEntity
    {
        public string Decription { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
