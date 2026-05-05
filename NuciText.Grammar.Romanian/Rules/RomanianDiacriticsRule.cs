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

        result = Regex.Replace(result, @"\b([Tt])[aăâ]ri([sș])", "$1ări$2");
        result = Regex.Replace(result, @"\b([Zz])g[aăâ]r", "$1gâr");
        result = Regex.Replace(result, @"\b([Zz])v[aăâ]p[aăâ]", "$1văpă");

        result = Regex.Replace(result, @"\bSah([iu])", "Șah$1");
        result = Regex.Replace(result, @"\bS([lt]?)ef", "Ș$1ef");
        result = Regex.Replace(result, @"\bSp[aă]g", "Șpăg");
        result = Regex.Replace(result, @"\bTip([aă])t", "Țip$1t");

        result = Regex.Replace(result, @"\bs([lt]?)ef", "ș$1ef");
        result = Regex.Replace(result, @"\bsah([iu])", "șah$1");
        result = Regex.Replace(result, @"\btip([aă])t", "țip$1t");

        result = Regex.Replace(result, @"([Mm])u[sș]ca([tț])", "$1ușca$2");
        result = Regex.Replace(result, @"([Pp])anz", "$1ânz");
        result = Regex.Replace(result, @"([Ss])[aă]r[aă]([tț])", "$1ăra$2");
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
        result = Regex.Replace(result, @"[aă]rgat", "ărgăt");
        result = Regex.Replace(result, @"[aăâ]rstn", "ârstn");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([iu])", "ărsat$1");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([o])", "ărsăt$1");
        result = Regex.Replace(result, @"ataf", "ătaf");
        result = Regex.Replace(result, @"avi[tț]i", "ăviți");
        result = Regex.Replace(result, @"avi[tț]u", "ăvitu");
        result = Regex.Replace(result, @"azu([tț])", "ăzu$1");
        result = Regex.Replace(result, @"âcai", "âcâi");
        result = Regex.Replace(result, @"emat", "emăt");
        result = Regex.Replace(result, @"esnic", "eșnic");
        result = Regex.Replace(result, @"icalo", "icălo");
        result = Regex.Replace(result, @"l[aă]b[aă]n", "lăbăn");
        result = Regex.Replace(result, @"ntar", "nțar");
        result = Regex.Replace(result, @"rai([nt])", "răi$1");
        result = Regex.Replace(result, @"raji", "răji");
        result = Regex.Replace(result, @"rator", "rător");
        result = Regex.Replace(result, @"rbar", "rbăr");
        result = Regex.Replace(result, @"rgator", "rgător");
        result = Regex.Replace(result, @"rmas", "rmaș");
        result = Regex.Replace(result, @"rmator", "rmător");
        result = Regex.Replace(result, @"sp[aă]g", "șpăg");
        result = Regex.Replace(result, @"[tț][aă]r[aă]n", "țăran");
        result = Regex.Replace(result, @"upar", "upăr");
        result = Regex.Replace(result, @"ustin", "usțin");
        result = Regex.Replace(result, @"utio", "uțio");
        result = Regex.Replace(result, @"var[aă][sș]", "varăș");
        result = Regex.Replace(result, @"zator", "zător");

        result = Regex.Replace(result, @"anător", "ânător");
        result = Regex.Replace(result, @"ânator", "ânător");
        result = Regex.Replace(result, @"ani([sș])t", "ăni$1t");

        // Endings
        result = Regex.Replace(result, @"ant(i|ii|ilor)\b", "anț$1");
        result = Regex.Replace(result, @"as(ul|ule|ului)?\b", "aș$1");
        result = Regex.Replace(result, @"at(i|ii)\b", "aț$1");
        result = Regex.Replace(result, @"avi(e|t|te)\b", "ăvi$1");
        result = Regex.Replace(result, @"avit(i|ii|ilor)\b", "ăviț$1");
        result = Regex.Replace(result, @"it(i|ii|ilor)\b", "iț$1");
        result = Regex.Replace(result, @"ret(i|ii|ilor)?\b", "reț$1");
        result = Regex.Replace(result, @"s(i|ii|iile|iilor|ile|ilor|ti|tii|tilor|tiilor)\b", "ș$1");
        result = Regex.Replace(result, @"([^ș])ti(i|ie|ii|ile|ilor|lor)\b", "$1ți$2");
        result = Regex.Replace(result, @"(re)t(ul|ule|ului)\b", "$1ț$2");
        result = Regex.Replace(result, @"ut(i|ii|ilor)\b", "uț$1");

        return result;
    }
}