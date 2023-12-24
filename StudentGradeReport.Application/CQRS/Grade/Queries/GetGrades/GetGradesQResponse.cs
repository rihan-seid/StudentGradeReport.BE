
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrades
{
    public class GetGradesQResponse
    {
        public int Total { get; set; }
        public List<Data.Entities.Grade> Grades { get; set; }
    }
}
