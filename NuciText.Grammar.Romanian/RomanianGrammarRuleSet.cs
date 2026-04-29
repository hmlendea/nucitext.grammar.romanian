using System.Collections.Generic;
using NuciText.Grammar.Romanian.Rules;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian;

/// <summary>
/// Romanian grammar correction rules.
/// </summary>
public sealed class RomanianGrammarRuleSet : GrammarRuleSet
{
    static readonly IGrammarRule[] rules =
    [
        new TrimWhitespaceRule(),
        new RepeatedCharacterCompressionRule(),
        new TzDiacriticBeforeVowelsRule(),
        new RomanianSlangRule(),
        new RomanianDiacriticsRule(),
        new RomanianProperNounsRule(),
        new RomanianSpacingRule(),
        new RomanianEmojiRule(),
        new RomanianTypoFixRule(),
        new RomanianDiacriticsRule(),
        new RomanianCommaRule(),
        new FractionGlyphRule(),
        new UlInsteadOfURule(),
    ];

    /// <inheritdoc/>
    public override string LanguageCode => "ro";

    /// <inheritdoc/>
    public override IReadOnlyList<IGrammarRule> Rules => rules;
}