using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DictionaryApp.Models;

namespace DictionaryApp.Controllers
{
    public class HomeController : Controller
    {
        // Search interface for searching dictionary
        SearchInterface search;
        // Obtain search interface for search capability
        public HomeController(SearchInterface search)
        {
            string word_content = System.IO.File.ReadAllText("Datasource/words_alpha.txt");
            this.search = search;
            this.search.setContent(word_content);
        }
        public IActionResult Index(string word)
        {
            // Search with the given search term 'word'
            this.search.search(word);
            // Check if the search term is a valid search
            if (search.isValid())
            {
                // Set variables for HTML search page to use.
                ViewData["mainResults"] = search.getMainMatches();
                ViewData["relatedResults"] = search.getRelatedMatches();
                ViewData["search"] = word;
                ViewData["isSearching"] = true;
            }
            // Otherwise, don't view the search items
            else
            {
                ViewData["isSearching"] = false;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
