using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamProject.Application.DTOs.QuestionDTOs;

namespace ExamProject.Application.DTOs.AdminDTOs
{
    public class ExamUpdateDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [Range(1, 999)]
        public short MinDegree { get; set; }

        [Range(1, 1000)]
        public short MaxDegree { get; set; }

        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
