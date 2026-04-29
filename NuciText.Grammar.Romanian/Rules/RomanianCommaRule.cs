using System.Collections.Generic;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Inserts commas in a few high-confidence Romanian chat expressions.
/// </summary>
internal sealed class RomanianCommaRule : PatternReplacementRuleBase
{
    static readonly IReadOnlyList<RegexReplacement> replacements =
    [
        new("a stai", "a, stai"),
        new("ah ([a-z][a-z]*)", "ah, $1"),
        new("(ie[sș]it) revin", "ieșit, revin")
    ];

    /// <inheritdoc/>
    public override string Id => "romanian-comma";

    /// <inheritdoc/>
    public override string Description => "Adds commas to high-confidence conversational expressions.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
        => ApplyWordReplacements(text, replacements);
}