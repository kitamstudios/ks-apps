namespace KS.Applications.Common
{
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        public static T GetResult<T>(this Task @this)
        {
            return (T)typeof(Task<>)
                .MakeGenericType(typeof(T))
                .GetProperty(nameof(Task<T>.Result))
                .GetValue(@this);
        }
    }
}
