using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Util;
using Rumo.Resharper.QuickActions.Actions.Base;
using Rumo.Resharper.QuickActions.Helpers;
using Rumo.Resharper.QuickActions.Models;

namespace Rumo.Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones current property", Group = Constants.Languages.CSharp)]
    public class CloneProperty : CloneableClassMemberContextAction
    {
        const string ActionName = "Clone property";

        public CloneProperty(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            return GetContext().IsPropertySelected();
        }

        protected override IClassMemberDeclaration GetDeclarationToClone(ActionContext context)
        {
            return context.SelectedCodeElement.GetFirstParent<IPropertyDeclaration>();
        }
    }
}