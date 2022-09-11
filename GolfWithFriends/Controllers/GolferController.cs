using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class GolferController : Controller
{
    private readonly IGolferService _golferService;
    private readonly ApplicationDbContext _context;
    public GolferController(IGolferService golferService, ApplicationDbContext context)
    {
        _golferService = golferService;
        _context = context;

    }

    private string GetUserId()
    {
        string userIdClaim = "";
        try
        {
            userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
        catch (Exception ex)
        {
            return null;
        }
        return userIdClaim;
    }

    private bool SetUserIdInService()
    {
        var userId = GetUserId();
        if (userId == null) return false;
        _golferService.SetUserId(userId);
        return true;
    }

    
    public async Task<IActionResult> Index()
    {
        if (!SetUserIdInService()) return RedirectToAction("Index", "UserNotFound");
        var golfer = await _context.Golfer.Select(g => new GolferListItem
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            Handicap = g.Handicap,
            Location = g.Location,

        }).ToListAsync();
        return View(golfer);
    }
    public async Task<IActionResult> AllGolferFriends(string Id)
    {
        if (!SetUserIdInService()) return RedirectToAction("Index", "UserNotFound");

        var friends = await _golferService.AllFriends(Id);

        return View(friends);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GolferCreate model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (!SetUserIdInService()) return Unauthorized();
        if (await _golferService.GolferCreate(model)) return RedirectToAction(nameof(Index));
        else
            TempData["ErrorMsg"] = "Unable to save to the database, Please try again later";
        return UnprocessableEntity();

    }

    [HttpGet]
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null) return BadRequest();
        var golfer = await _golferService.GetGolferById(id);
        if (golfer == null) return NotFound();
        return View(golfer);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(string id)
    {
        var golfer = await _golferService.GetGolferById(id);
        if (golfer == null) return NotFound();

        //var friend = await _context.GolferFriends.FindAsync(friendId);

        if (!SetUserIdInService()) return Unauthorized();

        bool worked = await _golferService.DeleteGolfer(id);
        return RedirectToAction(nameof(Index));
        if (!worked) return BadRequest();
        //bool workedp2 = await _golferService.DeleteGolfer(friendId);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> DeleteGolferFriend( string id )
    {
        var friend = await _golferService.GetGolferFriendById( id);
        if (friend == null)
        {
            return BadRequest();
        }
        //if (friend == null) return NotFound();
        return View(friend);
    }
    [HttpPost]
    [ActionName("DeleteGolferFriend")]
    public async Task<IActionResult> DeleteGolferFriendPost(string id)
    {
        if (!SetUserIdInService()) return Unauthorized();
        var userId = GetUserId();
        var friend = await _golferService.GetGolferFriendById( id);
        if (friend == null) return BadRequest();
        bool worked = await _golferService.DeleteFriend(id);

        if (!worked) return NotFound();
        return RedirectToAction("Index");

    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {


        if (id == null) return BadRequest();


        var golfer = await _golferService.GetGolferByIdEdit(id);
        if (golfer == null) return NotFound();
        return View(golfer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, GolferEdit model)
    {
        var userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        if (userIdClaim != id) return null;



        if (!ModelState.IsValid) return BadRequest();

        if (!SetUserIdInService()) return Unauthorized();

        if (await _golferService.GolferEdit(id, model))
            return RedirectToAction(nameof(Index));
        else
            return UnprocessableEntity();
    }

    [HttpGet]
    public async Task<IActionResult> AddFriend()
    {
        var golfer_addAFriend = new Golfer_AddAFriend
        {

        };
        golfer_addAFriend.SelectableGolfers = _golferService.AllGolfers().Result.Select(a => new SelectListItem
        {
            Text = a.FirstName,
            Value = a.Id.ToString(),

        });
        return View(golfer_addAFriend);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddFriend(Golfer_AddAFriend model)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (!SetUserIdInService()) return Unauthorized();

        var user = (ClaimsIdentity)User.Identity;
        var claim = user.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (await _golferService.AddGolferFriend(claim, model.FriendId))
        {
            return RedirectToAction(nameof(Index));
        }
        else
            return View(model);


    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        if (!SetUserIdInService()) return RedirectToAction("Index", "Home");

        var user = await _golferService.GetGolferById(id);
        if (user == null) return BadRequest();
        var details = new GolferDetails
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Handicap = user.Handicap,
            Location = user.Location,
        };
        return View(details);
    }
    [HttpGet]
    public async Task<IActionResult> Text(string id)
    {
        if (!SetUserIdInService()) return RedirectToAction("Index", "UserNotFound");

        var user = await _golferService.TextSetById(id);
        if (user == null) return BadRequest();
        var details = new GolferListItem()
        {
            PhoneNumber = user.PhoneNumber,
        };
        return View(details);
        }

    [HttpGet]
    public async Task<IActionResult> ChallengeCreate(string id)
    {
        var friend = await _golferService.GetFriendById(id);
        if (friend == null)
        {
            return BadRequest();
        }
        return View(friend);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChallengeCreate(string Id, IFormCollection formValues)
    {
        if (!SetUserIdInService()) return BadRequest();
        if (!ModelState.IsValid) return BadRequest();

        var user = (ClaimsIdentity)User.Identity;
        var name = user.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (await _golferService.CreateChallenge(name, Id))
        {
            return RedirectToAction(nameof(AllGolferFriends));
        }
        else
            return RedirectToAction(nameof(AllChallenges));
        
    }
    [HttpGet]
    public async Task<IActionResult> AllChallenges()
    {
        if (!SetUserIdInService()) return RedirectToAction("Index", "Home");

        var all = await _golferService.AllGolferChallenges();
        return View(all);
    }



}
    //public async Task<IActionResult> Settings(string id)
    //{

    //}


    //[HttpPost]
    //[AllowAnonymous]
    //[ValidateAntiForgeryToken]
    //public async Task<ActionResult> Register([Bind(Exclude = "UserPhoto")] GolferDetails model)
    //{
    //    if (ModelState.IsValid)
    //    {

    //        // To convert the user uploaded Photo as Byte Array before save to DB    
    //        byte[] imageData = null;
    //        if (Request.Files.Count > 0)
    //        {
    //            HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

    //            using (var binary = new BinaryReader(poImgFile.InputStream))
    //            {
    //                imageData = binary.ReadBytes(poImgFile.ContentLength);
    //            }
    //        }


    //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

    //        //Here we pass the byte array to user context to store in db    
    //        user.UserPhoto = imageData;

    //        var result = await UserManager.CreateAsync(user, model.Password);
    //        if (result.Succeeded)
    //        {
    //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

    //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771    
    //            // Send an email with this link    
    //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);    
    //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);    
    //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");    

    //            return RedirectToAction("Index", "Home");
    //        }
    //        AddErrors(result);
    //    }

    //    // If we got this far, something failed, redisplay form    
    //    return View(model);

