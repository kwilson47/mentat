﻿using Mentat.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mentat.Repository.Models;
using Mentat.Repository.Services;

namespace Mentat.UI.Controllers
{

    /*
     * This class will create a page called "Account". When clicking "Register" or "Login" it
     * can be noticed that we then go to the "Register/Login" page depending on the dropdown item selected.
     */

    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            // create + return new instance of VM:
            return View(new RegisterViewModel());      // simplified to one line
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            _logger.LogInformation("First Name: {firstName}, \nLast Name: {lastName}, \nName: {nm}, \nPW: {pw}, " +
                "\nType: {type}, \nRememberMe: {rememberMe}, \nEmail: {email}, \nBirth Date: {birthDate}",
                            model.FirstName, model.LastName, model.UserName, model.Password, model.UserType, 
                            model.RememberMe, model.Email, model.BirthDate);

            if (model.UserType == 0)
            {
                return RedirectToAction("Index", "Student");
            }

            else if (model.UserType == 1)
            {
                return RedirectToAction("Index", "Mentor");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel()); // new view using the login view model
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            _logger.LogInformation("Name: {nm}, \nPW: {pw}, \nType: {type}, \nRememberMe: {rememberMe}",
                model.UserName, model.Password, model.UserType, model.RememberMe);


            if (model.UserType == 0)
            {
                return RedirectToAction("Index", "Student");
            }

            else if (model.UserType == 1)
            {
                return RedirectToAction("Index", "Mentor");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
