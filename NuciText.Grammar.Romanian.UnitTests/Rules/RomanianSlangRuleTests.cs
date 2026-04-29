using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RomanianSlangRuleTests
    {
        [TestCase("kk", "bine")]
        [TestCase("lfl", "la fel")]
        [TestCase("mcac", "mă cac")]
        [TestCase("nush", "nu știu")]
        [TestCase("pt", "pentru")]
        [TestCase("vsm", "vai și amar")]
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
}