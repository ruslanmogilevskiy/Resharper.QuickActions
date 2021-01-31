using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace Resharper.QuickActions.Helpers
{
    public static class PlatformExtensions
    {
        public static bool IsMethod(this IDeclaration member)
        {
            return member is IMethodDeclaration;
        }

        public static bool IsProperty(this IDeclaration member)
        {
            return member is IPropertyDeclaration;
        }

        public static bool IsType(this IDeclaration member)
        {
            return member is IClassDeclaration;
        }
    }
}