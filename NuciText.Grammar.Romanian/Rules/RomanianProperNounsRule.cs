using System.Collections.Generic;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Normalises proper names, software names, and settlement names.
/// </summary>
internal sealed class RomanianProperNounsRule : PatternReplacementRuleBase
{
    static readonly IReadOnlyList<RegexReplacement> replacements =
    [
        new("(?i:andrei)", "Andrei"),
        new("(?i:batman)", "Batman"),
        new("(?i:de ce comics)", "DC Comics"),
        new("(?i:george)", "George"),
        new("(?i:hori)", "Hori"),
        new("(?i:ioan)", "Ioan"),
        new("(?i:ioana)", "Ioana"),
        new("(?i:ioane)", "Ioane"),
        new("(?i:ionut)", "Ionuț"),
        new("(?i:mada)", "Mădă"),
        new("(?i:maria)", "Maria"),
        new("(?i:marvel)", "Marvel"),
        new("(?i:minecraft)", "Minecraft"),
        new("(?i:nicusor)", "Nicușor"),
        new("(?i:pokemon)", "Pokémon"),
        new("(?i:romania)", "România"),
        new("(?i:spiderman)", "Spiderman"),
    ];

    /// <inheritdoc/>
    public override string Id => "romanian-proper-nouns";

    /// <inheritdoc/>
    public override string Description => "Normalises proper nouns, names, and software titles.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
        => ApplyWordReplacements(text, replacements);
}