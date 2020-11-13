namespace KS.Applications.Common
{
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Autofac;

    public static class AutofacExtensions
    {
        public static void RegisterMatchingTypesAsImplementedInterfaces(this ContainerBuilder builder, Assembly containingAssembly, params string[] classNameMatchers)
        {
            builder
                .RegisterAssemblyTypes(containingAssembly)
                .Where(t => classNameMatchers.Any(m => Regex.IsMatch(t.Name, m)))
                .AsImplementedInterfaces();
        }
    }
}
