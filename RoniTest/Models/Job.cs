using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoniTest.Models
{
    [Table("RX_Job")]
    public class Job
    {
        public Guid ID { get; set; }

        public int? ContractorID { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int? Floor { get; set; }

        public int? Room { get; set; }

        public string DelayReason { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateCompleted { get; set; }

        public DateTime? DateDelayed { get; set; }

        public int? StatusNum { get; set; }

        public int? RJobID { get; set; }

        public Guid? RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }
    }
}
