using PVCR.DragDropExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Model
{
    public class WriteupModel
    {
        [DbColumn("name")]
        public string Message { get; set; }

        [DbColumn("count")]
        public int Count { get; set; }
    }
}
