using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Domain.Models.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }

        public BaseModel()
        {
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
            IsArchived = false;
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
            IsActive = false;
            IsArchived = false;
        }

        public void Archive()
        {
            IsDeleted = false;
            IsActive = false;
            IsArchived = true;
        }

        public void DeActivate()
        {
            IsDeleted = false;
            IsActive = false;
            IsArchived = false;
        }

        public void Activate()
        {
            IsDeleted = false;
            IsActive = true;
            IsArchived = false;
        }
    }
}
