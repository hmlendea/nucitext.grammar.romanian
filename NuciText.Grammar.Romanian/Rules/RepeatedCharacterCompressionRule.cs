using System.Text.RegularExpressions;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Compresses very long repeated character sequences to a maximum of three characters.
/// </summary>
internal sealed class RepeatedCharacterCompressionRule : GrammarRule
{
    /// <inheritdoc/>
    public override string Id => "repeated-character-compression";

    /// <inheritdoc/>
    public override string Description => "Compresses repeated character sequences longer than three characters.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
        => Regex.Replace(text, "(([A-ZĂÂÎȘȚa-zăâîșț!?.])\\2\\2)\\2*", "$1", RegexOptions.CultureInvariant);
}