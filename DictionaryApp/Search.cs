using System;
using System.Text.RegularExpressions;

namespace DictionaryApp
{
    public class Search
    {
        // Search term and the content to be searched,
        // as well as search properties for regex
        private string searchTerm;
        private string content;
        private string searchProperties = @"(?im)^";
        // The pattern strings to be used for the search
        private string mainPattern;
        private string relatedPattern;
        // Checks whether search term was valid or not
        private bool isvalid;
        // Match collections of the main and related matches
        // obtained from the content
        private MatchCollection mainMatches;
        private MatchCollection relatedMatches;
        
        // Search
        // Parameters:
        // searchTerm (string) - The search term to look for in content
        // content (string) - The content to be searched using searchTerm
        public Search(string searchTerm, string content)
        {
            this.searchTerm = searchTerm;
            this.content = content;
            this.mainPattern = this.searchProperties + this.searchTerm + ".*";
            this.relatedPattern = this.searchProperties + ".+" + this.searchTerm + ".*";
        }
        // method: search
        // Obtains both the main and related matches of type MatchCollection if the
        // search function has been called successfully with a valid search term.
        // The items of mainMatches and relatedMatches will be in lexicographical order.
        // If there is an issue with the search term, the isvalid value will 
        // be set to false. Otherwise, it will be set to true. An Exception
        // object will be returned if there is an issue. Otherwise, null will
        // be returned.
        public Exception search()
        {
            // Check if search term is not null and length is longer than 0
            if (this.searchTerm != null && this.searchTerm.Length > 0)
            {
                // Check for unexpected errors
                try
                {
                    this.mainMatches = Regex.Matches(this.content, this.mainPattern);
                    this.relatedMatches = Regex.Matches(this.content, this.relatedPattern);
                    if (this.mainMatches != null && this.relatedMatches != null)
                    {
                        this.isvalid = true;
                        return null;
                    }
                    this.isvalid = false;
                    return new Exception("Unexpected error occurred");
                }
                // If there are unexpected errors, return exception and set isvalid to false
                catch (Exception e)
                {
                    this.mainMatches = null;
                    this.relatedMatches = null;
                    this.isvalid = false;
                    return e;
                }
            }
            // If the search term is null and/or has a length of 0, return false
            // and exception
            else
            {
                this.isvalid = false;
                return new Exception("There were no search terms entered.");
            }
        }
        // method: getMainMatches
        // Returns the main matches as MatchCollection if successful.
        // Otherwise, it returns null if unsuccessful or no search conducted.
        public MatchCollection getMainMatches()
        {
            return this.mainMatches;
        }
        // method: getRelatedMatches
        // Returns the related matches as MatchCollection if successful.
        // Otherwise, it returns null if unsuccessful or no search conducted.
        public MatchCollection getRelatedMatches()
        {
            return this.relatedMatches;
        }
        // method: isValid
        // Returns if the search term used was valid
        public bool isValid()
        {
            return this.isvalid;
        }
    }
}
