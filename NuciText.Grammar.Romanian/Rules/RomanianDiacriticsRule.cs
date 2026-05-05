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

        //
        result = Regex.Replace(result, @"\b([Cc])a[\s]am\b", "$1ă am");
        result = Regex.Replace(result, @"\b([Cc])a[\s][iî]mi\b", "$1ă îmi");
        result = Regex.Replace(result, @"\b([Cc])a[\s][aă]\b", "$1a să");

        // Whole words
        result = Regex.Replace(result, @"\b([Aa])sa\b", "$1șa");
        result = Regex.Replace(result, @"\b([Aa])s\b", "$1ș");
        result = Regex.Replace(result, @"\b([Dd])aca\b", "$1acă");
        result = Regex.Replace(result, @"\b([Mm])ulta\b", "$1ultă");
        result = Regex.Replace(result, @"\b([Nn])oastra\b", "$1oastră");
        result = Regex.Replace(result, @"\b([Oo])data\b", "$1dată");
        result = Regex.Replace(result, @"\b([Oo])r[aă][sș]el\b", "$1rășel");
        result = Regex.Replace(result, @"\b([Pp])una\b", "$1ună");
        result = Regex.Replace(result, @"\b([Ss])a\b", "$1ă");
        result = Regex.Replace(result, @"\b([Tt])au\b", "$1ău");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]n\b", "în");

        result = Regex.Replace(result, @"\b([PRpr])[aă]m[aâ]n", "$1ămân");

        result = Regex.Replace(result, @"\b([Aa])lat", "$1lăt");
        result = Regex.Replace(result, @"\b([Bb])antu", "$1ântu");
        result = Regex.Replace(result, @"\b([Bb])orat", "$1orât");
        result = Regex.Replace(result, @"\b([Cc])[aă]l[aă]([rt])", "$1ălă$2");
        result = Regex.Replace(result, @"\b([Cc])[aâ]in([ei])", "$1âin$2");
        result = Regex.Replace(result, @"\b([Cc])[aâ]te([^l])", "$1âte$2");
        result = Regex.Replace(result, @"\b([Cc])aldu", "$1ăldu");
        result = Regex.Replace(result, @"\b([Cc])arnos", "$1ărnos");
        result = Regex.Replace(result, @"\b([Cc])ires", "$1ireș");
        result = Regex.Replace(result, @"\b([Ff])acea", "$1ăcea");
        result = Regex.Replace(result, @"\b([Rr])[aă]bd", "$1ăbd");
        result = Regex.Replace(result, @"\b([Rr])[aă]s([ăcpstu])", "$1ăs$2");
        result = Regex.Replace(result, @"\b([Rr])[aă]t[aă]", "$1ătă");
        result = Regex.Replace(result, @"\b([Rr])[aă]u([ft])", "$1ău$2");
        result = Regex.Replace(result, @"\b([Rr])[aă]z", "$1ăz");
        result = Regex.Replace(result, @"\b([Rr])o[sș]([c])", "$1oș$2");
        result = Regex.Replace(result, @"\b([Ss])[aă]ra", "$1ăra");
        result = Regex.Replace(result, @"\b([Tt])[aăâ]ri([sș])", "$1ări$2");
        result = Regex.Replace(result, @"\b([Uu])ra([tț])", "$1râ$2");
        result = Regex.Replace(result, @"\b([Zz])g[aăâ]r", "$1gâr");
        result = Regex.Replace(result, @"\b([Zz])v[aăâ]p[aăâ]", "$1văpă");

        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]mpreu", "împreu");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]nai", "înai");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]ncepe", "începe");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]nc([el])", "înc$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]nfu", "înfu");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]n([gl])", "în$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]not", "înot");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]nsea", "însea");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]nto", "înto");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ii]ntr", "într");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]([lt]?)ef", "ș$1ef");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]ah([iu])", "șah$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]([ae])rp", "ș$1rp");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]col", "școl");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]erif", "șerif");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]obo", "șobo");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]oca([tț])", "șocat");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]p[aă]g", "șpăg");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]ter", "șter");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]tiu", "știu");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Ss]us[tț]([i])", "susț$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[SȘsș]ans", "șans");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[SȘss]ust([aă])", "șust$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt][aâ]n[tț]", "țânț");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]eav", "țeav");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]ig([al])", "țig$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]in([tu])", "țin$1");
        result = RegexReplaceMatchingFirstLetterCase(result, @"\b[Tt]ip([aă].)", "țip$1");

        result = Regex.Replace(result, @"([Aa])mana", "$1mâna");
        result = Regex.Replace(result, @"([Aa])paru", "$1păru");
        result = Regex.Replace(result, @"([Aa])rata", "$1răta");
        result = Regex.Replace(result, @"([Aa])tr[aă]g[aă]", "$1trăgă");
        result = Regex.Replace(result, @"([Bb])[aă][sș]ti", "$1ăști");
        result = Regex.Replace(result, @"([Bb])[aă]g[aă]([c])", "$1ăgă$2");
        result = Regex.Replace(result, @"([Bb])[aă]rb([aeio])", "$1ărb$2");
        result = Regex.Replace(result, @"([Bb])[aă]tut", "$1ătut");
        result = Regex.Replace(result, @"([Bb])[aă]ut", "$1ăut");
        result = Regex.Replace(result, @"([Bb])afto", "$1ăfto");
        result = Regex.Replace(result, @"([Bb])arc", "$1ărc");
        result = Regex.Replace(result, @"([Bb])arf", "$1ârf");
        result = Regex.Replace(result, @"([Bb])atr", "$1ătr");
        result = Regex.Replace(result, @"([Bb])esin", "$1eșin");
        result = Regex.Replace(result, @"([Bb])etiv", "$1ețiv");
        result = Regex.Replace(result, @"([Cc])[aă][tț]el", "$1ățel");
        result = Regex.Replace(result, @"([Cc])[aă]lug", "$1ălug");
        result = Regex.Replace(result, @"([Cc])[aă]m[aă]tar", "$1ămătar");
        result = Regex.Replace(result, @"([Cc])[aă]p[sș]u", "$1ăpșu");
        result = Regex.Replace(result, @"([Cc])[aă]pitan", "$1ăpitan");
        result = Regex.Replace(result, @"([Cc])[aă]ptu[sș]", "$1ăptuș");
        result = Regex.Replace(result, @"([Cc])[aă]s[aă]p", "$1ăsăp");
        result = Regex.Replace(result, @"([Cc])[aă]s[aă]to", "$1ăsăto");
        result = Regex.Replace(result, @"([Cc])[aă]ut([aă])t", "$1ăut$2t");
        result = Regex.Replace(result, @"([Cc])[aâ][sș]tig", "$1âștig");
        result = Regex.Replace(result, @"([Cc])[aâ]nta([nrt])", "$1ânta$2");
        result = Regex.Replace(result, @"([Cc])[aâ]rn[aă]c", "$1ârnăc");
        result = Regex.Replace(result, @"([Cc])apc", "$1ăpc");
        result = Regex.Replace(result, @"([Cc])lad", "$1lăd");
        result = Regex.Replace(result, @"([Cc])ur[aă][tț]", "$1urăț");
        result = Regex.Replace(result, @"([Ff])leosc", "$1leoșc");
        result = Regex.Replace(result, @"([Ff])acut", "$1ăcut");
        result = Regex.Replace(result, @"([Ff])rant", "$1rânt");
        result = Regex.Replace(result, @"([Gg])arz", "$1ărz");
        result = Regex.Replace(result, @"([Gg])ase([sș])", "$1ăse$2");
        result = Regex.Replace(result, @"([Gg])rajda", "$1răjda");
        result = Regex.Replace(result, @"([Jj])uc[aă]to", "$1ucăto");
        result = Regex.Replace(result, @"([Mm])[aâ]r[sș]([aă])v", "$1ârș$2v");
        result = Regex.Replace(result, @"([Mm])agar", "$1ăgar");
        result = Regex.Replace(result, @"([Mm])an([aâ])n", "$1ănân");
        result = Regex.Replace(result, @"([Mm])anam", "$1ânam");
        result = Regex.Replace(result, @"([Mm])anc", "$1ânc");
        result = Regex.Replace(result, @"([Mm])u[sș]ca([tț])", "$1ușca$2");
        result = Regex.Replace(result, @"([Mm])uti([tț])", "$1uți$2");
        result = Regex.Replace(result, @"([Oo])([bn])tinu", "$1$2ținu");
        result = Regex.Replace(result, @"([Oo])ra[sș]", "$1raș");
        result = Regex.Replace(result, @"([Oo])ra[sș]elel", "$1rășelel");
        result = Regex.Replace(result, @"([Oo])rti([mnrtț])", "$1rți$2");
        result = Regex.Replace(result, @"([Pp])anz", "$1ânz");
        result = Regex.Replace(result, @"([Pp])are([ar])", "$1ăre$2");
        result = Regex.Replace(result, @"([Pp])lacer", "$1lăcer");
        result = Regex.Replace(result, @"([Pp])usc", "$1ușc");
        result = Regex.Replace(result, @"([Rr])agu", "$1ăgu");
        result = Regex.Replace(result, @"([Rr])[aă]uv", "$1ăuv");
        result = Regex.Replace(result, @"([Rr])ein([t])", "$1eîn$2");
        result = Regex.Replace(result, @"([Ss])[aă]pt", "$1ăpt");
        result = Regex.Replace(result, @"([Ss])[aă]rac", "$1ărac");
        result = Regex.Replace(result, @"([Ss])[aă]rb[aă]t", "$1ărbăt");
        result = Regex.Replace(result, @"([Ss])[aă]ri([tț])", "$1ări$2");
        result = Regex.Replace(result, @"([Ss])[aâ]c[aâ]i", "$1âcâi");
        result = Regex.Replace(result, @"([Ss])[aâ]mb[aă]t", "$1âmbăt");
        result = Regex.Replace(result, @"([Ss])c[aă]ld", "$1căld");
        result = Regex.Replace(result, @"([Ss])c[aâ]rb", "$1cârb");
        result = Regex.Replace(result, @"([Ss])c[aâ]rp", "$1cărp");
        result = Regex.Replace(result, @"([Ss])f[aă]d", "$1făd");
        result = Regex.Replace(result, @"([Ss])otu", "$1oțu");
        result = Regex.Replace(result, @"([Ss])t[aâ]n([ac])", "$1tân$2");
        result = Regex.Replace(result, @"([Ss])tr[aâ]n([sș])", "$1trân$2");
        result = Regex.Replace(result, @"([Tt])[aă]cu", "$1ăcu");
        result = Regex.Replace(result, @"([Tt])[aă]ier", "$1ăier");
        result = Regex.Replace(result, @"([Tt])[aâ]mp", "$1âmp");
        result = Regex.Replace(result, @"([Tt])[aâ]rco", "$1ârco");
        result = Regex.Replace(result, @"([Tt])[aâ]rn", "$1ârn");
        result = Regex.Replace(result, @"([Tt])[aâ]r[aâ]t", "$1ârât");
        result = Regex.Replace(result, @"([Uu])sur([aăâ])", "$1șur$2");
        result = Regex.Replace(result, @"([Vv])[aă]car", "$1ăcar");
        result = Regex.Replace(result, @"([Vv])[aă]rs", "$1ărs");
        result = Regex.Replace(result, @"([Vv])oua", "$1ouă");

        result = Regex.Replace(result, @"([^i])rmator", "$1rmător");
        result = Regex.Replace(result, @"([^i])zator", "$1zător");
        result = Regex.Replace(result, @"([^j])dari([ei])", "$1dări$2");
        result = Regex.Replace(result, @"([A-Za-z])[aă]rgat", "$1ărgat");
        result = Regex.Replace(result, @"([cs])ator", "$1ător");
        result = Regex.Replace(result, @"([fv])[aâ]r[sș]", "$1ârș");
        result = Regex.Replace(result, @"([ir])mari", "$1mări");
        result = Regex.Replace(result, @"([sș])ur[aă]t([^aeiou])", "$1urăt$2");

        result = Regex.Replace(result, @"acâi", "âcâi");
        result = Regex.Replace(result, @"ames([^t])", "ameș$1");
        result = Regex.Replace(result, @"andu", "ându");
        result = Regex.Replace(result, @"[aă]c[aă]t", "ăcat");
        result = Regex.Replace(result, @"[aă]c[aă]to", "ăcăto");
        result = Regex.Replace(result, @"[aă]d[aă]tor", "ădător");
        result = Regex.Replace(result, @"[aă]lb[aă]t", "ălbăt");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([iu])", "ărsat$1");
        result = Regex.Replace(result, @"[aăâ]rs[aăâ]t([o])", "ărsăt$1");
        result = Regex.Replace(result, @"[aăâ]rstn", "ârstn");
        result = Regex.Replace(result, @"agacio", "ăgăcio");
        result = Regex.Replace(result, @"anz([aă])t", "ânz$1t");
        result = Regex.Replace(result, @"ataf", "ătaf");
        result = Regex.Replace(result, @"ati([ou])n", "ați$1n");
        result = Regex.Replace(result, @"avi[tț]i", "ăviți");
        result = Regex.Replace(result, @"avi[tț]u", "ăvitu");
        result = Regex.Replace(result, @"azu([tț])", "ăzu$1");
        result = Regex.Replace(result, @"ălato", "ălăto");
        result = Regex.Replace(result, @"ăluga", "ălugă");
        result = Regex.Replace(result, @"ăptam", "ăptăm");
        result = Regex.Replace(result, @"âcai", "âcâi");
        result = Regex.Replace(result, @"ârn[aă]c", "ârnăc");
        result = Regex.Replace(result, @"bdat", "bdăt");
        result = Regex.Replace(result, @"berta([tț])", "bertă$1");
        result = Regex.Replace(result, @"btia", "bția");
        result = Regex.Replace(result, @"cetator", "cetător");
        result = Regex.Replace(result, @"ctio", "cțio");
        result = Regex.Replace(result, @"cuvan", "cuvân");
        result = Regex.Replace(result, @"danc", "dânc");
        result = Regex.Replace(result, @"dauga", "dăuga");
        result = Regex.Replace(result, @"dusi([emtț])", "duși$1");
        result = Regex.Replace(result, @"ecatui", "ecătui");
        result = Regex.Replace(result, @"ectio", "ecțio");
        result = Regex.Replace(result, @"eg[aă]ti([tț])", "egăti$1");
        result = Regex.Replace(result, @"eg[aă]tor", "egător");
        result = Regex.Replace(result, @"entin", "ențin");
        result = Regex.Replace(result, @"erset", "erșet");
        result = Regex.Replace(result, @"ertare[tț]", "ertăreț");
        result = Regex.Replace(result, @"esnic", "eșnic");
        result = Regex.Replace(result, @"este([dz])", "ește$1");
        result = Regex.Replace(result, @"f[aă]c[aă]t", "făcăt");
        result = Regex.Replace(result, @"f[aă]tui", "fătui");
        result = Regex.Replace(result, @"flator", "flător");
        result = Regex.Replace(result, @"gata([sș])", "gătaș");
        result = Regex.Replace(result, @"gusit", "gușit");
        result = Regex.Replace(result, @"icalo", "icălo");
        result = Regex.Replace(result, @"ietui", "iețui");
        result = Regex.Replace(result, @"indato", "indăto");
        result = Regex.Replace(result, @"inti", "inți");
        result = Regex.Replace(result, @"l([cd])at", "l$1ăt");
        result = Regex.Replace(result, @"l[aă]b[aă]n", "lăbăn");
        result = Regex.Replace(result, @"l[aă]bit", "lăbit");
        result = Regex.Replace(result, @"l[aâ]ng[aă]t", "lângăt");
        result = Regex.Replace(result, @"l[aâ]nui", "lănui");
        result = Regex.Replace(result, @"latio", "lațio");
        result = Regex.Replace(result, @"lecti", "lecți");
        result = Regex.Replace(result, @"ltator", "ltător");
        result = Regex.Replace(result, @"m[aă]n[aă]t\b", "mănat");
        result = Regex.Replace(result, @"m[aă]n[aă]ti", "mănati");
        result = Regex.Replace(result, @"m[aă]n[aă]to", "mănăto");
        result = Regex.Replace(result, @"m[aă]n[aă]tu", "mănatu");
        result = Regex.Replace(result, @"manal", "mânal");
        result = Regex.Replace(result, @"manț", "mânț");
        result = Regex.Replace(result, @"mariil", "măriil");
        result = Regex.Replace(result, @"mbato", "mbăto");
        result = Regex.Replace(result, @"metit", "mețit");
        result = Regex.Replace(result, @"minti", "minți");
        result = Regex.Replace(result, @"mti", "mți");
        result = Regex.Replace(result, @"nant([ae])", "nanț$1");
        result = Regex.Replace(result, @"nato([sș])", "năto$1");
        result = Regex.Replace(result, @"nint([aă])t", "ninț$1t");
        result = Regex.Replace(result, @"nun[tț]a([tț])", "nunța$1");
        result = Regex.Replace(result, @"ol[tț]o([sș])", "olțo$1");
        result = Regex.Replace(result, @"olani([tț])", "olăni$1");
        result = Regex.Replace(result, @"olse", "olșe");
        result = Regex.Replace(result, @"onditi", "ondiți");
        result = Regex.Replace(result, @"onstie", "onștie");
        result = Regex.Replace(result, @"osist", "oșist");
        result = Regex.Replace(result, @"pagar", "păgar");
        result = Regex.Replace(result, @"pcau", "pcău");
        result = Regex.Replace(result, @"pranc", "prânc");
        result = Regex.Replace(result, @"ptămana", "ptămâna");
        result = Regex.Replace(result, @"radin", "rădin");
        result = Regex.Replace(result, @"ragut", "răguț");
        result = Regex.Replace(result, @"rai([nt])", "răi$1");
        result = Regex.Replace(result, @"raji", "răji");
        result = Regex.Replace(result, @"rambu", "râmbu");
        result = Regex.Replace(result, @"rante", "rânte");
        result = Regex.Replace(result, @"rapun", "răpun");
        result = Regex.Replace(result, @"razni", "răzni");
        result = Regex.Replace(result, @"rbar", "rbăr");
        result = Regex.Replace(result, @"rdaria", "rdăria");
        result = Regex.Replace(result, @"ret(e|ei|ele|elor|i|ii|ilor|u|ul|ule|ului)?", "reț$1");
        result = Regex.Replace(result, @"resel", "reșel");
        result = Regex.Replace(result, @"rgator", "rgător");
        result = Regex.Replace(result, @"rmar", "rmăr");
        result = Regex.Replace(result, @"rmas", "rmaș");
        result = Regex.Replace(result, @"rsav", "rșav");
        result = Regex.Replace(result, @"[tț][aă]r[aă]n", "țăran");
        result = Regex.Replace(result, @"[tț][aâ]nț", "țânț");
        result = Regex.Replace(result, @"[tț]in[aă]tor", "ținător");
        result = Regex.Replace(result, @"t[aă]p[aâ]n", "tăpân");
        result = Regex.Replace(result, @"t[aâ]ng", "tâng");
        result = Regex.Replace(result, @"tacio", "tăcio");
        result = Regex.Replace(result, @"tenti", "tenți");
        result = Regex.Replace(result, @"tigat([a-z])", "tigăt$1");
        result = Regex.Replace(result, @"tramu", "trămu");
        result = Regex.Replace(result, @"trani", "trâni");
        result = Regex.Replace(result, @"tusit", "tușit");
        result = Regex.Replace(result, @"ucatar", "ucătar");
        result = Regex.Replace(result, @"ugac", "ugăc");
        result = Regex.Replace(result, @"upar", "upăr");
        result = Regex.Replace(result, @"ustin", "usțin");
        result = Regex.Replace(result, @"utator", "utător");
        result = Regex.Replace(result, @"utio", "uțio");
        result = Regex.Replace(result, @"var[aă][sș]", "varăș");
        result = Regex.Replace(result, @"vrat", "vrăt");
        result = Regex.Replace(result, @"ziti", "ziți");

        // Endings
        result = Regex.Replace(result, @"([^â][^i])[tț]easc[aă]\b", "$1țească");
        result = Regex.Replace(result, @"([^bcl])ata\b", "$1ața");
        result = Regex.Replace(result, @"([^cdglmnstv])ar(i|ul|ule|ului)?\b", "$1ăr$2");
        result = Regex.Replace(result, @"([^iu])tam\b", "$1țam");
        result = Regex.Replace(result, @"([^sș])t(i|ia|ie|iei|ii|iile|iilor|ile|ilor)\b", "$1ț$2");
        result = Regex.Replace(result, @"([A-Za-z])este\b", "$1ește");
        result = Regex.Replace(result, @"([a])ti(i|ile|ilor|u|ul|ului)\b", "$1țiu");
        result = Regex.Replace(result, @"([n])ita\b", "$1ița");
        //result = Regex.Replace(result, @"([ru])[tț]i[tț](u|ul|ule|ului)?\b", "$1țit$2");

        result = Regex.Replace(result, @"[tț]e[sș]t([ei])\b", "țeșt$1");

        result = Regex.Replace(result, @"[aă]l[aă]tor(i|ii|ilor|ul|ule|ului)?\b", "ălător$1");
        result = Regex.Replace(result, @"ant(a|ei|i|ii|ilor)\b", "anț$1");
        result = Regex.Replace(result, @"aster(e|ea|i|ii)\b", "așter$1");
        result = Regex.Replace(result, @"at(i|ii)\b", "aț$1");
        result = Regex.Replace(result, @"at(it)\b", "ăt$1");
        result = Regex.Replace(result, @"avi(e|t|te)\b", "ăvi$1");
        result = Regex.Replace(result, @"avit(i|ii|ilor)\b", "ăviț$1");
        result = Regex.Replace(result, @"ea(sc|z)a\b", "ea$1ă");
        result = Regex.Replace(result, @"eamna\b", "eamnă");
        result = Regex.Replace(result, @"elata\b", "elată");
        result = Regex.Replace(result, @"esti\b", "ești");
        result = Regex.Replace(result, @"fas(i|ii|ilor|u|ul|ule|ului)?\b", "faș$1");
        result = Regex.Replace(result, @"iaza\b", "iază");
        result = Regex.Replace(result, @"int(a|e|ei|ele|elor|i|ii|ilor)\b", "inț$1");
        result = Regex.Replace(result, @"isor(i|ii|ilor|u|ul|ule|ului)?\b", "ișor$1");
        result = Regex.Replace(result, @"iste\b", "iște");
        result = Regex.Replace(result, @"it(e|ei|ele|elor|i|ii|ilor)\b", "iț$1");
        result = Regex.Replace(result, @"ldut(i|ii|ilor|u|ul|ule|ului)?\b", "lduț$1");
        result = Regex.Replace(result, @"lus(i|ii|ilor|u|ul|ule|ului)?\b", "luș$1");
        result = Regex.Replace(result, @"mu[tț]i[tț](i|ii|ilor)\b", "muțiț$1");
        result = Regex.Replace(result, @"nala\b", "nală");
        result = Regex.Replace(result, @"nanc\b", "nânc");
        result = Regex.Replace(result, @"nas(ul|ule|ului)?\b", "naș$1");
        result = Regex.Replace(result, @"ng[aă]tor(i|ii|ilor|u|ul|ule|ului)?\b", "ngător$1");
        result = Regex.Replace(result, @"r([cg])a\b", "r$1ă");
        result = Regex.Replace(result, @"ramt\b", "râmt");
        result = Regex.Replace(result, @"ran(e|ei|eii|i|ii|ilor|u|ul|ule|ului)?\b", "rân$1");
        result = Regex.Replace(result, @"ranesc\b", "rănesc");
        result = Regex.Replace(result, @"rcut(a|e)\b", "rcuț$1");
        result = Regex.Replace(result, @"ret(i|ii|ilor)?\b", "reț$1");
        result = Regex.Replace(result, @"risca\b", "rișca");
        result = Regex.Replace(result, @"rtine\b", "rține");
        result = Regex.Replace(result, @"s(i|ii|iile|iilor|ile|ilor|im|ite|iti|itilor|ti|tii|tilor|tiilor)\b", "ș$1");
        result = Regex.Replace(result, @"sca\b", "scă");
        result = Regex.Replace(result, @"tas(i|ii|ilor|u|ul|ule|ului)?\b", "taș$1");
        result = Regex.Replace(result, @"temator(i|ii|ilor|u|ul|ule|ului)?\b", "temător$1");

        // Fixes
        result = Regex.Replace(result, @"([ăâ])teni", "$1țeni");
        result = Regex.Replace(result, @"([Ss])[aâ]năto([sș])", "$1ănăto$2");
        result = Regex.Replace(result, @"daugaț", "dăugaț");
        result = Regex.Replace(result, @"iănist", "ianist");

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