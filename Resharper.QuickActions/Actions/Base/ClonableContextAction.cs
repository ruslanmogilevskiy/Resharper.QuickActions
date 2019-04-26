using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using Resharper.QuickActions.Helpers;

namespace Resharper.QuickActions.Actions.Base
{
    public abstract class ClonableContextAction : GenericContextAction
    {
        protected ClonableContextAction(string actionName, ICSharpContextActionDataProvider provider)
            : base(actionName, provider)
        {
        }

        protected sealed override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var context = GetContext();
            var code = context.SelectedMember.GetText();
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            var containingClass = context.ContainingType as IClassLikeDeclaration;
            if (containingClass == null)
            {
                return null;
            }

            var cloneDeclaration = (IClassMemberDeclaration)Provider.ElementFactory.CreateTypeMemberDeclaration(code);
            var result = containingClass.AddClassMemberDeclarationBefore(cloneDeclaration, context.SelectedMember);
            result.Format();

            return null;
        }
    }
}