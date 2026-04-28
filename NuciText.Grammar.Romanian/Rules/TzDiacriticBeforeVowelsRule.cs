namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Applies the Ț diacritic before vowels rule to Romanian text.
/// </summary>
internal sealed class TzDiacriticBeforeVowelsRule : GrammarRule
{
    /// <inheritdoc/>
    public override string Id => "tz-diacritic-before-vowels";

    /// <inheritdoc/>
    public override string Description => "Trims leading and trailing whitespace.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
    {
        string result = text;

        foreach (char vowel in "aeiouAEIOU")
        {
            result = result.Replace($"tz{vowel}", $"ț{vowel}");
            result = result.Replace($"Tz{vowel}", $"Ț{vowel}");
            result = result.Replace($"TZ{vowel}", $"Ț{vowel}");
        }

        return result;
    }
}