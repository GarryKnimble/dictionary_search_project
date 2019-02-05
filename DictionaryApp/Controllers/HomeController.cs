﻿using System.Diagnostics;
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
            this.search = search;
        }
        public IActionResult Index(string word)
        {
            // Retrieve data source content 'Datasource/words_alpha.txt' and define pattern 
            // for parsing starting and containing strings. Insert 'word' url param to dictate 
            // what to search for.
            string word_content = System.IO.File.ReadAllText("Datasource/words_alpha.txt");
            this.search.search(word, word_content);
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
