using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.ContextActions;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.Util;
using Rumo.Resharper.QuickActions.Actions.Base;
using Rumo.Resharper.QuickActions.Helpers;
using Rumo.Resharper.QuickActions.Models;

namespace Rumo.Resharper.QuickActions.Actions
{
    [ContextAction(Name = ActionName, Description = "Clones current method", Group = Constants.Languages.CSharp)]
    public class CloneMethod : CloneableClassMemberContextAction
    {
        const string ActionName = "Clone method";

        public CloneMethod(ICSharpContextActionDataProvider provider) : base(ActionName, provider)
        {
        }

        public override bool IsAvailable(IUserDataHolder bag)
        {
            return GetContext().IsMethodSelected();
        }

        protected override IClassMemberDeclaration GetDeclarationToClone(ActionContext context)
        {
            return context.SelectedCodeElement.GetFirstParent<IMethodDeclaration>();
        }
    }
}