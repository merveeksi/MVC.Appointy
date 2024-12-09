using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MVC.Appointy.Views.Footer
{
    public class Hakkimizda : PageModel
    {
        private readonly ILogger<Hakkimizda> _logger;

        public Hakkimizda(ILogger<Hakkimizda> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            // Asenkron işlemler burada yapılabilir
            await Task.CompletedTask; // Örnek asenkron işlem
        }
    }
}