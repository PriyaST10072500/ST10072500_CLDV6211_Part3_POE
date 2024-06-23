using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace ST10072500_CLDV6211_Part2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {

        private readonly RoleManager<IdentityRole> _manager;


        public RolesController(RoleManager<IdentityRole> roleManager) 
        {
            _manager = roleManager;
        
        }


        public IActionResult Index()
        {
            var roles = _manager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var roles = _manager.Roles;

            return View();
        }


        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            //Check if the role exists
            if(!_manager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _manager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }

            return RedirectToAction("Index");
        }


    }
}
