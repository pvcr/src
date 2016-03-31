using PVCR.DragDropExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Model
{
    
        public class TVReviewModel
        {
            [DbColumn("name")]
            public string Name { get; set; }

            [DbColumn("method_Number")]
            public string MethodNumber { get; set; }

            [DbColumn("samples_Per_Method_No")]
            public int Count { get; set; }
        }
   
}
