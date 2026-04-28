using System.Collections.Generic;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Normalises common abbreviations.
/// </summary>
internal sealed class RomanianAbbreviationsRule : PatternReplacementRuleBase
{
    static readonly IReadOnlyList<RegexReplacement> replacements =
    [
        new("(?i:afk)", "AFK"),
        new("(?i:brb)", "BRB"),
        new("(?i:omg)", "OMG"),
        new("(?i:pc)", "PC"),
        new("(?i:rip)", "RIP"),
    ];

    /// <inheritdoc/>
    public override string Id => "romanian-abbreviations";

    /// <inheritdoc/>
    public override string Description => "Normalises common abbreviations.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
        => ApplyWordReplacements(text, replacements);
}