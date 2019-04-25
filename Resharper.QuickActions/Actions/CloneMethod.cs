using System;
using System.Diagnostics;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using JetBrains.Util;
using Resharper.QuickActions.Helpers;
using Resharper.QuickActions.Models;

namespace Resharper.QuickActions.Actions
{
    [ContextAction(Name = Constants.PluginName, Description = "Clones selected method", Group = "C#")]
    public class CloneMethod : ContextActionBase
    {
        readonly ICSharpContextActionDataProvider _provider;

        ActionContext Context => _provider.GetActionContext();

        public CloneMethod(ICSharpContextActionDataProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Popup menu item text
        /// </summary>
        public override string Text => Constants.PluginName;

        public override bool IsAvailable(IUserDataHolder bag)
        {
            return Context != null;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var context = Context;
            if (context == null)
            {
                return null;
            }

            var code = context.Method.GetText();
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            var typeMember = _provider.ElementFactory.CreateTypeMemberDeclaration(code);

            var classDeclaration = context.ContainingType as IClassLikeDeclaration;
            if (classDeclaration == null)
            {
                return null;
            }

            var memberDeclaration = typeMember as IClassMemberDeclaration;
            Debug.Assert(memberDeclaration != null, "memberDeclaration != null");

            var result = classDeclaration.AddClassMemberDeclarationBefore(memberDeclaration, context.Method);

            result.Format();

            return null;
        }
    }
}