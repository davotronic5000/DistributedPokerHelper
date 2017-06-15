using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistributedPokerHelper.Entities
{
    [Table("Tournament")]
    public class TournamentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Index(IsUnique = true), MaxLength(450)]
        public string Name { get; set; }

        public virtual ICollection<TableEntity> GameTables { get; set; }

        public ICollection<BlindRoundEntity> FinishedBlindRounds { get; set; }

        public BlindRoundEntity CurrentBlindRound { get; set; }
    }
}