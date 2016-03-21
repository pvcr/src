using PVCR.DragDropExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Model
{
    public  class TestingModel
    {
        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("x_method_number")]
        public string MethodNumber { get; set; }

        [DbColumn("count")]
        public int Count { get; set; }
    }
}
