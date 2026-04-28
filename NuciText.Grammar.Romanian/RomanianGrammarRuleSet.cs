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
        new TzDiacriticBeforeVowelsRule(),
    ];

    /// <inheritdoc/>
    public override string LanguageCode => "ro";

    /// <inheritdoc/>
    public override IReadOnlyList<IGrammarRule> Rules => rules;
}