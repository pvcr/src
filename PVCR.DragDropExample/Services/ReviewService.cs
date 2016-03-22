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
    public class ReviewService : IReviewService
    {
        private const string QUERY = @"select substring(i.name,1,20) Investigation_Name,
                                          i.type Investigation_type,
                                          s.lot sampleLot,
                                          count(io.object_id) sample_count
                                from investigation i,
                                        invest_objects io ,
                                        sample s
                                where i.name  = io.investigation and
                                         io.object_class = 'SAMPLE' and
                                         io.object_id = s.sample_number
                                group by i.name, i.type, s.lot
                                order by i.name, count(io.object_id) desc";

        public IEnumerable<ReviewModel> GetAllWriteups()
        {
            SqlDataAccessHelper sqlHelper = new SqlDataAccessHelper();

            using (var reader = sqlHelper.ExecuteReader(QUERY, CommandType.Text, null))
            {
                var mapper = new DataReaderMapper<ReviewModel>(reader);
                while (reader.Read())
                    yield return mapper.MapFrom(reader);
            }
        }
    }
}
