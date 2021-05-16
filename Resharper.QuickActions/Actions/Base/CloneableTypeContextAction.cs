using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using Rumo.Resharper.QuickActions.Helpers;

namespace Rumo.Resharper.QuickActions.Actions.Base
{
    public abstract class CloneableTypeContextAction : CloneableContextActionBase
    {
        protected CloneableTypeContextAction(string actionName, ICSharpContextActionDataProvider provider) : base(actionName, provider)
        {
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var context = GetContext();
            var typeToClone = (IClassDeclaration) GetDeclarationToClone(context);
            var selectedElementCode = typeToClone?.GetText();
            // Note: skip if we cannot get the selected member`s source code.
            if (string.IsNullOrEmpty(selectedElementCode))
                return null;

            var cloneDeclaration = (IClassMemberDeclaration) Provider.ElementFactory.CreateTypeMemberDeclaration(selectedElementCode);
            var result = typeToClone.AddClassMemberDeclarationBefore(cloneDeclaration, typeToClone);
            result.Format();

            return null;
        }
    }
}