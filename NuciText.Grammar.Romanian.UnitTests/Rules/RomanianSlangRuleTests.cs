using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules;

[TestFixture]
public class RomanianSlangRuleTests
{
    [TestCase("nush", "nu știu")]
    [TestCase("pt", "pentru")]
    [TestCase("kk", "bine")]
    public void Apply_ReplacesCommonSlang(string text, string expected)
    {
        IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianSlangRule");

        string result = rule.Apply(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    static IGrammarRule CreateRule(string typeName)
    {
        Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
        return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
    }
}