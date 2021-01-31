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
            var selectedTreeNode = provider.SelectedElement as ICSharpTypeMemberDeclaration;
            var context = new ActionContext
            {
                ContainingType = selectedTreeNode?.GetContainingTypeDeclaration(),
                SelectedCodeElement = selectedTreeNode
            };
            if (selectedTreeNode != null)
            {
                if (selectedTreeNode.GetNameDocumentRange().Contains(provider.DocumentCaret))
                {
                    context.MemberFocusedPart = MemberFocusedPart.Name;
                }
            }

            return context;
        }
    }
}