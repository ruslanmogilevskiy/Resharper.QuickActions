using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using Resharper.QuickActions.Helpers;
using Resharper.QuickActions.Models;

namespace Resharper.QuickActions.Actions.Base
{
    public abstract class GenericContextAction : ContextActionBase
    {
        readonly string _actionName;

        public override string Text => _actionName;

        protected ICSharpContextActionDataProvider Provider { get; }

        protected GenericContextAction(string actionName, ICSharpContextActionDataProvider provider)
        {
            _actionName = actionName;
            Provider = provider;
        }

        protected ActionContext GetContext() => Provider.GetActionContext();
    }
}