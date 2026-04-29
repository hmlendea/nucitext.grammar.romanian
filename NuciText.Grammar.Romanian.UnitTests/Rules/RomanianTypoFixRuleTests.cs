using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RomanianTypoFixRuleTests
    {
        [TestCase("aci", "aici")]
        [TestCase("acm", "acum")]
        [TestCase("acu", "acum")]
        [TestCase("aier", "aer")]
        [TestCase("altcv", "altceva")]
        [TestCase("amu", "acum")]
        [TestCase("anapoi", "înapoi")]
        [TestCase("ălea", "alea")]
        [TestCase("cva", "ceva")]
        [TestCase("d aia", "d-aia")]
        [TestCase("daia", "d-aia")]
        [TestCase("dala", "d-ăla")]
        [TestCase("dalea", "d-alea")]
        [TestCase("deam", "de-am")]
        [TestCase("deati", "de-ați")]
        [TestCase("dute", "du-te")]
        [TestCase("lam", "l-am")]
        [TestCase("lar", "l-ar")]
        [TestCase("lasal", "lasă-l")]
        [TestCase("miai", "mi-ai")]
        [TestCase("miam", "mi-am")]
        [TestCase("miar", "mi-ar")]
        [TestCase("mio", "mi-o")]
        [TestCase("n am", "n-am")]
        [TestCase("nam", "n-am")]
        [TestCase("nar", "n-ar")]
        [TestCase("nare", "n-are")]
        [TestCase("navea", "n-avea")]
        [TestCase("navem", "n-avem")]
        [TestCase("naveti", "n-aveți")]
        [TestCase("nentoarcem", "ne-ntoarcem")]
        [TestCase("nui", "nu-i")]
        [TestCase("numa", "numai")]
        [TestCase("nus", "nu-s")]
        [TestCase("nusi", "nu-și")]
        [TestCase("nuti", "nu-ți")]
        [TestCase("pten", "prieten")]
        [TestCase("sami", "să-mi")]
        [TestCase("santem", "suntem")]
        [TestCase("sasi", "să-și")]
        [TestCase("sati", "să-ți")]
        [TestCase("siau", "și-au")]
        [TestCase("sior", "și-or")]
        [TestCase("supsol", "subsol")]
        [TestCase("tio", "ți-o")]
        [TestCase("trmin", "termin")]
        [TestCase("vam", "v-am")]
        [TestCase("vati", "v-ați")]
        [TestCase("vbinde", "vinde")]
        [TestCase("vi la", "vii la")]
        [TestCase("vroiai", "voiai")]
        [TestCase("vroiam", "voiam")]
        [TestCase("vroiati", "voiati")]
        [TestCase("vroiați", "voiați")]
        [TestCase("vroiau", "voiau")]
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
}