using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Resharper.QuickActions.Models
{
    public class ActionContext
    {
        public ICSharpTypeDeclaration ContainingType { get; set; }

        /// <summary>Code member under the mouse cursor.</summary>
        public ICSharpTypeMemberDeclaration SelectedCodeElement { get; set; }

        /// <summary>Member focused part under the mouse cursor.</summary>
        public MemberFocusedPart MemberFocusedPart { get; set; }
    }
}