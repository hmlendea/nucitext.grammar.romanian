using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RomanianFormattingRuleTests
    {
        [Test]
        public void CommaRule_NormalisesShortInterjections()
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianCommaRule");

            string result = rule.Apply("a stai");

            Assert.That(result, Is.EqualTo("a, stai"));
        }

        [Test]
        public void SpacingRule_NormalisesSpacingAroundPunctuation()
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianSpacingRule");

            string result = rule.Apply("salut,lume");

            Assert.That(result, Is.EqualTo("salut, lume"));
        }

        [Test]
        public void EmojiRule_NormalisesEmojiCasing()
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianEmojiRule");

            string result = rule.Apply("xd");

            Assert.That(result, Is.EqualTo("xD"));
        }

        [Test]
        public void FractionRule_ReplacesAsciiFractions()
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.FractionGlyphRule");

            string result = rule.Apply("1/2");

            Assert.That(result, Is.EqualTo("½"));
        }

        [Test]
        public void RepeatedCharacterRule_CompressesLongRuns()
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RepeatedCharacterCompressionRule");

            string result = rule.Apply("noooooroc");

            Assert.That(result, Is.EqualTo("noooroc"));
        }

        static IGrammarRule CreateRule(string typeName)
        {
            Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
            return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
        }
    }
}