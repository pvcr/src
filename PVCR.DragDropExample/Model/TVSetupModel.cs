using PVCR.DragDropExample.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Model
{
    public class TVSetupModel
    {
        [DbColumn("name")]
        public string Name { get; set; }

        [DbColumn("method_Number")]
        public string MethodNumber { get; set; }

        [DbColumn("total_results_Count")]
        public int TotalResultCount { get; set; }

        [DbColumn("completed_Results_Count")]
        public int CompletedResultCount { get; set; }

        [DbColumn("samples_Per_Method_No")]
        public int Count { get; set; }

        public string InstrumentName { get; set; }
    }
}
