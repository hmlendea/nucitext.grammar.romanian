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
    [TestCase("ana are mere", "ana are mere")]
    [TestCase("tzara asta este mare", "țara asta este mare")]
    [TestCase("tzeava sparge geamu", "țeava sparge geamul")]
    public void GivenText_WhenCorrecting_ThenTheExpectedTextIsReturned(
        string inputText,
        string expectedText)
    {
        IGrammarCorrector corrector = new RomanianGrammarCorrector();

        string result = corrector.Correct(inputText);

        Assert.That(result, Is.EqualTo(expectedText));
    }
}