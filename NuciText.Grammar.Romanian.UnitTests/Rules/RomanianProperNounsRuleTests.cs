using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules;

[TestFixture]
public class RomanianProperNounsRuleTests
{
    [TestCase("george", "George")]
    [TestCase("hori", "Hori")]
    [TestCase("ioan", "Ioan")]
    [TestCase("ioana", "Ioana")]
    public void Apply_NormalisesProperNouns(string text, string expected)
    {
        IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianProperNounsRule");

        string result = rule.Apply(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    static IGrammarRule CreateRule(string typeName)
    {
        Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
        return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
    }
}