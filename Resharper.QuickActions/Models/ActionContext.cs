using JetBrains.ReSharper.Psi.Tree;

namespace Rumo.Resharper.QuickActions.Models
{
    public class ActionContext
    {
        /// <summary>Code member under the mouse cursor.</summary>
        public ITreeNode SelectedCodeElement { get; set; }

        /// <summary>Whether a member's body declaration is selected. Supports member and class declarations.</summary>
        public bool IsBodyDeclarationSelected { get; set; }

        /// <summary>The member's focused part under the mouse cursor.</summary>
        public MemberFocusedPart MemberFocusedPart { get; set; }
    }
}