namespace KS.Applications.Common
{
    using System.Threading.Tasks;

    public static class ObjectExtensions
    {
        public static Task<T> ToTask<T>(this T o)
        {
            return Task.FromResult(o);
        }
    }
}
