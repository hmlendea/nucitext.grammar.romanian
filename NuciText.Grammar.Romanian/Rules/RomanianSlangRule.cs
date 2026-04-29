using System.Collections.Generic;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Expands Romanian chat slang to its full form.
/// </summary>
internal sealed class RomanianSlangRule : PatternReplacementRuleBase
{
    static readonly IReadOnlyList<RegexReplacement> replacements =
    [
        new("afaik", "din câte știu"),
        new("afair", "din câte îmi aduc aminte"),
        new("cnv", "cineva"),
        new("csf", "ce să faci"),
        new("dc", "de ce"),
        new("ft", "foarte"),
        new("idk", "nu știu"),
        new("imd", "imediat"),
        new("mcac", "mă cac"),
        new("mn", "mine"),
        new("nmk[k]*", "nimica"),
        new("nuj", "nu știu"),
        new("nush", "nu știu"),
        new("pt", "pentru"),
        new("sal", "salut"),
        new("sall", "salut"),
        new("tre", "trebuie")
    ];

    /// <inheritdoc/>
    public override string Id => "romanian-slang-replacement";

    /// <inheritdoc/>
    public override string Description => "Expands common Romanian chat slang expressions.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
    {
        string result = ApplyWordReplacements(text, replacements);

        if (result is "k" or "kk" or "K")
        {
            return "bine";
        }

        return result;
    }
}