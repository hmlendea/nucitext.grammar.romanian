using System;
using System.Collections.Generic;
using NuciText.Grammar.Romanian.UnitTests.Helpers.Lists;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class UlInsteadOfURuleTests
    {
        private static IEnumerable<TestCaseData> MasculineNounVariationTestCases()
        {
            foreach (var noun in MasculineNouns.Values)
            {
                yield return new TestCaseData($"{noun}u", $"{noun}ul")
                    .SetName($"{noun}u' -> '{noun}ul'");
            }
        }

        [Test, TestCaseSource(nameof(MasculineNounVariationTestCases))]
        public void GivenMasculineNounEndingWithU_WhenApplyingTheRule_ThenLIsAddedAtTheEnd(
            string text,
            string expected)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.UlInsteadOfURule");

            string result = rule.Apply(text);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("aeru", "aerul")]
        [TestCase("altu", "altul")]
        [TestCase("becu", "becul")]
        [TestCase("calu", "calul")]
        [TestCase("codu", "codul")]
        [TestCase("filmu", "filmul")]
        [TestCase("gandu", "gandul")]
        [TestCase("lacu", "lacul")]
        [TestCase("lemnu", "lemnul")]
        [TestCase("locu", "locul")]
        [TestCase("malu", "malul")]
        [TestCase("netu", "netul")]
        [TestCase("nivelu", "nivelul")]
        [TestCase("omul", "omul")]
        [TestCase("palatu", "palatul")]
        [TestCase("planu", "planul")]
        [TestCase("podu", "podul")]
        [TestCase("porcu", "porcul")]
        [TestCase("puiu", "puiul")]
        [TestCase("satu", "satul")]
        [TestCase("seifu", "seiful")]
        [TestCase("sfatu", "sfatul")]
        [TestCase("sobolanu", "sobolanul")]
        [TestCase("stocul", "stocul")]
        [TestCase("ursu", "ursul")]
        [TestCase("valu", "valul")]
        [TestCase("vantu", "vantul")]
        [TestCase("varfu", "varful")]
        [TestCase("votu", "votul")]
        [TestCase("zidu", "zidul")]
        public void GivenWordEndingWithU_WhenApplyingTheRule_ThenLIsAddedAtTheEnd(string text, string expected)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.UlInsteadOfURule");

            string result = rule.Apply(text);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Aerul", "Aerul")]
        [TestCase("Calul", "Calul")]
        [TestCase("codul", "codul")]
        [TestCase("CODUL", "CODUL")]
        [TestCase("CoDuL", "CoDuL")]
        public void GivenWordAlreadyEndingWithUl_WhenApplyingTheRule_ThenItIsNotChanged(string text, string expected)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.UlInsteadOfURule");

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
