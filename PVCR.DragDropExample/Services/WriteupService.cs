﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVCR.DragDropExample.Model;
using PVCR.DragDropExample.DB;
using System.Data;

namespace PVCR.DragDropExample.Services
{
    public class WriteupService : IWriteupService
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


        private const string QUERY1 = @"SELECT     b.name,
                                                   substring(t.x_method_number,1,20) method_Number,
                                                   count (r.result_number) total_results_Count ,
                                                   count( case when r.status in ('A','M','E') then 1 else null end)  completed_Results_Count,
                                                   count(distinct bo.sample_number) samples_Per_Method_No
                                        FROM      batch b,
                                                  batch_objects bo,
                                                  sample s,
                                                  test t, result r
                                        WHERE     b.name = bo.batch and
                                                  bo.sample_type = 'SAMPLE' and
                                                  bo.sample_number = s.sample_number  and
                                                  s.sample_number  = t.sample_number and t.test_number = r.test_number and
                                                  s.status in ('I','P') and t.status in ('I','P') and bo.batch = 'L16-AQUAL-009'
                                    GROUP BY b.name, t.x_method_number
                                    ORDER BY b.name,  count(bo.sample_number) desc";


        private const string QUERY2 = @"SELECT     b.name,
                                                   substring(t.x_method_number,1,20) method_Number,
                                                   count (r.result_number) total_results_Count ,
                                                   count( case when r.status in ('A','M','E') then 1 else null end)  completed_Results_Count,
                                                   count(distinct bo.sample_number) samples_Per_Method_No
                                        FROM      batch b,
                                                  batch_objects bo,
                                                  sample s,
                                                  test t, result r
                                        WHERE     b.name = bo.batch and
                                                  bo.sample_type = 'SAMPLE' and
                                                  bo.sample_number = s.sample_number  and
                                                  s.sample_number  = t.sample_number and t.test_number = r.test_number and
                                                  s.status in ('I','P') and t.status in ('I','P') and bo.batch = 'L16-AQUAL-008'
                                    GROUP BY b.name, t.x_method_number
                                    ORDER BY b.name,  count(bo.sample_number) desc";

        public IEnumerable<WriteupModel> GetAllWriteups()
        {
            SqlDataAccessHelper sqlHelper = new SqlDataAccessHelper();

            using (var reader = sqlHelper.ExecuteReader(QUERY, CommandType.Text, null))
            {
                var mapper = new DataReaderMapper<WriteupModel>(reader);
                while (reader.Read())
                    yield return mapper.MapFrom(reader);
            }
        }
    }
}
