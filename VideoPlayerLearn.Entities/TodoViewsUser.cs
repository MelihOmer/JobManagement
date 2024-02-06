using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class TodoViewsUser:BaseEntity
    {
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
    }
}
