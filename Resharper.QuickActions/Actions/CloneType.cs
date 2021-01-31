using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.Util;
using Resharper.QuickActions.Actions.Base;
using Resharper.QuickActions.Models;

namespace Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones focused type", Group = Constants.Languages.CSharp)]
    public class CloneType : CloneableTypeContextAction
    {
        const string ActionName = "Clone type";

        public CloneType(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            var context = GetContext();
            return context?.ContainingType != null && context.MemberFocusedPart == MemberFocusedPart.Name;
        }
    }
}