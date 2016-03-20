using PVCR.DragDropExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Services
{
    public interface IWriteupService
    {
        IEnumerable<WriteupModel> GetAllWriteups();
    }
}
