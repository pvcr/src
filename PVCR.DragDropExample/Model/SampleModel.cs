using PVCR.DragDropExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Model
{
    public class SampleModel
    {
        [DbColumn("X_METHOD_NUMBER")]
        public string MethodName { get; set; }

        public int Count { get; set; }

        [DbColumn("PRODUCTION_DATE")]
        public DateTime? ProductionDate { get; set; }


    }
}
