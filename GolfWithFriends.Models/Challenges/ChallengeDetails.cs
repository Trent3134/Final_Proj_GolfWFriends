using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ChallengeDetails
    {
    public int ChallengeId { get; set; }
    public string GolferA { get; set; }
    public string Text { get; set; }
    public Golfers_Friends GolferAInfo { get; set; }

    public string GolferB { get; set; }
    public GolferDetails GolferBInfo { get; set; }

}

