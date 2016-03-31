using PVCR.DragDropExample.DB;
using PVCR.DragDropExample.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCR.DragDropExample.Services
{
    
        public class TVReviewService : ITVReviewService
        {
            private const string QUERY = @"SELECT  b.name,
                                        substring(t.x_method_number,1,20) method_Number,
                                        count (r.result_number) total_results_Count ,
                                        count( case when r.status in ('A','M','E') then 1 else null end)  completed_Results_Count,
                                        count(distinct bo.sample_number) samples_Per_Method_No
                                    FROM batch_hdr_template bh,
                                              batch b,
                                              batch_objects bo,
                                              sample s,
                                              test t, result r
                                    WHERE bh.x_lab = 'TEST_TECH' and
                                              bh.name = b.template and
                                              b.name = bo.batch and
                                              bo.sample_type = 'SAMPLE' and
                                              bo.sample_number = s.sample_number  and
                                              s.sample_number  = t.sample_number and t.test_number = r.test_number and
                                              s.status in ('I','P') and t.status in ('I','P')
                                GROUP BY b.name, t.x_method_number
                                ORDER BY b.name,  count(bo.sample_number) desc";


            public IEnumerable<TVReviewModel> GetAllTVReviews()
            {
                SqlDataAccessHelper sqlHelper = new SqlDataAccessHelper();

                using (var reader = sqlHelper.ExecuteReader(QUERY, CommandType.Text, null))
                {
                    var mapper = new DataReaderMapper<TVReviewModel>(reader);
                    while (reader.Read())
                        yield return mapper.MapFrom(reader);
                }
            }
        }
   
}
