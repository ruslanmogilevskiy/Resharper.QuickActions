using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Resharper.QuickActions.Helpers
{
    public static class PlatformExtensions
    {
        public static bool IsMethod(this IClassMemberDeclaration member)
        {
            return member is IMethodDeclaration;
        }

        public static bool IsProperty(this IClassMemberDeclaration member)
        {
            return member is IPropertyDeclaration;
        }
    }
}