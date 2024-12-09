using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Appointy.Views.Patient
{
    public class ForgotPassword : PageModel
    {
        private readonly ILogger<ForgotPassword> _logger;

        public ForgotPassword(ILogger<ForgotPassword> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}