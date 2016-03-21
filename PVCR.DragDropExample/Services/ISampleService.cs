using PVCR.DragDropExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Services
{
    public interface ISampleService
    {
        IEnumerable<SampleModel> GetAllSamples();

        IEnumerable<SampleModel> GetRedSamples();

        IEnumerable<SampleModel> GetYellowSamples();

        IEnumerable<SampleModel> GetGreenSamples();


    }
}
