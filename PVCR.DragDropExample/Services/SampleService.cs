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
    public class SampleService : ISampleService
    {
        private const string QUERY = @"select 
                            distinct s.sample_number, s.status, t.analysis, t.STATUS, t.BATCH, t.X_METHOD_NUMBER, s.X_CAUGHT_ON, s.PRODUCT, l.X_LOT_NAME, s.LOCATION,
                            l.PRODUCTION_DATE, s.SAMPLE_TYPE, a.ANALYSIS_TYPE, s.SPEC_TYPE
                            from LimsUser.SAMPLE s, LimsUser.RESULT r, LimsUser.TEST t, LimsUser.LOT l, ANALYSIS a
                            WHERE s.SAMPLE_NUMBER = t.SAMPLE_NUMBER
                            and t.TEST_NUMBER = r.TEST_NUMBER
                            and a.[NAME] = t.ANALYSIS
                            and a.VERSION = t.VERSION
                            and s.status IN('U','I')
                            and s.LOT = l.LOT_NUMBER
                            and s.sample_type NOT IN ('RAW_MAT','EM')
                            and s.LOCATION NOT IN ('DISCARD','PPD','PAD','CCPD')
                            and a.ANALYSIS_TYPE NOT IN ('PAD', 'MFG','CONTRACT','MICRO')
                            and s.PRODUCT NOT IN ('WATER','MFG_QUAL')
                            and s.spec_type NOT IN('BACKUP','BACKUP2','BACKUP3','SATELLITE')
                            and a.ANALYSIS_TYPE = 'TEST_TECH'
                            and s.sample_number > 1240666";

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

        public IEnumerable<SampleModel> GetAllSamples()
        {
            SqlDataAccessHelper sqlHelper = new SqlDataAccessHelper();

            using (var reader = sqlHelper.ExecuteReader(QUERY, CommandType.Text, null))
            {
                var mapper = new DataReaderMapper<SampleModel>(reader);
                while(reader.Read())
                yield return mapper.MapFrom(reader);
            }
        }

        public IEnumerable<SampleModel> GetGreenSamples()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleModel> GetRedSamples()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleModel> GetYellowSamples()
        {
            throw new NotImplementedException();
        }
    }
}
