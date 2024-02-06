using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Common;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface IDepartmentService :IService<Department>
    {
        List<Department> DepartmentList();
    }
}
