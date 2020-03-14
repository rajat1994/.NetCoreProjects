using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]  // Need to Understand this properly

        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
           Book = await _db.Book.FindAsync(id);
        }


        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {


                var BookDromDb = await _db.Book.FindAsync(Book.Id);
                BookDromDb.Name = Book.Name;
                BookDromDb.Author = Book.Author;
                BookDromDb.Author = Book.Author;


                await _db.SaveChangesAsync();

                return RedirectToPage("Index");


            }

            else
            {

                return Page();
            }

        }
    }
}