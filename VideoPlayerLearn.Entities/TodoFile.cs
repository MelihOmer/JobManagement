using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Entities
{
    public class TodoFile : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TodoId { get; set; }
        public Todo Todo { get; set; }
        public string RealFileName { get; set; }
    }
}
