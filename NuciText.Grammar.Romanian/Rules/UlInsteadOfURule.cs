using System.Text.RegularExpressions;

namespace NuciText.Grammar.Romanian.Rules
{
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
                "adânc", "aer", "acoperiș", "alt", "aparat", "ars", "ascultat", "ascuns", "bec",
                "bloc", "bogat", "bulevard", "bunic", "cal", "câștig", "câștigător", "cap", "castel",
                "calculator", "cartier", "cerșetor", "cinci", "cireș", "client", "cod", "colț", "confirmat",
                "cont", "crescut", "crocodil", "democrat", "depășit", "descărcat", "deschis", "dragon", "drăguț",
                "drum", "dubios", "dușman", "enoriaș", "episod", "estimat", "examen", "făcut", "film",
                "fiert", "format", "fraier", "gând", "geam", "inamic", "inculpat", "împrumut", "întâmpinat",
                "întreg", "interior", "inventar", "joc", "jucător", "judecător", "lac", "lemn", "liniștit",
                "loc", "luptător", "mal", "mers", "meseriaș", "mijloc", "mormânt", "mort", "mutat",
                "net", "nivel", "ocean", "om", "omorât", "onorat", "opt", "orfan", "orășel",
                "oraș", "palat", "păcătos", "pilot", "pirat", "pivot", "plan", "plin", "pod",
                "polițist", "porc", "port", "posibil", "post", "poștaș", "preferat", "preot", "prim",
                "pui", "războinic", "rest", "roșcat", "săpun", "sărac", "sărit", "sărut", "sat",
                "schelet", "scop", "seif", "sfânt", "sfat", "șef", "șobolan", "singur", "soldat",
                "stat", "steguleț", "stoc", "tăiat", "târnăcop", "telefon", "tip", "top", "topor",
                "tort", "tot", "trecut", "trăsnet", "tren", "trei", "tur", "ucis", "urs",
                "următor", "vânt", "vameș", "val", "vârf", "vinovat", "vot", "zid"
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
}