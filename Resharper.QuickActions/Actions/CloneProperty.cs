using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.Util;
using Resharper.QuickActions.Actions.Base;
using Resharper.QuickActions.Helpers;

namespace Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones focused property", Group = Constants.Languages.CSharp)]
    public class CloneProperty : CloneableMemberContextAction
    {
        const string ActionName = "Clone property";

        public CloneProperty(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            var context = GetContext();
            return context?.SelectedCodeElement?.IsProperty() == true;
        }
    }
}