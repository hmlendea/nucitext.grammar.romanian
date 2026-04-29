using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests;

[TestFixture]
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
    [TestCase("ah frate", "ah, frate")]
    [TestCase("am fo la concert la AC/DC si mio placut ft mult", "am fost la concert la AC/DC și mi-a plăcut foarte mult")]
    [TestCase("ana are mere", "ana are mere")]
    [TestCase("are cnv sami dea niste pamant??", "are cineva să-mi dea niște pământ??")]
    [TestCase("azi am fo in visita in Washington DC", "azi am fost în vizită în Washington DC")]
    [TestCase("batman e dc comics si spiderman e marvel", "Batman e DC Comics și Spiderman e Marvel")]
    [TestCase("ca imi fac si eu un trnacop de cupru", "că îmi fac și eu un trnacop de cupru")]
    [TestCase("ce faceti colo", "ce faceți acolo")]
    [TestCase("daca vrei poti sa vi la mn", "dacă vrei poți să vii la mine")]
    [TestCase("dracu sa tio ia", "dracu să ți-o ia")]
    [TestCase("dute si mineaza linistit", "du-te și minează liniștit")]
    [TestCase("nu functioneaza, am să fac o piata functionala unde poti vbinde chestii", "nu funcționează, am să fac o piață funcțională unde poți vinde chestii")]
    [TestCase("nu lam vazut", "nu l-am văzut")]
    [TestCase("nu sti asta? io da", "nu știi asta? Io da")]
    [TestCase("nu vad nmc de ceatza asta", "nu văd nimic de ceața asta")]
    [TestCase("nuj dc da ma doare capu ft tare", "nu știu de ce, dar mă doare capul foarte tare")]
    [TestCase("nush ca esti in orasu meu", "nu știu că ești în orașul meu")]
    [TestCase("o/  1/2 si xd", "o/ ½ și xD")]
    [TestCase("pot sa imi fac supsol?", "pot să îmi fac subsol?")]
    [TestCase("sal si bine vam gasit", "salut și bine v-am găsit")]
    [TestCase("stim din start ca no sa facem", "știm din start că nu o să facem")]
    [TestCase("te vad acm", "te văd acum")]
    [TestCase("tzara asta este mare", "țara asta este mare")]
    [TestCase("tzeava sparge geamu", "țeava sparge geamul")]
    [TestCase("vine valu siti ia calu", "vine valul și îți ia calul")]
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