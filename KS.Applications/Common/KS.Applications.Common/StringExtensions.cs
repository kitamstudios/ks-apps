namespace KS.Applications.Common
{
    using System.IO;
    using System.Text;

    public static class StringExtensions
    {
        public static Stream ToStreamUTF8(this string s)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(s));
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
