using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using Resharper.QuickActions.Helpers;

namespace Resharper.QuickActions.Actions.Base
{
    public abstract class CloneableTypeContextAction : GenericContextAction
    {
        protected CloneableTypeContextAction(string actionName, ICSharpContextActionDataProvider provider) : base(actionName, provider)
        {
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var context = GetContext();
            var code = context.SelectedCodeElement?.GetText();
            // Note: skip if there`s no selected element so we cannot get its code block body.
            if (string.IsNullOrEmpty(code))
                return null;

            var containingClass = context.ContainingType as IClassLikeDeclaration;
            if (containingClass != null)
            {
                var cloneDeclaration = (IClassMemberDeclaration) Provider.ElementFactory.CreateTypeMemberDeclaration(code);
                var result = containingClass.AddClassMemberDeclarationBefore(cloneDeclaration, (IClassMemberDeclaration) context.SelectedCodeElement);
                result.Format();
            }

            return null;
        }
    }
}