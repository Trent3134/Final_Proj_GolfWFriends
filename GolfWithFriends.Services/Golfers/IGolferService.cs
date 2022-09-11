using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IGolferService
{
    Task<bool> GolferCreate(GolferCreate model);
    Task<GolferDetails> GetGolferById(string id);
    Task<IEnumerable<GolferListItem>> AllGolfers();
    Task<bool> GolferEdit(string id, GolferEdit model);
    Task<bool> DeleteGolfer(string id);
    Task<GolferEdit> GetGolferByIdEdit(string id);
    Task<bool> AddGolferFriend(string GolferId, string GolferIDb);
    void SetUserId(string userId);
    Task<List<FriendListItem>> AllFriends(string Id);
    Task<bool> DeleteFriend(string friendId);
    Task<Golfers_Friends> GetFriendById(string friendId);
    Task<bool> CreateChallenge(string GolferId, string userId);
    Task<List<ChallengeListItem>> AllGolferChallenges();
    Task<Golfers_Friends> GetGolferFriendById(string Id);
    Task<FriendListItem> TextSetById(string id);


}

