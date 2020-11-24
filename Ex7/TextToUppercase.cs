namespace Ex7
{
    public class TextToUppercase : IProcessText
    {
        public string ProcessText(string text)
        {
            return text.ToUpper();
        }
    }
}