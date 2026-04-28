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
    [TestCase("ana are mere", "ana are mere")]
    [TestCase("are cnv sami dea niste pamant??", "are cineva să-mi dea niște pământ??")]
    [TestCase("ca imi fac si eu un trnacop de cupru", "că îmi fac și eu un trnacop de cupru")]
    [TestCase("daca vrei poti sa vi la mn", "dacă vrei poți să vii la mine")]
    [TestCase("dracu sa tio ia", "dracu să ți-o ia")]
    [TestCase("dute si mineaza linistit", "du-te și minează liniștit")]
    [TestCase("nu functioneaza, am să fac o piata functionala unde poti vbinde chestii", "nu funcționează, am să fac o piață funcțională unde poți vinde chestii")]
    [TestCase("nush ca esti in orasu meu", "nu știu ca ești în orașul meu")]
    [TestCase("o/  1/2 si xd", "o/ ½ și xD")]
    [TestCase("pot sa imi fac supsol?", "pot să îmi fac subsol?")]
    [TestCase("te vad acm", "te văd acum")]
    [TestCase("tzara asta este mare", "țara asta este mare")]
    [TestCase("tzeava sparge geamu", "țeava sparge geamul")]
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