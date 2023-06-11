﻿// Licencie to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using jautomulti.Data;
using jautomulti.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace jautomulti.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        /// <summary>
        /// classe q representa o acesso à BD do sistema
        /// </summary>
        private readonly ApplicationDbContext _context;


        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
           
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context; 
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            /// <summary>
            /// dados do dono que ficará associado à autenticação
            /// </summary>
            public Proprietarios Proprietario { get; set; }

            public Profissionais Profissional { get; set; }


            public  string RoleEscolhida { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                // atribuir o nome de batismo e a data de registo ao novo utilizador
                user.NomeDoUtilizador = Input.Proprietario.Nome;
                 user.DataRegisto = DateTime.Now;
                var result = await _userManager.CreateAsync(user, Input.Password);

                //ApplicationUser userDaIdentity = await _userManager.FindByEmailAsync(Input.Email);
                //Proprietarios proprietarios = new Proprietarios();
                //proprietarios.Email = Input.Email;
                //proprietarios.Nome = "João Silva";
                //proprietarios.NIF = "223445667";
                //proprietarios.Telemovel = "9159111123";
                //proprietarios.UserID = userDaIdentity.Id;

                //_context.Proprietarios.Add(proprietarios);
                //  _context.SaveChanges();

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if(string.IsNullOrEmpty(Input.RoleEscolhida)) { Input.RoleEscolhida = "Cliente"; }

                    await _userManager.AddToRoleAsync(user, Input.RoleEscolhida);

                    //if (Input.RoleEscolhida == "Profissional")
                    //{
                    //    // Encontre o profissional correspondente ao usuário registrado
                    //    Input.Profissional.Email = Input.Email;
                    //    // (2)
                    //    Input.Profissional.UserID = user.Id;
                    //    try
                    //    {
                    //        // (3)
                    //        _context.Add(Input.Profissional);


                    //        await _context.SaveChangesAsync();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        // se chego aqui, aconteceu um problema
                    //        // e qual é?
                    //        // não conseguir guardar os dados do novo Proprietario
                    //        // o que fazer????
                    //        // eliminar o utilizador já criado
                    //        await _userManager.DeleteAsync(user);
                    //        // criar msg de erro a ser enviada ao utilizador
                    //        ModelState.AddModelError("", "Ocorreu um erro com a criação do Utilizador");


                    //    }
                    //}
                    //else { 
                        /* +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                   * guardar os dados do novo PROPRIETARIO
                   * 1- atribuir ao novo Proprietario, o email
                   * 2-                        o UserID
                   * 3- guardar os dados na BD
                   */
                        // (1)
                        Input.Proprietario.Email = Input.Email;
                    // (2)
                    Input.Proprietario.UserID = user.Id;
                    try
                    {
                        // (3)
                        _context.Add(Input.Proprietario);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        // se chego aqui, aconteceu um problema
                        // e qual é?
                        // não conseguir guardar os dados do novo Proprietario
                        // o que fazer????
                        // eliminar o utilizador já criado
                        await _userManager.DeleteAsync(user);
                        // criar msg de erro a ser enviada ao utilizador
                        ModelState.AddModelError("", "Ocorreu um erro com a criação do Utilizador");



                        // notificar o Admin q ocorreu um erro...
                        // escrever num ficheiro de log o erro...
                        // etc. ...

                        // devolver o controlo da app ao utilizador
                        return Page(); // <=> return View();
                    }



                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
