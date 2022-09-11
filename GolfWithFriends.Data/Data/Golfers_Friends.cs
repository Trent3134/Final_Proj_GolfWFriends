using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Golfers_Friends
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string GolferId { get; set; }
    public string FriendId { get; set; }

    [ForeignKey(nameof(FriendId))]
    public Golfers GolfersFriend { get; set; }

    [ForeignKey(nameof(GolferId))]
    public Golfers GolfersUser { get; set; }
    //public List<Challenge> Challenge { get; set; }

}

