using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistributedPokerHelper.Entities
{
    [Table("GameTable")]
    public class TableEntity
    {
        [Key]
        public int Id { get; set; }

        public ICollection<PlayerEntity> Players { get; set; }
    }
}