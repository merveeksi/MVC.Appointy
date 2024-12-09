using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Appointy.Views.Footer
{
    public class GizlilikPolitikasi : PageModel
    {
        private readonly ILogger<GizlilikPolitikasi> _logger;

        public GizlilikPolitikasi(ILogger<GizlilikPolitikasi> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}