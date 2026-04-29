namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Replaces common ASCII fractions with their Unicode glyphs.
/// </summary>
internal sealed class FractionGlyphRule : GrammarRule
{
    /// <inheritdoc/>
    public override string Id => "fraction-glyph";

    /// <inheritdoc/>
    public override string Description => "Replaces common ASCII fractions with Unicode fraction glyphs.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
    {
        string result = text;

        result = result.Replace("1/2", "½");
        result = result.Replace("1/3", "⅓");
        result = result.Replace("2/3", "⅔");
        result = result.Replace("1/4", "¼");
        result = result.Replace("3/4", "¾");
        result = result.Replace("1/8", "⅛");
        result = result.Replace("3/8", "⅜");
        result = result.Replace("5/8", "⅝");
        result = result.Replace("7/8", "⅞");

        return result;
    }
}