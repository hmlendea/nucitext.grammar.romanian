using System.Collections;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Replaces "u" endings with "ul" in Romanian text.
/// </summary>
internal sealed class UlInsteadOfURule : GrammarRule
{
    /// <inheritdoc/>
    public override string Id => "ul-instead-of-u";

    /// <inheritdoc/>
    public override string Description => "Replaces 'u' endings with 'ul' in Romanian text.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
    {
        string result = text;

        string[] nouns =
        [
            "aer", "acoperiș", "bloc", "bulevard", "cal", "cap", "castel", "calculator", "cartier",
            "câștig", "colț", "dragon", "drăguț", "drum", "dubios", "examen", "film", "gând", "geam",
            "interior", "inventar", "joc", "lac", "lemn", "loc", "mal", "mijloc", "mormânt", "mort",
            "nivel", "ocean", "om", "oraș", "orășel", "palat", "pod", "porc", "posibil", "prim", "pui",
            "sat", "sărit", "săpun", "sărut", "seif", "sfat", "stat", "steguleț", "stoc", "târnăcop",
            "telefon", "top", "tort"
        ];

        foreach (string noun in nouns)
        {
            result = result.Replace($"{noun}u", $"{noun}ul");
        }

        return result;
    }
}