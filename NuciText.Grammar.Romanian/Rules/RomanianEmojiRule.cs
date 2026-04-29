using System.Collections.Generic;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Normalises emoji casing and spacing.
/// </summary>
internal sealed class RomanianEmojiRule : PatternReplacementRuleBase
{
    static readonly IReadOnlyList<RegexReplacement> replacements =
    [
        new("[Oo]([7/])", "o$1"),
        new("([:;=])[ ]*[Dd]", "$1D"),
        new("([:;=])[ ]*[Oo]", "$1O"),
        new("([:;=])[ ]*[Pp]", "$1P"),
        new("([:;=])[ ]*[Xx]", "$1X"),
        new("[Xx][Dd]", "xD")
    ];

    /// <inheritdoc/>
    public override string Id => "romanian-emoji";

    /// <inheritdoc/>
    public override string Description => "Normalises emoji casing and spacing.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
        => ApplyWordReplacements(text, replacements);
}