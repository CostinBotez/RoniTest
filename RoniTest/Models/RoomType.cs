using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoniTest.Models
{
    [Table("RX_RoomType")]
    public class RoomType
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
