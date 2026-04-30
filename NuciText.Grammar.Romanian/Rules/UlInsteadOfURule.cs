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
                "următor", "vânt", "vameș", "val", "vârf", "vinovat", "vot", "zid",
                "abandonat", "abordat", "absolvit", "absorbit", "achiziționat", "acolit", "acoperit", "acordat", "activist", "actualizat",
                "acumulat", "acuzat", "adecvat", "admirat", "adorat", "adunat", "adus", "aduși", "adăugat", "afacerist",
                "afemeiat", "aflat", "afurisit", "agent", "ahtiat", "aiurist", "ajutat", "alarmat", "alchemist", "alcătuit",
                "alergat", "alergător", "ales", "alienat", "alimentat", "aliniat", "alintat", "alipit", "alocat", "alungat",
                "alungător", "alăturat", "ambalat", "ambulant", "amenajat", "amenințat", "amenințător", "amestecat", "amețit", "amețitor",
                "amintit", "amorezat", "amortizat", "amorțit", "amputat", "amuzant", "amuzat", "amânat", "analist", "analizat",
                "anarhist", "ancorat", "andocat", "antrenat", "anunțat", "aparținător", "apelat", "aprins", "apropriat", "apărut",
                "aranjat", "arborat", "aristocrat", "arogant", "arondat", "articulat", "artist", "aruncat", "arătat", "asamblat",
                "ascultător", "aspirat", "astupat", "atenționat", "atins", "aurist", "avantajat", "avertizat", "avocat", "avut",
                "bambus", "baptist", "bazat", "beneficiat", "biciclist", "binecuvântat", "binefăcător", "binevenit", "blasfemiator", "blestemat",
                "blestemător", "blocant", "blocat", "bogătaș", "bolșevic", "bolșevist", "bolșevizat", "bomardat", "borfaș", "borât",
                "bos", "bot", "briliant", "bucuros", "bucătar", "budist", "burdușit", "băftos", "bărbat", "bărbierit",
                "bătrân", "bătut", "băștinaș", "cactus", "calculat", "calibrat", "calificat", "camerist", "capitalist", "captat",
                "capturat", "carantinat", "carburant", "celebrat", "centrist", "cercetător", "certat", "chemat", "chimist", "chinuit",
                "cinstit", "ciupitist", "clarificat", "clocotit", "coborât", "colaborat", "colectat", "colonialist", "colonist", "colonizat",
                "colorant", "colorat", "comandant", "comandat", "combinat", "complicat", "comunist", "condamnat", "confederalist", "confederalizat",
                "confederat", "confiscat", "confuzat", "consacrat", "considerat", "conspirant", "conspirat", "constructor", "construit", "consumat",
                "consumerist", "consătean", "contrariat", "controversat", "convenit", "convertit", "convingător", "convins", "cooperant", "cooperat",
                "copt", "corespondent", "cotropit", "craftat", "creat", "creaționist", "credincios", "crescător", "creștin", "crucificat",
                "culegător", "cules", "cultist", "cumințit", "cumnat", "cumpănit", "cumpărat", "cumpătat", "cunoscut", "cuprins",
                "cuprinzător", "curajos", "curat", "cutreierat", "cuțitar", "câcat", "călcat", "călduros", "călduț", "călugăr",
                "călăreț", "călător", "cămătar", "căpcăun", "căpitan", "căptușit", "căpșunar", "cărat", "căsătorit", "dascăl",
                "deblocant", "deblocat", "decalibrat", "defalcat", "defrișat", "delegat", "deluros", "delăsător", "demarat", "demarcat",
                "demontat", "denumit", "depanat", "dependent", "deportat", "depozitat", "deputat", "depărtat", "deranjant", "deranjat",
                "derivat", "descoperit", "descrescător", "descurajat", "descurcat", "descurcător", "descălecat", "descărcător", "desfundat", "desprins",
                "destabilizant", "destabilizat", "destabilizator", "destrămat", "devalizat", "devenit", "devotat", "dezacordat", "dezamăgit", "dezaranjat",
                "dezasamblat", "dezavantajat", "dezertat", "dezgustat", "dezgustător", "dezintegrat", "dezmierdat", "dezmințit", "dezolant", "dezolat",
                "dezpodobit", "deșertic", "deștept", "deținut", "dichisit", "digitalizat", "diplomat", "disperat", "disputat", "dispărut",
                "distanțat", "distins", "distrugător", "distrus", "dizolvat", "doborât", "domesticat", "domesticit", "donat", "dormit",
                "dospit", "dramatizat", "dărâmat", "dărâmător", "echilibrat", "eclipsat", "eclozat", "ecologist", "economisit", "educat",
                "ejaculat", "elaborat", "eliberat", "elocvent", "emancipat", "enervant", "enervat", "erudit", "evacuat", "evadat",
                "evaluat", "evitant", "evitat", "evoluat", "evoluționist", "excavat", "executat", "expert", "expirat", "explodat",
                "explorat", "exportat", "exportator", "extins", "extremist", "fabricat", "facturat", "faimos", "falimentat", "familist",
                "farmat", "fascist", "favorit", "favorizat", "federalist", "federalizat", "federat", "fericit", "ferit", "fermentat",
                "fertilizant", "fertilizat", "fertilizator", "fidelizat", "filmat", "finalizat", "finisat", "fluierat", "fochist", "forfecat",
                "fortificat", "fost", "fotbalist", "frecat", "fricos", "friguros", "fript", "frumos", "frânt", "fugit",
                "funcțional", "fundaș", "furios", "fuzionat", "făcător", "garant", "garantat", "generat", "generos", "georgist",
                "gesticulat", "ghiftuit", "glumeț", "golaș", "golit", "gras", "greșit", "grănicer", "gândit", "gânditor",
                "găletar", "găsit", "găurit", "hotărât", "hoț", "hrănit", "hrănitor", "idealist", "iertat", "ieșit",
                "ignorant", "ignorat", "ilustrat", "ilustrator", "iluzionist", "imaginat", "imparțial", "imperialist", "impertinent", "implicat",
                "important", "importat", "importator", "impozant", "improvizat", "incert", "inclus", "industrialist", "infect", "infectat",
                "inimos", "inspirat", "integralist", "integrat", "inteligent", "interesat", "intimidat", "intrat", "ionizat", "iscat",
                "iscusit", "islamist", "isteț", "iubit", "izolant", "izolat", "jucat", "jurat", "jurist", "jurnalist",
                "laborant", "laborios", "laburist", "legat", "legist", "leneș", "locotenent", "locuit", "locuitor", "lucrător",
                "lunetist", "lăbărțat", "lăsat", "lăsător", "marcat", "mareșal", "marxist", "mascat", "materialist", "medaliat",
                "medalist", "meditat", "menționat", "merit", "meritat", "meticulos", "militant", "militarist", "mincinos", "minerit",
                "minunat", "mințit", "miraculos", "mistreț", "mituit", "mișcat", "miștocar", "mobilat", "modelat", "moderat",
                "modificat", "molipsit", "molipsitor", "monarhist", "montat", "moș", "moștenit", "moștenitor", "moț", "muist",
                "mult", "muncit", "muntos", "murat", "murdărit", "mut", "mușcat", "mâncat", "mâncător", "mânuit",
                "mârșav", "măcelar", "măcelărit", "măcinat", "măcinător", "măritat", "măsurat", "nazist", "național", "naționalist",
                "naționalizat", "neatins", "necredincios", "nemișcat", "nepot", "nervos", "neserios", "nesimțit", "nevătămat", "nihilist",
                "norocos", "numărat", "obosit", "observat", "odihnit", "onest", "operat", "oprit", "optimist", "optimizat",
                "ostaș", "otrăvit", "otrăvitor", "oxidat", "oțelit", "parcat", "parcelat", "parcurs", "parțial", "pedepsit",
                "penetrat", "perfect", "periclitat", "periculos", "permis", "perseverent", "pertinent", "pescar", "pesimist", "pianist",
                "pierdut", "pirotehnist", "pivotat", "pizdos", "pișat", "plantat", "plângător", "plâns", "plătit", "pocăit",
                "poposit", "poruncit", "potolit", "potrivit", "povestit", "preafericit", "prefabricat", "prefect", "prefăcut", "pregătit",
                "pregătitor", "prelat", "preluat", "premiat", "pretins", "prevenit", "prevăzut", "prevăzător", "prezent", "prezentat",
                "prețuit", "prețuitor", "pricopsit", "prietenos", "primit", "prinși", "profet", "progresist", "prost", "protejat",
                "protestant", "prudent", "prăjit", "prăjitor", "puiet", "purist", "purtat", "pus", "pușcat", "păcălit",
                "păcătuit", "pădurar", "păduros", "păgân", "pălmuit", "părerolog", "părut", "păstrat", "pătruns", "racolat",
                "racordat", "radicalist", "rahat", "raportat", "readus", "realist", "realizat", "realizator", "recalculat", "recalibrat",
                "reclamat", "recoltat", "recoltator", "recomandat", "redat", "redus", "regalist", "religios", "remarcat", "remediat",
                "remodelat", "remorcat", "remușcat", "renovat", "renumit", "reparat", "repartizat", "repatriat", "reperat", "repetat",
                "reprezentant", "reprezentat", "reprimat", "reproșat", "resetat", "respectat", "respectuos", "respondent", "retras", "reușit",
                "revenit", "revoltat", "revoluționar", "revoluționist", "rezident", "rezistent", "rezolvat", "rezonat", "rezultat", "ridicat",
                "risipit", "risipitor", "ritm", "robotizat", "rugat", "rupt", "rus", "răbdător", "rămas", "rănit",
                "răpit", "răposat", "răpus", "răscolit", "răsculat", "răspunzător", "răspândit", "răstignit", "răsturnat", "răsărit",
                "răsăritor", "rătăcit", "rătăcitor", "răufăcător", "răuvoitor", "răzvrătit", "sacadat", "sacrificat", "salvat", "salvator",
                "savant", "schimbat", "schimbător", "scobit", "scos", "sculat", "scurtat", "secătuit", "semănat", "serios",
                "setat", "sfințit", "simțit", "sindicalist", "sindicalizat", "sinucis", "slăbit", "slăbănog", "slăvit", "smintit",
                "socialist", "somnoros", "sonorizat", "soroșist", "soț", "spart", "spectaculos", "sperat", "speriat", "spumant",
                "spumat", "spânzurat", "spălat", "spălător", "spărgător", "stabilizant", "stabilizat", "stabilizator", "stagnat", "stareț",
                "stins", "strigat", "strâmb", "strâns", "străin", "strămutat", "străpuns", "student", "stăpân", "subțiat",
                "sufocat", "sunat", "supărat", "surprins", "suspect", "suspicios", "susținut", "susținător", "sâcâit", "sălbatic",
                "sălbăticit", "sămânțar", "sănătos", "săpat", "săptămânal", "sărat", "săritor", "tanchist", "teafăr", "temător",
                "tentat", "terasat", "terminat", "ticălos", "tolerant", "tors", "tovarăș", "traficant", "transformat", "transparent",
                "tras", "trasat", "trecător", "trezit", "trimis", "trotinetist", "trântit", "trădător", "trăit", "trăznit",
                "tuns", "turist", "tâlhar", "tâmpit", "tâmplar", "târât", "târâtor", "tăcut", "uimit", "uitat",
                "umplut", "unificat", "unionizat", "unit", "urcat", "urmaș", "urzicat", "urzit", "uscat", "utilat",
                "utopist", "ușurat", "validat", "vasalizat", "venerat", "veninos", "venit", "versionat", "vestit", "veșnic",
                "vicios", "vindecat", "vindecător", "visat", "visător", "vizat", "vizitat", "voios", "vomitat", "vorbăreț",
                "votant", "vrednic", "vrut", "vrăjit", "vrăjitor", "vândut", "vânzător", "vânător", "vârstnic", "vărsat",
                "vărsător", "văzut", "zburător", "zelos", "ziarist", "zidit", "zilnic", "zugrăvit", "îmbinat", "îmbolnăvit",
                "îmbrăcat", "îmbunătățit", "îmbăiat", "îmbătrânit", "împins", "împodobit", "împotmolit", "împrumutat", "împrăștiat", "împuns",
                "împuternicit", "împușcat", "împuțit", "împărat", "împărtășit", "împărțit", "înaintat", "înbunat", "înbunătățit", "încarcerat",
                "început", "încercat", "încercuit", "încet", "încetinit", "încețoșat", "închinat", "închis", "încolțit", "încrezut",
                "încrezător", "încurcat", "încântat", "încântător", "încălecat", "încălzit", "încălzitor", "încălțat", "încărcat", "încărcător",
                "încătușat", "îndatorat", "îndepărtat", "îndoit", "îndrumat", "îndrăgostit", "îndulcit", "înflorit", "înfricoșat", "înfricoșător",
                "înfundat", "înfuriat", "înghețat", "îngrijorat", "îngropat", "îngrozit", "îngrășat", "îngânfat", "înjurat", "înjurător",
                "înlăturat", "înmormântat", "înmulțit", "înpădurit", "înpământat", "înrobit", "însemnat", "însorit", "înspăimântat", "înspăimântător",
                "înstrăinat", "însurat", "întemeiat", "întemeietor", "întemnițat", "întins", "întors", "întrebat", "întrepătruns", "întreținut",
                "întunecat", "întârziat", "înviat", "învins", "învățat", "învățător", "înzăpezit", "înălțat", "înțelept", "șahist",
                "școlit", "șerpuit", "șlefuit", "șofer", "șpăgar", "ștergător", "șters", "țap", "țarist", "țigan",
                "țintit", "ținut", "țipat", "țânțar", "țăran", "țărănist", "actual", "adaptat", "admin", "administrator",
                "adoptat", "aliat", "antrenor", "apucat", "asemănat", "asemănător", "candidat", "centrat", "clonat", "colindat",
                "dezbinat", "doctor", "fermier", "forțat", "frământat", "inadaptat", "infiltrat", "instalat", "înregistrat", "jertfit",
                "lenevit", "linșat", "lipitor", "lipsit", "lucrat", "medic", "miner", "muncitor", "numerotat", "numit",
                "parlamentar", "patinat", "plecat", "plictisit", "plictisitor", "pomenit", "pompat", "pompier", "premier", "profesionist",
                "profesor", "profilat", "programat", "programator", "punctual", "răzbunat", "reactor", "reapucat", "reinstalat", "reîntors",
                "reprator", "revanșat", "similar", "simplificat", "singular", "specializat", "sportiv", "stricat",
                "cercetat", "scriitor", "politolog", "protestatar", "umbros", "noros", "ploios", "umbrit", "plouat", "cântărit",
                "verificat", "ban", "bancher", "baron", "codat", "coordonat", "decolat", "dobândit", "dominat", "dominator",
                "domn", "domnitor", "dovedit", "gândac", "imun", "imunizat", "înstărit", "jupân", "martor", "ordinar",
                "ordonat", "oripilat", "oropsit", "ostenit", "ostentativ", "parvenit", "pervers", "pozat", "ucenic", "vaccinat",
                "vătaf", "vitreg", "voievod", "vulcan", "vulnerabil", "acționat",
                "calculator", "căscat", "cântat", "cântărit", "cercetat", "diavol", "drac", "încleștat", "înger", "noros",
                "paznic", "păzitor", "ploios", "plouat", "politolog", "protestatar", "scriitor", "umbrit", "umbros", "verificat",
                "asasin", "asin", "asistent", "asociat", "asortat", "asumat", "asuprit", "atent", "atipic", "atlet",
                "atletic", "atmosferic", "atomizat", "atrăgător", "auzit", "avansat", "avantajos", "cârnăcior", "cârnaț", "cartof",
                "concediat", "disponibil", "disponibilizat", "divers", "diversificat", "diversificator", "identic", "identificat", "înclinat", "istovit",
                "marginalizat", "mic", "morcov", "neavut", "necesar", "necesitat", "nepermis", "neprimit", "nevoiaș", "nevoit",
                "nevrut", "postat", "prichindel", "reglementat", "repostat", "revigorant", "revigorat", "ridicol", "ridiculizat", "ridiculos",
                "sabotat", "sabotor", "scârbit", "scârbos", "slujit", "slujitor", "spumos", "sufletist", "tipărit", "tipizat",
                "titan", "titanic", "transferat", "treptat", "universal", "universalist", "variat", "viguros", "voit",
                "alegător", "amiral", "bântuit", "bebeluș", "bifurcat", "catolic", "colos", "dictator", "electrolit", "fascicul",
                "general", "gigant", "lup", "mânz", "pitic", "piton", "popular", "populist", "rozător", "rudimentar",
                "rulment", "social-democrat", "strateg", "uriaș", "vultur", "zgâriat", "zgomotos", "zugrav", "zvăpăiat",
                "zvonit",
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

            // Keep the common fixed expression unchanged.
            result = Regex.Replace(result, @"\bdracul să ți-o ia\b", "dracu să ți-o ia", RegexOptions.CultureInvariant);

            return result;
        }
    }
}