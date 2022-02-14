using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstoreProject.Controllers
{
    public class HomeController : Controller
    {

        //private BookstoreContext context { get; set; }

        //public HomeController (BookstoreContext temp)
        //{
        //    context = temp;
        //}

        //public HomeController(BookstoreContext temp) => context = temp;

        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var x = new BooksViewModel
            {
                Books = repo.Books
                        .OrderBy(b => b.Title)
                        .Skip((pageNum - 1) * pageSize)
                        .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            

            return View(x);
        }

        
    }
}
