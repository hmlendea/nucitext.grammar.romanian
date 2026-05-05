using System.Collections.Generic;
using System.Text.RegularExpressions;
using NuciText.Grammar.Rules;

namespace NuciText.Grammar.Romanian.Rules;

/// <summary>
/// Adds Romanian diacritics and other high-confidence orthographic fixes.
/// </summary>
internal sealed class RomanianDiacriticsRule : PatternReplacementRuleBase
{
    /// <inheritdoc/>
    public override string Id => "romanian-diacritics";

    /// <inheritdoc/>
    public override string Description => "Adds Romanian diacritics and normalises common orthographic forms.";

    /// <inheritdoc/>
    protected override string DoApply(string text)
    {
        string result = text;

        result = Regex.Replace(result, @"\b([Rr])[aă]bd", "$1ăbd");
        result = Regex.Replace(result, @"\b([Rr])[aă]s([cpt])", "$1ăs$2");
        result = Regex.Replace(result, @"\b([Rr])[aă]t[aă]", "$1ătă");
        result = Regex.Replace(result, @"\b([Rr])[aă]uf", "$1ăuf");
        result = Regex.Replace(result, @"\b([Rr])[aă]z", "$1ăz");
        result = Regex.Replace(result, @"\b([Ss])[aă]ra", "$1ăra");
        result = Regex.Replace(result, @"\b([Tt])[aăâ]ri([sș])", "$1ări$2");
        result = Regex.Replace(result, @"\b([Zz])g[aăâ]r", "$1gâr");
        result = Regex.Replace(result, @"\b([Zz])v[aăâ]p[aăâ]", "$1văpă");

        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]ah([iu])", "șah$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]col", "școl");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]([lt]?)ef", "ș$1ef");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]oca([tț])", "șocat");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]p[aă]g", "șpăg");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt][aâ]n[tț]", "țânț");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]ig([al])", "țig$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]in([tu])", "țin$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]ip([aă])t", "țip$1t");

        result = Regex.Replace(result, @"([Mm])u[sș]ca([tț])", "$1ușca$2");
        result = Regex.Replace(result, @"([Pp])anz", "$1ânz");
        result = Regex.Replace(result, @"([Rr])[aă]uv", "$1ăuv");
        result = Regex.Replace(result, @"([Rr])ein([t])", "$1eîn$2");
        result = Regex.Replace(result, @"([Ss])[aă]pt", "$1ăpt");
        result = Regex.Replace(result, @"([Ss])[aă]rac", "$1ărac");
        result = Regex.Replace(result, @"([Ss])[aă]ri([tț])", "$1ări$2");
        result = Regex.Replace(result, @"([Ss])[aâ]c[aâ]i", "$1âcâi");
        result = Regex.Replace(result, @"([Ss])c[aâ]rb", "$1cârb");
        result = Regex.Replace(result, @"([Ss])c[aâ]rp", "$1cărp");
        result = Regex.Replace(result, @"([Ss])f[aă]d", "$1făd");
        result = Regex.Replace(result, @"([Ss])otu", "$1oțu");
        result = Regex.Replace(result, @"([Ss])t[aâ]n([ac])", "$1tân$2");
        result = Regex.Replace(result, @"([Ss])tr[aâ]n([sș])", "$1trân$2");
        result = Regex.Replace(result, @"([Tt])[aă]cu", "$1ăcu");
        result = Regex.Replace(result, @"([Tt])[aâ]mp", "$1âmp");
        result = Regex.Replace(result, @"([Tt])[aâ]r[aâ]t", "$1ârât");
        result = Regex.Replace(result, @"([Uu])sur([aăâ])", "$1șur$2");
        result = Regex.Replace(result, @"([Vv])[aă]rs", "$1ărs");

        result = Regex.Replace(result, @"([cs])ator", "$1ător");

        result = Regex.Replace(result, @"acâi", "âcâi");
        result = Regex.Replace(result, @"ames", "ameș");
        result = Regex.Replace(result, @"anat", "ânat");
        result = Regex.Replace(result, @"andu", "ându");
        result = Regex.Replace(result, @"anz([aă])t", "ânz$1t");
        result = Regex.Replace(result, @"[aă]d[aă]tor", "ădător");
        result = Regex.Replace(result, @"[aă]rgat", "ărgat");
        result = Regex.Replace(result, @"[aă]lb[aă]t", "ălbăt");
        result = Regex.Replace(result, @"[aăâ]rstn", "ârstn");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([iu])", "ărsat$1");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([o])", "ărsăt$1");
        result = Regex.Replace(result, @"ataf", "ătaf");
        result = Regex.Replace(result, @"avi[tț]i", "ăviți");
        result = Regex.Replace(result, @"avi[tț]u", "ăvitu");
        result = Regex.Replace(result, @"azu([tț])", "ăzu$1");
        result = Regex.Replace(result, @"âcai", "âcâi");
        result = Regex.Replace(result, @"btia", "bția");
        result = Regex.Replace(result, @"emat", "emăt");
        result = Regex.Replace(result, @"ecatui", "ecătui");
        result = Regex.Replace(result, @"ectio", "ecțio");
        result = Regex.Replace(result, @"eg[aă]ti([tț])", "egăti$1");
        result = Regex.Replace(result, @"esnic", "eșnic");
        result = Regex.Replace(result, @"este([dz])", "ește$1");
        result = Regex.Replace(result, @"f[aă]c[aă]t", "făcăt");
        result = Regex.Replace(result, @"f[aă]tui", "fătui");
        result = Regex.Replace(result, @"flator", "flător");
        result = Regex.Replace(result, @"icalo", "icălo");
        result = Regex.Replace(result, @"ietui", "iețui");
        result = Regex.Replace(result, @"latio", "lațio");
        result = Regex.Replace(result, @"l[aă]b[aă]n", "lăbăn");
        result = Regex.Replace(result, @"l[aă]bit", "lăbit");
        result = Regex.Replace(result, @"l[aâ]ng[aă]t", "lângăt");
        result = Regex.Replace(result, @"ldat", "ldăt");
        result = Regex.Replace(result, @"lecti", "lecți");
        result = Regex.Replace(result, @"manal", "mânal");
        result = Regex.Replace(result, @"manț", "mânț");
        result = Regex.Replace(result, @"mbato", "mbăto");
        result = Regex.Replace(result, @"mti", "mți");
        result = Regex.Replace(result, @"nato([sș])", "năto$1");
        result = Regex.Replace(result, @"nsat", "nșat");
        result = Regex.Replace(result, @"ntar", "nțar");
        result = Regex.Replace(result, @"nti", "nți");
        result = Regex.Replace(result, @"olani([tț])", "olăni$1");
        result = Regex.Replace(result, @"osist", "oșist");
        result = Regex.Replace(result, @"pagar", "păgar");
        result = Regex.Replace(result, @"pt[aa]m[aâ]n", "tămân");
        result = Regex.Replace(result, @"rai([nt])", "răi$1");
        result = Regex.Replace(result, @"raji", "răji");
        result = Regex.Replace(result, @"rambu", "râmbu");
        result = Regex.Replace(result, @"([Ff])rant", "$1rânt");
        result = Regex.Replace(result, @"rapun", "răpun");
        result = Regex.Replace(result, @"rator", "rător");
        result = Regex.Replace(result, @"razni", "răzni");
        result = Regex.Replace(result, @"rbar", "rbăr");
        result = Regex.Replace(result, @"rgator", "rgător");
        result = Regex.Replace(result, @"rmas", "rmaș");
        result = Regex.Replace(result, @"rmar", "rmăr");
        result = Regex.Replace(result, @"rmator", "rmător");
        result = Regex.Replace(result, @"([sș])ur[aă]t([^aeiou])", "$1urăt$2");
        result = Regex.Replace(result, @"tacio", "tăcio");
        result = Regex.Replace(result, @"t[aâ]ng", "tâng");
        result = Regex.Replace(result, @"[tț][aă]r[aă]n", "țăran");
        result = Regex.Replace(result, @"[tț][aâ]nț", "țânț");
        result = Regex.Replace(result, @"t[aă]p[aâ]n", "tăpân");
        result = Regex.Replace(result, @"tramu", "trămu");
        result = Regex.Replace(result, @"upar", "upăr");
        result = Regex.Replace(result, @"ustin", "usțin");
        result = Regex.Replace(result, @"utio", "uțio");
        result = Regex.Replace(result, @"var[aă][sș]", "varăș");
        result = Regex.Replace(result, @"vrat", "vrăt");
        result = Regex.Replace(result, @"([^i])zator", "$1zător");

        result = Regex.Replace(result, @"anător", "ânător");
        result = Regex.Replace(result, @"ânator", "ânător");
        result = Regex.Replace(result, @"ani([sș])t", "ăni$1t");

        // Fixes
        result = Regex.Replace(result, @"([Ss])[aâ]năto([sș])", "$1ănăto$2");

        // Endings
        result = Regex.Replace(result, @"ant(i|ii|ilor)\b", "anț$1");
        result = Regex.Replace(result, @"([^ln])ar(i|ul|ule|ului)?\b", "$1ăr$2");
        result = Regex.Replace(result, @"as(ul|ule|ului)?\b", "aș$1");
        result = Regex.Replace(result, @"at(i|ii)\b", "aț$1");
        result = Regex.Replace(result, @"at(it)\b", "ăt$1");
        result = Regex.Replace(result, @"avi(e|t|te)\b", "ăvi$1");
        result = Regex.Replace(result, @"avit(i|ii|ilor)\b", "ăviț$1");
        result = Regex.Replace(result, @"[aă]l[aă]tor(i|ii|ilor|ul|ule|ului)?\b", "ălător$1");
        result = Regex.Replace(result, @"isor(i|ii|ilor|ul|ule|ului)?\b", "ișor$1");
        result = Regex.Replace(result, @"it(i|ii|ilor)\b", "iț$1");
        result = Regex.Replace(result, @"ret(i|ii|ilor)?\b", "reț$1");
        result = Regex.Replace(result, @"s(i|ii|iile|iilor|ile|ilor|ti|tii|tilor|tiilor)\b", "ș$1");
        result = Regex.Replace(result, @"([^ș])t(i|ie|ii|iile|iilor|ile|ilor)\b", "$1ț$2");
        result = Regex.Replace(result, @"(re)t(ul|ule|ului)\b", "$1ț$2");
        result = Regex.Replace(result, @"ut(i|ii|ilor)\b", "uț$1");

        return result;
    }

    private string RegexReplaceMatchingFirstLetterCase(
        string input,
        string pattern,
        string replacement)
        => Regex.Replace(
            input,
            pattern,
            m => (char.IsUpper(m.Value[0]) ? char.ToUpper(replacement[0]) : char.ToLower(replacement[0])) + replacement[1..]
                .Replace("$1", m.Groups[1].Value)
                .Replace("$2", m.Groups[2].Value));
}