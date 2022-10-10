using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStore.Data;
using OnlineClothingStore.Models.ViewModels;
using System.Linq;

namespace OnlineClothingStore.Controllers
{
    public class IndexController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext applicationDbContext;

        public IndexController(UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }

      

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByIdAsync(User.Claims.First().Value);
            var userRoles = await userManager.GetRolesAsync(user);

            var productsList = applicationDbContext.Products.ToList();

            var indexViewModel = new IndexViewModel()
            {
                products = productsList,
                userRoles = userRoles,
            };

            return View(indexViewModel);
        }
    }
}
