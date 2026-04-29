using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RomanianGrammarCorrectorTests
    {
        [Test]
        public void GivenNullText_WhenCorrecting_ThenArgumentNullExceptionIsThrown()
        {
            IGrammarCorrector corrector = new RomanianGrammarCorrector();

            Assert.Throws<ArgumentNullException>(() => corrector.Correct(null!));
        }

        [Test]
        [TestCase("  salut lume  ", "salut lume")]
        [TestCase("  salut     lume  ", "salut lume")]
        public void GivenTextWithExccessiveWhitespaces_WhenCorrecting_ThenWhitespaceIsTrimmed(
            string inputText,
            string expectedText)
        {
            IGrammarCorrector corrector = new RomanianGrammarCorrector();

            string result = corrector.Correct(inputText);

            Assert.That(result, Is.EqualTo(expectedText));
        }

        [Test]
        [TestCase("a stai ca am", "a, stai că am")]
        [TestCase("acolo e resedinta", "acolo e reședința")]
        [TestCase("ah frate", "ah, frate")]
        [TestCase("altu nu mai vezi", "altul nu mai vezi")]
        [TestCase("am afut ft multa rabdare si miam consumat bunavointa cu tine", "am avut foarte multă răbdare și mi-am consumat bunăvoința cu tine")]
        [TestCase("am fo la buna so mai vad", "am fost la buna s-o mai văd")]
        [TestCase("am fo la concert la AC/DC si mio placut ft mult", "am fost la concert la AC/DC și mi-o plăcut foarte mult")]
        [TestCase("am iesit la minat", "am ieșit la minat")]
        [TestCase("am o gramada de piatra dasta", "am o grămadă de piatră d-asta")]
        [TestCase("am taiat toata padurea", "am tăiat toată pădurea")]
        [TestCase("am terminat casuta", "am terminat căsuța")]
        [TestCase("am tipat deam spart fereastra", "am țipat de-am spart fereastra")]
        [TestCase("am vazut multe trote pe strada mea", "am văzut multe trotinete pe strada mea")]
        [TestCase("amu csz, nai csf", "acum ce să zic, n-ai ce să faci")]
        [TestCase("ana are mere", "ana are mere")]
        [TestCase("arata bn", "arată bine")]
        [TestCase("arata mai bn ca nainte", "arată mai bine ca înainte")]
        [TestCase("are cnv sami dea niste pamant??", "are cineva să-mi dea niște pământ??")]
        [TestCase("asai, si aia ii buna", "așa-i, și aia îi bună")]
        [TestCase("asi vrea si io o parcela", "aș vrea și eu o parcelă")]
        [TestCase("avem formatu gresit", "avem formatul greșit")]
        [TestCase("aveti dreptate", "aveți dreptate")]
        [TestCase("azi am fo in visita in Washington DC", "azi am fost în vizită în Washington DC")]
        [TestCase("baga inca o fisa", "bagă încă o fisă")]
        [TestCase("baga mare ca iti dau eu", "bagă mare că îți dau eu")]
        [TestCase("bate vantu", "bate vântul")]
        [TestCase("batman e dc comics si spiderman e marvel", "Batman e DC Comics și Spiderman e Marvel")]
        [TestCase("bine ca esti tu destept", "bine că ești tu deștept")]
        [TestCase("bogatii si saracii", "bogații și săracii")]
        [TestCase("bunavointa sa nare limite", "bunăvoința sa nu are limite")]
        [TestCase("ca imi fac si eu un trnacop de cupru", "că îmi fac și eu un târnăcop de cupru")]
        [TestCase("ca sa fi bogat", "ca să fii bogat")]
        [TestCase("capra sare piatra, piatra crapa in patru", "capra sare piatra, piatra crapă în patru")]
        [TestCase("care era intrebarea", "care era întrebarea")]
        [TestCase("ce faceti colo", "ce faceți acolo")]
        [TestCase("ce planuri mai ai pe joc", "ce planuri mai ai pe joc")]
        [TestCase("cemi dai, ca io le vreau pe toate", "ce-mi dai, că eu le vreau pe toate")]
        [TestCase("conacu ala", "conacul ăla")]
        [TestCase("conducatorii nostri sunt corupti", "conducătorii noștri sunt corupți")]
        [TestCase("contu de admin pe care il tot astept", "contul de admin pe care îl tot aștept")]
        [TestCase("copiaza pana-i sar capacele", "copiază până-i sar capacele")]
        [TestCase("cum e viata in romania", "cum e viața în România")]
        [TestCase("cum faceam sa corectez mesaju", "cum făceam să corectez mesajul")]
        [TestCase("daca sar face ceva", "dacă s-ar face ceva")]
        [TestCase("daca vrei poti sa vi la mn", "dacă vrei poți să vii la mine")]
        [TestCase("dc ma tot corecteaza", "de ce mă tot corectează")]
        [TestCase("dracu sa tio ia", "dracu să ți-o ia")]
        [TestCase("dute si mineaza linistit", "du-te și minează liniștit")]
        [TestCase("e asa urata cabana", "e așa urâtă cabana")]
        [TestCase("fati de cap", "fă-ți de cap")]
        [TestCase("fereasca sfantu", "ferească sfântul")]
        [TestCase("fimiar scarba de tot ce sentampla", "fi-mi-ar scârbă de tot ce se întâmplă")]
        [TestCase("furnicutele se strang sub fereastra", "furnicuțele se strâng sub fereastră")]
        [TestCase("gradina din spatele casutei", "grădina din spatele căsuței")]
        [TestCase("habar nam, nmn nu stie", "habar n-am, nimeni nu știe")]
        [TestCase("i-mi dai un mar", "îmi dai un măr")]
        [TestCase("ii lasi direct acolo", "îi lași direct acolo")]
        [TestCase("il voi lasa asa", "îl voi lăsa așa")]
        [TestCase("imi aduc bine aminte cand testam ca mergea mai bine decat acum", "îmi aduc bine aminte când testam că mergea mai bine decât acum")]
        [TestCase("imi vine sa borasc", "îmi vine să borăsc")]
        [TestCase("inainte arata mai bn", "înainte arăta mai bine")]
        [TestCase("inot pana la malu celalalt", "înot până la malul celălalt")]
        [TestCase("inseamna ca da", "înseamnă că da")]
        [TestCase("intra linistit si uita-te", "intră liniștit și uită-te")]
        [TestCase("intrun palat", "într-un palat")]
        [TestCase("isi strangea si aduna chestiile", "își strângea și aduna chestiile")]
        [TestCase("iti dau pamant", "îți dau pământ")]
        [TestCase("jos labile", "jos labele")]
        [TestCase("lacu o secatuit", "lacul o secătuit")]
        [TestCase("lucrez in gradina", "lucrez în grădină")]
        [TestCase("ma omoara raceala asta, is o racitura si jumate", "mă omoară răceala asta, îs o răcitură și jumătate")]
        [TestCase("ma tot bate la cap intruna", "mă tot bate la cap întruna")]
        [TestCase("macar sa avem ce manca", "măcar să avem ce mânca")]
        [TestCase("mai dai si tu cu buna ziua", "mai dai și tu cu bună ziua")]
        [TestCase("mam impotmolit pe drumu dintre sate", "m-am împotmolit pe drumul dintre sate")]
        [TestCase("merem singuri", "mergem singuri")]
        [TestCase("mi so stricat căruța", "mi s-a stricat căruța")]
        [TestCase("miai dat deja parcela din stanga mea", "mi-ai dat deja parcela din stânga mea")]
        [TestCase("miam rupt ghiozdanu", "mi-am rupt ghiozdanul")]
        [TestCase("miam scos trota", "mi-am scos trotineta")]
        [TestCase("miam uitat parola si vriau so schimb", "mi-am uitat parola și vreau s-o schimb")]
        [TestCase("mo batut fraieru", "m-a bătut fraierul")]
        [TestCase("najung lemnele mai taie cateva", "nu ajung lemnele, mai taie câteva")]
        [TestCase("nar fi greu deloc", "nu ar fi greu deloc")]
        [TestCase("navem", "n-avem")]
        [TestCase("ne aliniem cu totii", "ne aliniem cu toții")]
        [TestCase("nici democratia nu mai e ce era odata", "nici democrația nu mai e ce era odată")]
        [TestCase("nivelez niste munti ca sa las numa muntele din spate intreg", "nivelez niște munți ca să las numai muntele din spate întreg")]
        [TestCase("nu fi sarpe", "nu fi șarpe")]
        [TestCase("nu functioneaza, am să fac o cladire functionala unde poti vbinde chestii", "nu funcționează, am să fac o clădire funcțională unde poți vinde chestii")]
        [TestCase("nu lam vazut", "nu l-am văzut")]
        [TestCase("nu mai mina atata", "nu mai mina atâta")]
        [TestCase("nu mio aparut mesaju", "nu mi-o apărut mesajul")]
        [TestCase("nu sti asta? io da", "nu știi asta? eu da")]
        [TestCase("nu vad nmc de ceatza asta", "nu văd nimic de ceața asta")]
        [TestCase("nuj dc da ma doare capu ft tare", "nu știu de ce, dar mă doare capul foarte tare")]
        [TestCase("numa bogatii gandesc asa ca tn", "numai bogații gândesc așa ca tine")]
        [TestCase("nush ca esti in orasu meu", "nu știu că ești în orașul meu")]
        [TestCase("o cladire pentru mina, o primarie, trei temnite", "o clădire pentru mină, o primărie, trei temnițe")]
        [TestCase("o sa vina si vremea aia cand o sati stea in gat", "o să vină și vremea aia când o să-ți stea în gât")]
        [TestCase("o/  1/2 si xd", "o/ ½ și xD")]
        [TestCase("pacat ca nai mai venit", "păcat că n-ai mai venit")]
        [TestCase("pacatosule dute de aci", "păcătosule du-te de aici")]
        [TestCase("placerea e de partea mea", "plăcerea e de partea mea")]
        [TestCase("poate se actualizeaza mai des ca acu e cam rar", "poate se actualizează mai des că acum e cam rar")]
        [TestCase("pot sa imi fac supsol?", "pot să îmi fac subsol?")]
        [TestCase("poti sami dai ca o trmin", "poți să-mi dai că o termin")]
        [TestCase("prima parte cu bosii o fo mai buna", "prima parte cu boșii o fost mai bună")]
        [TestCase("ruleaza acum testele", "rulează acum testele")]
        [TestCase("sa aprinda becu", "să aprindă becul")]
        [TestCase("sa nentoarcem in trecut, ca nainte era mai bn", "să ne-ntoarcem în trecut, că înainte era mai bine")]
        [TestCase("sa te speli de pacate", "să te speli de păcate")]
        [TestCase("sal si bine vam gasit", "salut și bine v-am găsit")]
        [TestCase("salutarile mele", "salutările mele")]
        [TestCase("schimbarile se tot strang, numa zic", "schimbările se tot strang, numai zic")]
        [TestCase("sigur o sati mai trebuiasca", "sigur o să-ți mai trebuiască")]
        [TestCase("sio gatat tura", "și-a terminat tura")]
        [TestCase("stai linistit ca daca stia nu mai intra acolo", "stai liniștit că dacă știa nu mai intra acolo")]
        [TestCase("stai sa gasesc siti dau", "stai să găsesc și-ți dau")]
        [TestCase("stim din start ca no sa facem", "știm din start că nu o să facem")]
        [TestCase("strada nui destul de mare pentru trota mea", "strada nu-i destul de mare pentru trotineta mea")]
        [TestCase("te vad acm", "te văd acum")]
        [TestCase("tiam adus cirese", "ți-am adus cireșe")]
        [TestCase("tiar prinde bine", "ți-ar prinde bine")]
        [TestCase("tipu e asa oldschool", "tipul e așa oldschool")]
        [TestCase("toporu lu hori", "toporul lui Hori")]
        [TestCase("totu pt natiune", "totul pentru națiune")]
        [TestCase("tre sa mai cresti prima data", "trebuie să mai crești prima dată")]
        [TestCase("tzara asta este mare", "țara asta este mare")]
        [TestCase("tzeava sparge geamu", "țeava sparge geamul")]
        [TestCase("urmaresc cu mare interes", "urmăresc cu mare interes")]
        [TestCase("vine ca sa plece", "vine ca să plece")]
        [TestCase("vrem si noi sa fim bogati", "vrem și noi să fim bogați")]
        [TestCase("vai dar ai un catel asa de dragut", "vai dar ai un cățel așa de drăguț")]
        [TestCase("veniti sa luati lumina", "veniți să luați lumina")]
        [TestCase("vezi sa nu te impiedici", "vezi să nu te împiedici")]
        [TestCase("viata unui caine", "viața unui câine")]
        [TestCase("vina e a lui", "vina e a lui")]
        [TestCase("vine de la oras", "vine de la oraș")]
        [TestCase("vine sfarsitu lumii si ne ia pe toti", "vine sfârșitul lumii și ne ia pe toți")]
        [TestCase("vine valu siti ia calu", "vine valul și-ți ia calul")]
        [TestCase("vroiai sami zici ceva", "voiai să-mi zici ceva")]
        [TestCase("vroiam sati spun cv", "voiam să-ți spun ceva")]
        [TestCase("vsm de capu tau", "vai și amar de capul tău")]
        [TestCase("yeah dar as prefera sa faceti voi rost singuri de materiale", "yeah dar aș prefera să faceți voi rost singuri de materiale")]
        public void GivenText_WhenCorrecting_ThenTheExpectedTextIsReturned(
            string inputText,
            string expectedText)
        {
            IGrammarCorrector corrector = new RomanianGrammarCorrector();

            string result = corrector.Correct(inputText);

            Assert.That(result, Is.EqualTo(expectedText));
        }
    }
}