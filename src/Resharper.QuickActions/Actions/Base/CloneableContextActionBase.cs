using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using Rumo.Resharper.QuickActions.Models;

namespace Rumo.Resharper.QuickActions.Actions.Base
{
    public abstract class CloneableContextActionBase : ContextActionBase
    {
        protected CloneableContextActionBase(string actionName, ICSharpContextActionDataProvider provider) : base(actionName, provider)
        {
        }

        protected abstract IClassMemberDeclaration GetDeclarationToClone(ActionContext context);
    }
}