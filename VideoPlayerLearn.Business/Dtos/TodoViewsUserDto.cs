using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPlayerLearn.Business.Dtos
{
    public class TodoViewsUserDto
    {
        public int Todo { get; set; }
        public int Kullanici { get; set; }
        public int Sayi { get; set; }
        public string? FullName { get; set; }
        public string? ImagePath { get; set; }
    }
}
