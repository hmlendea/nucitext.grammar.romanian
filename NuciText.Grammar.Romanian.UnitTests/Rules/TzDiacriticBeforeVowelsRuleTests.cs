using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules;

[TestFixture]
public class TzDiacriticBeforeVowelsRuleTests
{
    [Test]
    public void Id_ReturnsExpectedValue()
    {
        IGrammarRule rule = CreateRule();

        Assert.That(rule.Id, Is.EqualTo("tz-diacritic-before-vowels"));
    }

    [Test]
    public void Apply_NullText_ThrowsArgumentNullException()
    {
        IGrammarRule rule = CreateRule();

        Assert.Throws<ArgumentNullException>(() => rule.Apply(null!));
    }

    [Test]
    public void CanApply_NullText_ThrowsArgumentNullException()
    {
        IGrammarRule rule = CreateRule();

        Assert.Throws<ArgumentNullException>(() => rule.CanApply(null!));
    }

    [TestCase("tzara", true)]
    [TestCase("Tzara", true)]
    [TestCase("TZARA", true)]
    [TestCase("tzmeu", false)]
    [TestCase("țară", false)]
    public void CanApply_ReturnsExpectedValue(string text, bool expected)
    {
        IGrammarRule rule = CreateRule();

        bool result = rule.CanApply(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase("tzara", "țara")]
    [TestCase("Tzara", "Țara")]
    [TestCase("TZARA", "ȚARA")]
    public void Apply_TextContainsSupportedPattern_ReplacesItWithDiacritic(string text, string expected)
    {
        IGrammarRule rule = CreateRule();
        string result = rule.Apply(text);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Apply_TextWithoutSupportedPatterns_ReturnsSameText()
    {
        IGrammarRule rule = CreateRule();

        string result = rule.Apply("țară tzm tzy salut");

        Assert.That(result, Is.EqualTo("țară tzm tzy salut"));
    }

    static IGrammarRule CreateRule()
    {
        Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(
            "NuciText.Grammar.Romanian.Rules.TzDiacriticBeforeVowelsRule",
            throwOnError: true)!;

        return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
    }
}