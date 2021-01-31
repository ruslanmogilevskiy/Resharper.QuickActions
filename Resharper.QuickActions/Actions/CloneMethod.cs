using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.Util;
using Resharper.QuickActions.Actions.Base;
using Resharper.QuickActions.Helpers;

namespace Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones focused method", Group = Constants.Languages.CSharp)]
    public class CloneMethod : CloneableMemberContextAction
    {
        const string ActionName = "Clone method";

        public CloneMethod(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            var context = GetContext();
            return context?.SelectedCodeElement?.IsMethod() == true;
        }
    }
}