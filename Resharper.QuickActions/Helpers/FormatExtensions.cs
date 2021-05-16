using JetBrains.Application.Progress;
using JetBrains.DocumentManagers;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.CSharp.CodeStyle;
using JetBrains.ReSharper.Psi.Tree;

namespace Rumo.Resharper.QuickActions.Helpers
{
    public static class FormatExtensions
    {
        /// <summary>
        ///     The format body.
        /// </summary>
        /// <param name="statement">The body.</param>
        public static void Format(this ITreeNode statement)
        {
            if (!statement.IsPhysical())
            {
                return;
            }

            var documentRange = statement.GetDocumentRange();
            if (!documentRange.IsValid())
            {
                return;
            }

            var containingFile = statement.GetContainingFile();
            var psiSourceFile = containingFile?.GetSourceFile();
            if (psiSourceFile == null)
            {
                return;
            }

            var document = psiSourceFile.Document;
            var solution = statement.GetPsiServices().Solution;

            var languageService = statement.Language.LanguageService();
            var codeFormatter = languageService?.CodeFormatter;
            if (codeFormatter == null)
            {
                return;
            }

            var rangeMarker = new DocumentRange(document, documentRange.TextRange).CreateRangeMarker(DocumentManager.GetInstance(solution));

            containingFile.OptimizeImportsAndRefs(rangeMarker, false, true, NullProgressIndicator.Instance);
            codeFormatter.Format(statement, CodeFormatProfile.DEFAULT);
        }
    }
}