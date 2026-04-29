using System.Text.RegularExpressions;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Replaces "u" endings with "ul" for Romanian masculine nouns.
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
            "aer", "acoperiș", "alt", "bec", "bloc", "bulevard", "cal", "cap", "castel",
            "calculator",
            "cartier", "câștig", "cinci", "client", "cod", "colț", "cont",
            "dragon", "drăguț", "drum", "dubios", "examen", "film", "format",
            "fraier", "gând", "geam", "interior", "inventar", "joc", "lac",
            "lemn", "loc", "mal", "mijloc", "mormânt", "mort", "net", "nivel",
            "ocean", "om", "opt", "oraș", "orășel", "palat", "plan", "pod",
            "porc", "posibil", "prim", "pui", "sat", "sărit", "săpun", "sărut",
            "scop", "seif", "sfânt", "sfat", "singur", "stat", "steguleț", "stoc", "șef",
            "târnăcop", "telefon", "tip", "top", "topor", "tort", "tot", "trăsnet",
            "tur", "trei", "vânt", "val", "vârf", "vot", "zid"
        ];

        foreach (string noun in nouns)
        {
            string diacriticlessNoun = noun
                .Replace("ă", "a")
                .Replace("â", "a")
                .Replace("î", "i")
                .Replace("ș", "s")
                .Replace("ț", "t")
                .Replace("Ă", "A")
                .Replace("Â", "A")
                .Replace("Î", "I")
                .Replace("Ș", "S")
                .Replace("Ț", "T");
            result = Regex.Replace(result, $@"\b{Regex.Escape(noun)}u\b", $"{noun}ul");
            result = Regex.Replace(result, $@"\b{Regex.Escape(diacriticlessNoun)}u\b", $"{diacriticlessNoun}ul");
        }

        return result;
    }
}