namespace NuciText.Grammar.Romanian
{
    /// <summary>
    /// Applies the Romanian grammar rule set to a piece of text.
    /// </summary>
    public sealed class RomanianGrammarCorrector : IGrammarCorrector
    {
        readonly GrammarCorrector corrector = new(new RomanianGrammarRuleSet());

        /// <inheritdoc/>
        public string Correct(string text)
            => corrector.Correct(text);
    }
}