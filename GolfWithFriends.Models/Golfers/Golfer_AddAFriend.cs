using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Golfer_AddAFriend
{
    public string Id { get; set; }

    public string FriendId { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> SelectableGolfers { get; set; }

}

