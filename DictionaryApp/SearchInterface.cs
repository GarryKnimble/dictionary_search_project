using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DictionaryApp
{
    public interface SearchInterface
    {
        void setContent(string content);
        Exception search(string searchTerm);
        MatchCollection getMainMatches();
        MatchCollection getRelatedMatches();
        bool isValid();
    }
}
