using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistributedPokerHelper.Entities
{
    [Table("BlindRound")]
    public class BlindRoundEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int TotalInSeconds { get; set; }
    }
}