using System;
using System.ComponentModel.DataAnnotations;

namespace SHS.Domain.Core.Interfaces
{
    public class BaseEntity
    {
        private Guid id { get; set; }
        [Key]
        public Guid ID
        {
            get { return id; }
            set
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    id = value;
                }
                else
                {
                    id = Guid.NewGuid();
                }
            }
        }

        public long Sort { get; set; }
        public int IsDel { get; set; }

        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }

        public Guid UpdateUserId { get; set; }

        public DateTime UpdateDate { get; set; }

        public Guid DeleteUserId { get; set; }

        public DateTime DeleteDate { get; set; }
        public string Remarks { get; set; }
    }
}
