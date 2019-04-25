using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using Resharper.QuickActions.Models;

namespace Resharper.QuickActions.Helpers
{
    public static class ActionContextExtensions
    {
        public static ActionContext GetActionContext(this ICSharpContextActionDataProvider provider)
        {
            var result = provider.GetSelectedElement<IMethodDeclaration>(true, true);
            if (result == null)
            {
                return null;
            }

            var selectedTreeNode = provider.SelectedElement;
            if (selectedTreeNode == null)
            {
                return null;
            }

            if (!result.GetNameDocumentRange().Contains(selectedTreeNode.GetDocumentRange()))
            {
                return null;
            }

            var containingType = result.GetContainingTypeDeclaration();
            if (containingType == null)
            {
                return null;
            }

            return new ActionContext
            {
                Method = result,
                ContainingType = containingType
            };
        }
    }
}