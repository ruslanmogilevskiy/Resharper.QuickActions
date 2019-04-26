using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Resharper.QuickActions.Models
{
    public class ActionContext
    {
        public ICSharpTypeDeclaration ContainingType { get; set; }

        public IClassMemberDeclaration SelectedMember { get; set; }

        public SelectedMemberPart SelectedMemberPart { get; set; }
    }

    public enum SelectedMemberPart
    {
        Name
    }
}