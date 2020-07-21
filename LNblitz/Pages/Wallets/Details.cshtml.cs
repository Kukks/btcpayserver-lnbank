using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LNblitz.Data;
using LNblitz.Models;
using Microsoft.AspNetCore.Identity;

namespace LNblitz.Pages.Wallets
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public Wallet Wallet { get; set; }

        public DetailsModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var userId = _userManager.GetUserId(User);
            Wallet = await _context.Wallets
                .FirstOrDefaultAsync(w => w.Id == id && w.UserId == userId);

            if (Wallet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
