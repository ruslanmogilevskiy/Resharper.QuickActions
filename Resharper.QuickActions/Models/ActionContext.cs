using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Resharper.QuickActions.Models
{
    public class ActionContext
    {
        public ICSharpTypeDeclaration ContainingType { get; set; }

        /// <summary>
        /// Selected method under cursor.
        /// </summary>
        public IMethodDeclaration Method { get; set; }
    }
}