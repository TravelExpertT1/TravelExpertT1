using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TravelExpert.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TravelExpert.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        //Tom added:
        private TravelExpertsContext data;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr,
            //Tom added:
            TravelExpertsContext rep)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            data = rep;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.Username,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    //Tom: Create new customer and save in Customer table in db 
                    var NewCustomer = new Customer();
                    NewCustomer.CustFirstName = model.Firstname;
                    NewCustomer.CustLastName = model.Lastname;
                    NewCustomer.CustEmail = model.Username;
                    data.Customers.Update(NewCustomer);
                    data.SaveChanges();

                    //Tom:Find and Add CustomerID to session
                    List<Customer> listCustomers;
                    listCustomers = data.Customers.ToList();
                    NewCustomer = listCustomers.Find(x => x.CustEmail == model.Username);
                    HttpContext.Session.SetInt32("CustomerId", NewCustomer.CustomerId);
                    //End
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            //Tom Added: Deleted Session (CustomerId)
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {

                    //Tom:Find and Add CustomerID to session
                    var NewCustomer = new Customer();
                    List<Customer> listCustomers;
                    listCustomers = data.Customers.ToList();
                    NewCustomer = listCustomers.Find(x => x.CustEmail == model.Username);
                    HttpContext.Session.SetInt32("CustomerId", NewCustomer.CustomerId);

                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}