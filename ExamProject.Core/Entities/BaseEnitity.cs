namespace ExamProject.Domain.Entities {

    public class BaseEnitity {
        public int ID { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool isUpdated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}