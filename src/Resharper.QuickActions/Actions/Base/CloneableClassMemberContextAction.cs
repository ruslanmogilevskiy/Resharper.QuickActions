using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using Rumo.Resharper.QuickActions.Helpers;

namespace Rumo.Resharper.QuickActions.Actions.Base
{
    public abstract class CloneableClassMemberContextAction : CloneableContextActionBase
    {
        protected CloneableClassMemberContextAction(string actionName, ICSharpContextActionDataProvider provider) : base(actionName, provider)
        {
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var context = GetContext();
            var memberToClone = GetDeclarationToClone(context);
            var selectedElementCode = memberToClone?.GetText();
            // Note: skip if we cannot get the selected member's source code.
            if (string.IsNullOrEmpty(selectedElementCode))
                return null;

            var containingClass = memberToClone.GetParentClass();
            if (containingClass == null)
                return null;

            var cloneDeclaration = (IClassMemberDeclaration) Provider.ElementFactory.CreateTypeMemberDeclaration(selectedElementCode);
            var result = containingClass.AddClassMemberDeclarationBefore(cloneDeclaration, memberToClone);
            result.Format();

            return null;
        }
    }
}