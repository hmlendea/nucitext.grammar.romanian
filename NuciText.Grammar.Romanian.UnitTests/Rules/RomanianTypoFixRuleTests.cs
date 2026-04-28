using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules;

[TestFixture]
public class RomanianTypoFixRuleTests
{
    [TestCase("acm", "acum")]
    [TestCase("cva", "ceva")]
    [TestCase("supsol", "subsol")]
    [TestCase("tio", "ți-o")]
    [TestCase("vbinde", "vinde")]
    [TestCase("pten", "prieten")]
    [TestCase("d aia", "de aia")]
    [TestCase("vi la", "vii la")]
    public void Apply_FixesExpectedTypos(string text, string expected)
    {
        IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianTypoFixRule");

        string result = rule.Apply(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    static IGrammarRule CreateRule(string typeName)
    {
        Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
        return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
    }
}