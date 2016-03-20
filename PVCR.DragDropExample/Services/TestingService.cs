using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVCR.DragDropExample.Model;
using PVCR.DragDropExample.DB;
using System.Data;

namespace PVCR.DragDropExample.Services
{
    public class TestingService : ITestingService
    {
        private const string QUERY = @"SELECT 	b.name, t.x_method_number, count(bo.sample_number) as [count]
	                                    FROM  	batch b, 
      		                                    batch_objects bo, 
      		                                    sample s, 
      		                                    test t
	                                    WHERE 	b.name = bo.batch and 
      		                                    bo.sample_type = 'SAMPLE' and
      		                                    bo.sample_number = s.sample_number  and
      		                                    s.sample_number  = t.sample_number and
      		                                    s.status in ('I','P') and t.status in ('I','P')
	                                    GROUP BY b.name, t.x_method_number
	                                    ORDER BY count(bo.sample_number) desc";

        
        public IEnumerable<TestingModel> GetAllTestings()
        {
            SqlDataAccessHelper sqlHelper = new SqlDataAccessHelper();

            using (var reader = sqlHelper.ExecuteReader(QUERY, CommandType.Text, null))
            {
                var mapper = new DataReaderMapper<TestingModel>(reader);
                yield return mapper.MapFrom(reader);
            }
        }
    }
}
