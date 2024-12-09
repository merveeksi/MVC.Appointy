using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Appointy.Views.Footer
{
    public class KVKK : PageModel
    {
        private readonly ILogger<KVKK> _logger;

        public KVKK(ILogger<KVKK> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}