using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using Rumo.Resharper.QuickActions.Helpers;
using Rumo.Resharper.QuickActions.Models;

namespace Rumo.Resharper.QuickActions.Actions.Base
{
    public abstract class ContextActionBase : JetBrains.ReSharper.Feature.Services.ContextActions.ContextActionBase
    {
        public override string Text { get; }

        protected ICSharpContextActionDataProvider Provider { get; }

        protected ContextActionBase(string actionName, ICSharpContextActionDataProvider provider)
        {
            Text = actionName;
            Provider = provider;
        }

        protected ActionContext GetContext() => Provider.GetActionContext();
    }
}