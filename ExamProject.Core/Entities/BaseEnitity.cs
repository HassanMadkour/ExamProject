using ExamProject.Application.Interfaces.IEntity;

namespace ExamProject.Domain.Entities {

    public class BaseEnitity : IBaseEntity {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool isUpdated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }
    }
}