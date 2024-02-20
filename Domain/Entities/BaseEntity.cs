using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        private static int _idCounter = 1;
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        protected BaseEntity()
        {
            Id = GetNextId();
            CreatedAt = DateTime.UtcNow;
        }
        private static int GetNextId()
        {
            return _idCounter++;
        }
    }
    
}
