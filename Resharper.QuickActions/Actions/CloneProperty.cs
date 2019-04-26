using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.Util;
using Resharper.QuickActions.Actions.Base;
using Resharper.QuickActions.Helpers;
using Resharper.QuickActions.Models;

namespace Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones selected property", Group = "C#")]
    public class CloneProperty : ClonableContextAction
    {
        const string ActionName = "Clone property";

        public CloneProperty(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            var context = GetContext();
            return context?.SelectedMember?.IsProperty() == true && context.SelectedMemberPart == SelectedMemberPart.Name;
        }
    }
}