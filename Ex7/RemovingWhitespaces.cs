using System.Text.RegularExpressions;

namespace Ex7
{
    public class RemovingWhitespaces : IProcessText
    {
        public string ProcessText(string text)
        {
            return Regex.Replace(text, @"\s+", "");
        }
    }
}