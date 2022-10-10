using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using OnlineClothingStore.Models.ViewModels;
using OnlineClothingStore.Data;

namespace OnlineClothingStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager, ApplicationDbContext applicationDbContext, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            SignInManager = signInManager;
        }

        public IndexViewModel indexViewModel { get; set;}
        public SignInManager<IdentityUser> SignInManager { get; }

        public async Task OnGetAsync()
        {

            //var userData = _userManager.FindByNameAsync(User.Identity.Name);
            //var userData = _userManager.GetUserAsync(this.HttpContext.User.Identity.Name);

            if (SignInManager.IsSignedIn(User))
            {
                var user = await _userManager.FindByIdAsync(this.HttpContext.User.Claims.First().Value);
                var userRoles = await _userManager.GetRolesAsync(user);

                var productsList = _applicationDbContext.Products.ToList();

                indexViewModel = new IndexViewModel()
                {
                    products = productsList,
                    userRoles = userRoles,
                };
            }
            
           
        }

    }
}