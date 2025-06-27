using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProject.Domain.Entities;
using ExamProject.Application.DTOs.QuestionDTOs;

namespace ExamProject.Application.DTOs.AdminDTOs
{
    public class GetExamDTO
    {
        public string Name { get; set; }

        public short MinDegree { get; set; }

        public short MaxDegree { get; set; }

        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public int QuestionOfNumber { get; set; }
        public virtual ICollection<QuestionDTO> Questions { get; set; }

    }
}
