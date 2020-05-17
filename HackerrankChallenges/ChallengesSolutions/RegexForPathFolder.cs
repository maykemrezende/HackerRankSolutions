using System.Text.RegularExpressions;

namespace HackerrankChallenges.ChallengesSolutions
{
    public static class RegexForPathFolder
    {
        const string PATTERN = "\\/?\\w+\\/\\w+\\/(.*)";

        public static string Solution(string word)
        {
            if (string.IsNullOrEmpty(word)) return string.Empty;

            Regex reg = new Regex(PATTERN, RegexOptions.Multiline);
            var matcher = reg.Match(word);
            string result = string.Empty;
            if (matcher.Success)            
                result = matcher.Groups[1].Value;
            
            return result;
        }

        public static string SolutionForMiddleFolder(string word)
        {
            if (string.IsNullOrEmpty(word)) return string.Empty;

            Regex reg = new Regex(PATTERN, RegexOptions.Multiline);
            var matcher = reg.Match(word);
            string result = string.Empty;
            if (matcher.Success)
            {
                result = matcher.Groups[0].Value;
                var firstOccurrencyOfFirstSlash = result.IndexOf('/');
                var secondOccurrencyOfSecSlash = result.IndexOf('/', result.IndexOf('/') + 1);
                result = result.Substring(firstOccurrencyOfFirstSlash + 1, secondOccurrencyOfSecSlash - firstOccurrencyOfFirstSlash - 1);
            }
            
            return result;
        }
    }
}
