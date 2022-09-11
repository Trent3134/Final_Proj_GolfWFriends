using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Challenges
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string ChallengeId { get; set; }
    public string Challenge2Id { get; set; }

    [ForeignKey(nameof(ChallengeId))]
    public Golfers GolfersFriend { get; set; }

    [ForeignKey(nameof(Challenge2Id))]
    public Golfers GolfersUser { get; set; }



}

