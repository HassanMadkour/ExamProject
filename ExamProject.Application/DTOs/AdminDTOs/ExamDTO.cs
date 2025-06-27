using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.DTOs.AdminDTOs
{
    public class ExamDTO
    {
        public string Name { get; set; }

        public short MinDegree { get; set; }

        public short MaxDegree { get; set; }

        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public int QuestionOfNumber { get; set; }
    }
}
