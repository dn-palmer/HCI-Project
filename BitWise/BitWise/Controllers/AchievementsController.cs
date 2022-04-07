using BitWise.Models.Entities;
using BitWise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BitWise.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly IAchievementsRepo _achievements;

        public AchievementsController(IAchievementsRepo achievements)
        {
            _achievements = achievements;
        }
        // GET: AchievementsController
        public async Task<ActionResult<IEnumerable<Trophy>>> Index()
        {
            var achievements = await _achievements.ReadAllAsync();
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (currentUserID == null)
            {
                ViewData["SignedIn"] = false;
                return View();
            }
           var  userAchievements = achievements.Where(a => a.BitWiseUser.Id == currentUserID);

            return View(userAchievements);
        }


    }
}