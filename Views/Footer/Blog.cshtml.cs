using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Appointy.Views.Footer
{
    public class Blog : PageModel
    {
        private readonly ILogger<Blog> _logger;

        public Blog(ILogger<Blog> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}