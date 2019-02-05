using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DictionaryApp
{
    public interface SearchInterface
    {
        Exception search(string searchTerm, string content);
        MatchCollection getMainMatches();
        MatchCollection getRelatedMatches();
        bool isValid();
    }
}
