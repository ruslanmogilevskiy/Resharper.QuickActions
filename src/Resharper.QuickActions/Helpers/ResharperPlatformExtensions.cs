using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using Rumo.Resharper.QuickActions.Models;

namespace Rumo.Resharper.QuickActions.Helpers
{
    public static class ResharperPlatformExtensions
    {
        public static bool IsClassSelected(this ActionContext context)
        {
            return (context.SelectedCodeElement.Parent is IClassBody || context.SelectedCodeElement.Parent  is IClassDeclaration) &&
                   (context.IsBodyDeclarationSelected || context.MemberFocusedPart == MemberFocusedPart.Name);
        }

        public static bool IsMethodSelected(this ActionContext context)
        {
            return (context.SelectedCodeElement.Parent is IBlock || context.SelectedCodeElement.Parent is IMethodDeclaration) &&
                   (context.IsBodyDeclarationSelected || context.MemberFocusedPart == MemberFocusedPart.Name);
        }

        public static bool IsPropertySelected(this ActionContext context)
        {
            return !context.IsBodyDeclarationSelected && context.SelectedCodeElement.GetFirstParent<IPropertyDeclaration>() != null;
        }

        public static IClassDeclaration GetParentClass(this IDeclaration member)
        {
            return member.GetFirstParent<IClassDeclaration>();
        }

        public static T GetFirstParent<T>(this ITreeNode startNode) where T : ITreeNode
        {
            var node = startNode;
            while (node != null)
            {
                if (node is T specificNode)
                    return specificNode;
                node = node.Parent;
            }

            return default;
        }

        public static ActionContext GetActionContext(this ICSharpContextActionDataProvider provider)
        {
            var selectedElement = provider.SelectedElement;
            if (selectedElement == null)
                return new ActionContext();

            var context = new ActionContext
            {
                SelectedCodeElement = selectedElement,
                IsBodyDeclarationSelected = IsBodyDeclarationSelected(selectedElement),
                MemberFocusedPart = GetMemberFocusedPart(provider, selectedElement)
            };

            return context;
        }

        static bool IsBodyDeclarationSelected(ITreeNode selectedElement)
        {
            if (selectedElement is IIdentifier)
                return false;

            // method or class body
            if (selectedElement.Parent is IBlock || selectedElement.Parent is IClassBody)
                return true;

            return false;
        }

        static MemberFocusedPart GetMemberFocusedPart(ICSharpContextActionDataProvider provider, ITreeNode selectedElement)
        {
            if (selectedElement is IIdentifier && IsSupportedElement(selectedElement.Parent))
                return MemberFocusedPart.Name;

            return MemberFocusedPart.None;
        }

        static bool IsSupportedElement(ITreeNode element)
        {
            return element is IClassDeclaration || element is IMethodDeclaration || element is IPropertyDeclaration;
        }
    }
}