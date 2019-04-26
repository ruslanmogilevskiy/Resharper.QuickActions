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
            var member = GetSelectedMemberDeclaration(provider);
            var context = new ActionContext
            {
                ContainingType = member?.GetContainingTypeDeclaration(),
                SelectedMember = member
            };

            var selectedTreeNode = provider.SelectedElement;
            if (selectedTreeNode != null && member.GetNameDocumentRange().Contains(selectedTreeNode.GetDocumentRange()))
            {
                context.SelectedMemberPart = SelectedMemberPart.Name;
            }

            return context;
        }

        static IClassMemberDeclaration GetSelectedMemberDeclaration(ICSharpContextActionDataProvider provider)
        {
            return (IClassMemberDeclaration)provider.GetSelectedElement<IMethodDeclaration>() ??
                   provider.GetSelectedElement<IPropertyDeclaration>();
        }
    }
}