
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


public class GolferService : IGolferService
{
    private readonly ApplicationDbContext _context;
    private string _userId;
    public GolferService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GolferListItem>> AllGolfers()
    {
        var golfer = await _context.Golfer.Select(g => new GolferListItem
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            Handicap = g.Handicap,
        }).ToListAsync();
        return golfer;
    }
    public async Task<Golfers_Friends> GetFriendById(string Id)
    {
        var friend = await _context.GolferFriends.Include(g => g.GolfersFriend).FirstOrDefaultAsync(g => g.FriendId == Id);
        //var friend = await _context.GolferFriends.FindAsync(friendId);
        if (Id == null)
        {
            return null;
        }
        return new Golfers_Friends
        {
            FriendId = Id,
            //GolfersFriend = friend.GolfersFriend
        };
    }
    public async Task<Golfers_Friends> GetGolferFriendById(string Id)
    {
        var friend = await _context.GolferFriends.Include(g => g.GolfersFriend).FirstOrDefaultAsync(g => g.FriendId == Id);
        return new Golfers_Friends
        {
            FriendId = Id
    
        };
    }

    public async Task<FriendListItem> TextSetById(string id)
    {
        var friend = await _context.Golfer.SingleOrDefaultAsync(g => g.Id == id);
        if (friend == null) return null;
        return new FriendListItem()
        {
            FriendId = friend.Id,
            PhoneNumber = friend.PhoneNumber,
        };
    }


    public async Task<bool> DeleteGolfer(string id)
    {
        var golfer = await _context.Golfer.FindAsync(id);
        if (golfer == null)
        {
            return false;
        }
        _context.Golfer.Remove(golfer);
        await _context.SaveChangesAsync();
        return true;

    }
    public async Task<bool> DeleteFriend(string friendId)
    {
        var friend = await _context.GolferFriends.Include(g => g.GolfersFriend).FirstOrDefaultAsync(f => f.FriendId == friendId);
        if (friendId == null)
        {
            return false;
        }
        _context.GolferFriends.Remove(friend);
        await _context.SaveChangesAsync();
        return true;
    }
  

    public async Task<GolferDetails> GetGolferById(string id)
    {
        var golfer = await _context.Golfer.FindAsync(id);
        if (golfer == null)
        {
            return null;
        }
        return new GolferDetails()
        {
            Id = golfer.Id,
            FirstName = golfer.FirstName,
            LastName = golfer.LastName,
            Handicap = golfer.Handicap,
            Location = golfer.Location,
            PhoneNumber = golfer.PhoneNumber,
            DegreeWedge = golfer.DegreeWedge,
           DegreeWedge2 = golfer.DegreeWedge2,
           PitchingWedge = golfer.PitchingWedge,
           NineIron = golfer.NineIron,
           EightIron = golfer.EightIron,
           SevenIron = golfer.SevenIron,
           SixIron = golfer.SixIron,
           FiveIron = golfer.FiveIron,
           FourIron = golfer.FourIron,
           ThreeIron = golfer.ThreeIron,
           TwoIron = golfer.TwoIron,
           OneIron = golfer.OneIron,
           FiveWood = golfer.FiveWood,
           ThreeWood = golfer.ThreeWood,
           Driver = golfer.Driver,
        };


    }

    public async Task<GolferEdit> GetGolferByIdEdit(string id)
    {

        var golfer = await _context.Golfer.FindAsync(id);
        if (golfer == null) return null;
        return new GolferEdit()
        {
            Id = golfer.Id,
            FirstName = golfer.FirstName,
            LastName = golfer.LastName,
            Handicap = golfer.Handicap,
            Location = golfer.Location
        };
    }

    public async Task<bool> GolferCreate(GolferCreate model)
    {
        var golfer = new Golfers
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Handicap = model.Handicap,
            Location = model.Location,
        };
        _context.Golfer.Add(golfer);
        return await _context.SaveChangesAsync() == 1;
    }

    public async Task<bool> GolferEdit(string id, GolferEdit model)
    {


        if (id != model.Id)
            return false;

        var golfer = await _context.Golfer.FindAsync(id);
        if (golfer == null)
            return false;

        golfer.FirstName = model.FirstName;
        golfer.LastName = model.LastName;
        golfer.Handicap = model.Handicap;
        golfer.Location = model.Location;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddGolferFriend(string GolferId, string GolferIDb)
    {

        var myself = await _context.Golfer.FirstOrDefaultAsync(x => x.Id == GolferId);
        if (myself == null) return false;
        var friend = await _context.Golfer.FirstOrDefaultAsync(x => x.Id == GolferIDb);
        if (friend == null) return false;

        var golferFriends = new Golfers_Friends
        {

            GolferId = myself.Id,
            FriendId = friend.Id,


        };
        await _context.GolferFriends.AddAsync(golferFriends);
        await _context.SaveChangesAsync();
        return true;

    }

    public async Task<List<FriendListItem>> AllFriends(string Id)
    {
        var myFriends = await _context.GolferFriends.Where(g => g.GolferId == Id).Select(s => new FriendListItem
        {
            FriendId = s.GolfersFriend.Id,
            FirstName = s.GolfersFriend.FirstName,
            LastName = s.GolfersFriend.LastName,
            Location = s.GolfersFriend.Location,
            Handicap = s.GolfersFriend.Handicap,
        }).ToListAsync();
        
        return myFriends;
    }

    public async Task<List<ChallengeListItem>> AllGolferChallenges()
    {
        var challenges = await _context.Challenge.Select(f => new ChallengeListItem
        {
            ChallengeId = f.ChallengeId,
            FirstName = f.GolfersFriend.FirstName,
            LastName = f.GolfersFriend.LastName,
            Handicap = f.GolfersFriend.Handicap,
            Location = f.GolfersFriend.Location,

        }).ToListAsync();
        return challenges;
    }


    public async Task<bool> CreateChallenge(string GolferId, string userId)
    {
        var myself = await _context.Golfer.FirstOrDefaultAsync(g => g.Id == userId);
        if (userId == null) return false;
        var friend = await _context.GolferFriends.FirstOrDefaultAsync(g => g.FriendId == GolferId);

        if (GolferId == null) return false;

        var challengeId = new Challenges
        {

            ChallengeId = GolferId,
            Challenge2Id = userId,
        };

        await _context.Challenge.AddAsync(challengeId);
        await _context.SaveChangesAsync();
        return true;
    }
    public void SetUserId(string userId) => _userId = userId;

    

 
}

