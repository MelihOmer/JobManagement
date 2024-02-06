using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class EducationCategory:BaseEntity
    {
        public string Title { get; set; }
        public List<Education> Educations { get; set; }
    }
}
