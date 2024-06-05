using JetBrains.Application.Progress;
using JetBrains.DocumentManagers;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeStyle;
using JetBrains.ReSharper.Psi.Tree;

namespace Rumo.Resharper.QuickActions.Helpers
{
    public static class FormatExtensions
    {
        /// <summary>
        /// Formats body of the specified statement.
        /// </summary>
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

            var rangeMarker = new DocumentRange(document, documentRange.TextRange).CreateProjectAwareRangeMarker(solution);
            languageService.OptimizeImportsAndRefs(containingFile, rangeMarker, false, true, NullProgressIndicator.Create());
            codeFormatter.Format(statement, CodeFormatProfile.DEFAULT);
        }
    }
}