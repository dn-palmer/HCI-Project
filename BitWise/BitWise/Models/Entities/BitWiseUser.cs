using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitWise.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace BitWise.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BitWiseUser class
public class BitWiseUser : IdentityUser
{
    public List<Trophy> Trophies { get; set; }

    public BitWiseUser()
    {
        Trophies = new List<Trophy>();
    }

}

