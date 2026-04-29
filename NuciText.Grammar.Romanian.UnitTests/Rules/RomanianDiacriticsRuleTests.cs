using System;
using System.Collections.Generic;
using System.Linq;
using NuciExtensions;
using NuciText.Grammar.Romanian.UnitTests.Helpers.Lists;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class RomanianDiacriticsRuleTests
    {
        private static IEnumerable<TestCaseData> FeminineNounEndingWithIeVariationTestCases()
        {
            string[] suffixes = ["a", "e", "ei", "i", "ile", "ilor"];

            foreach (var expectedNoun in FeminineNounsEndingWithIe.Values)
            {
                string baseExpectedNoun = expectedNoun[..^1];
                List<string> inputNouns = GenerateInputNouns(expectedNoun);

                foreach (var inputNoun in inputNouns)
                {
                    string baseInputNoun = inputNoun[..^1];

                    foreach (string suffix in suffixes)
                    {
                        string expectedWithSuffix = ComputeExpectedWithSuffix(
                            baseExpectedNoun,
                            baseInputNoun,
                            suffix);

                        yield return
                            new TestCaseData(baseInputNoun, suffix, expectedWithSuffix)
                                .SetName($"{expectedNoun} + '{inputNoun}' + '{suffix}'");
                    }
                }
            }
        }

        private static IEnumerable<TestCaseData> MasculineNounVariationTestCases()
        {
            var suffixes = new[] { "", "i", "ii", "ilor", "ul", "ule", "ului" };

            foreach (var expectedNoun in MasculineNouns.Values)
            {
                var inputNouns = GenerateInputNouns(expectedNoun);

                foreach (var inputNoun in inputNouns)
                {
                    foreach (var suffix in suffixes)
                    {
                        var expectedWithSuffix = ComputeExpectedWithSuffix(expectedNoun, inputNoun, suffix);

                        yield return new TestCaseData(inputNoun, suffix, expectedWithSuffix)
                            .SetName($"{expectedNoun} + '{inputNoun}' + '{suffix}'");
                    }
                }
            }
        }

        private static List<string> GenerateInputNouns(string expectedNoun)
        {
            List<string> inputNouns = [expectedNoun, expectedNoun.RemoveDiacritics()];

            for (int i = 0; i < expectedNoun.Length; i++)
            {
                char c = expectedNoun[i];

                if (c == 'ă' || c == 'â')
                {
                    inputNouns.Add(expectedNoun[..i] + expectedNoun[i] + expectedNoun[(i + 1)..]);
                    inputNouns.Add(expectedNoun[..i] + 'a' + expectedNoun[(i + 1)..]);
                }
                if (c == 'î')
                {
                    inputNouns.Add(expectedNoun[..i] + expectedNoun[i] + expectedNoun[(i + 1)..]);
                    inputNouns.Add(expectedNoun[..i] + 'i' + expectedNoun[(i + 1)..]);
                }
                if (c == 'ș')
                {
                    inputNouns.Add(expectedNoun[..i] + expectedNoun[i] + expectedNoun[(i + 1)..]);
                    inputNouns.Add(expectedNoun[..i] + 's' + expectedNoun[(i + 1)..]);
                }
                if (c == 'ț')
                {
                    inputNouns.Add(expectedNoun[..i] + expectedNoun[i] + expectedNoun[(i + 1)..]);
                    inputNouns.Add(expectedNoun[..i] + 't' + expectedNoun[(i + 1)..]);
                }
            }

            return [.. inputNouns.Distinct()];
        }

        private static string ComputeExpectedWithSuffix(string expectedNoun, string inputNoun, string suffix)
        {
            var result = expectedNoun;

            if (suffix.StartsWith("i", StringComparison.Ordinal))
            {
                if (inputNoun.EndsWith("st", StringComparison.Ordinal) &&
                    expectedNoun.EndsWith("st", StringComparison.Ordinal))
                {
                    result = expectedNoun[..^2] + "șt";
                }
                else if (inputNoun.EndsWith("t", StringComparison.Ordinal) &&
                        expectedNoun.EndsWith("t", StringComparison.Ordinal))
                {
                    result = expectedNoun[..^1] + "ț";
                }
                else if (inputNoun.EndsWith("s", StringComparison.Ordinal) &&
                        expectedNoun.EndsWith("s", StringComparison.Ordinal))
                {
                    result = expectedNoun[..^1] + "ș";
                }
            }

            return result + suffix;
        }

        [TestCase("actualizeaza", "actualizează")]
        [TestCase("adoarma", "adoarmă")]
        [TestCase("ajuti", "ajuți")]
        [TestCase("aliniaza", "aliniază")]
        [TestCase("amanam", "amânam")]
        [TestCase("apartine", "aparține")]
        [TestCase("aprinda", "aprindă")]
        [TestCase("as prefera", "aș prefera")]
        [TestCase("asa", "așa")]
        [TestCase("ascunsa", "ascunsă")]
        [TestCase("balanta", "balanța")]
        [TestCase("barcuta", "bărcuța")]
        [TestCase("ca am", "că am")]
        [TestCase("ca imi", "că îmi")]
        [TestCase("caine", "câine")]
        [TestCase("castigam", "câștigam")]
        [TestCase("castigat", "câștigat")]
        [TestCase("catel", "cățel")]
        [TestCase("cateva", "câteva")]
        [TestCase("cateva", "câteva")]
        [TestCase("cirese", "cireșe")]
        [TestCase("citeasca", "citească")]
        [TestCase("cladire", "clădire")]
        [TestCase("completeaza", "completează")]
        [TestCase("concentreaza", "concentrează")]
        [TestCase("corecteaza", "corectează")]
        [TestCase("cresti", "crești")]
        [TestCase("cunoastere", "cunoaștere")]
        [TestCase("daca", "dacă")]
        [TestCase("defileaza", "defilează")]
        [TestCase("dependinta", "dependința")]
        [TestCase("deschisa", "deschisă")]
        [TestCase("esti", "ești")]
        [TestCase("estimeaza", "estimează")]
        [TestCase("facea", "făcea")]
        [TestCase("faceam", "făceam")]
        [TestCase("faceti", "faceți")]
        [TestCase("fereasca", "ferească")]
        [TestCase("fleosc", "fleoșc")]
        [TestCase("fondata", "fondată")]
        [TestCase("frisca", "frișca")]
        [TestCase("functionala", "funcțională")]
        [TestCase("functioneaza,", "funcționează,")]
        [TestCase("functioneaza", "funcționează")]
        [TestCase("furnicutele", "furnicutele")]
        [TestCase("garzii", "gărzii")]
        [TestCase("gasesc", "găsesc")]
        [TestCase("gradinita", "grădinița")]
        [TestCase("greseasca", "gresească")]
        [TestCase("greselile", "greșelile")]
        [TestCase("hranesc", "hrănesc")]
        [TestCase("impreuna", "împreună")]
        [TestCase("incearca", "încearcă")]
        [TestCase("incepem", "începem")]
        [TestCase("ingrijorare", "îngrijorare")]
        [TestCase("inlocuiasca", "înlocuiască")]
        [TestCase("inot", "înot")]
        [TestCase("inseamna", "înseamnă")]
        [TestCase("intoarce", "întoarce")]
        [TestCase("intreaga", "întreaga")]
        [TestCase("iuti", "iuți")]
        [TestCase("jucatoarele", "jucătorarele")]
        [TestCase("libertatii", "libertății")]
        [TestCase("logheaza", "loghează")]
        [TestCase("mananc", "mănânc")]
        [TestCase("mancare", "mâncare")]
        [TestCase("mentenanta", "mentenanța")]
        [TestCase("mentin", "mențin")]
        [TestCase("mineaza", "minează")]
        [TestCase("minereasca", "minerească")]
        [TestCase("munceasca", "muncească")]
        [TestCase("muntii", "munții")]
        [TestCase("nationale", "naționale")]
        [TestCase("natiune", "națiune")]
        [TestCase("necesiteaza", "necesitează")]
        [TestCase("niste", "niște")]
        [TestCase("nivelata", "nivelată")]
        [TestCase("noastra", "noastră")]
        [TestCase("noptii", "nopții")]
        [TestCase("noștri", "noștri")]
        [TestCase("odata", "odată")]
        [TestCase("odihneasca", "odihnească")]
        [TestCase("odinioara", "odinioară")]
        [TestCase("orasel", "orășel")]
        [TestCase("orasele", "orașele")]
        [TestCase("oraselele", "orășelele")]
        [TestCase("orasu", "orașu")]
        [TestCase("oua", "ouă")]
        [TestCase("pacat", "păcat")]
        [TestCase("pacate", "păcate")]
        [TestCase("pamant", "pământ")]
        [TestCase("pamantean", "pământean")]
        [TestCase("parea", "părea")]
        [TestCase("parerea", "părerea")]
        [TestCase("piata", "piața")]
        [TestCase("placere", "plăcere")]
        [TestCase("planuiesti", "plănuiești")]
        [TestCase("planuit", "plănuit")]
        [TestCase("poti sa", "poți să")]
        [TestCase("poti", "poți")]
        [TestCase("puna", "pună")]
        [TestCase("pusca", "pușca")]
        [TestCase("rabdare", "răbdare")]
        [TestCase("raman", "rămân")]
        [TestCase("raspunsului", "răspunsului")]
        [TestCase("recunoasca", "recunoască")]
        [TestCase("renuntam", "renunțăm")]
        [TestCase("reusim", "reușim")]
        [TestCase("ridicata", "ridicată")]
        [TestCase("roscata", "roșcata")]
        [TestCase("rugaciune", "rugăciune")]
        [TestCase("ruleaza", "rulează")]
        [TestCase("sambata", "sâmbăta")]
        [TestCase("sansa", "șansa")]
        [TestCase("saptamana", "săptămâna")]
        [TestCase("saraca", "săraca")]
        [TestCase("saracii", "săracii")]
        [TestCase("saracilor", "săracilor")]
        [TestCase("saracit", "săracit")]
        [TestCase("sarat", "sărat")]
        [TestCase("sarbatoare", "sărbătoare")]
        [TestCase("sarpe", "șarpe")]
        [TestCase("scoasa", "scoasă")]
        [TestCase("scobeste", "scobește")]
        [TestCase("scolile", "școlile")]
        [TestCase("scuzati", "scuzați")]
        [TestCase("semneaza", "semnează")]
        [TestCase("sfarseasca", "sfârșească")]
        [TestCase("sfinteasca", "sfințească")]
        [TestCase("slefuita", "șlefuita")]
        [TestCase("sparga", "spargă")]
        [TestCase("spatiu", "spațiu")]
        [TestCase("stanga", "stânga")]
        [TestCase("starneste", "stârnește")]
        [TestCase("stiu", "știu")]
        [TestCase("stramt", "strâmt")]
        [TestCase("stropeasca", "stropească")]
        [TestCase("susta", "șusta")]
        [TestCase("taieri", "tăieri")]
        [TestCase("tarnacop", "târnăcop")]
        [TestCase("teava", "țeava")]
        [TestCase("teleporteaza", "teleportează")]
        [TestCase("temnita", "temnița")]
        [TestCase("temnite", "temnițe")]
        [TestCase("tipai", "țipai")]
        [TestCase("tipam", "țipam")]
        [TestCase("totusi", "totuși")]
        [TestCase("trantesc", "trântesc")]
        [TestCase("trânteasca", "trântească")]
        [TestCase("urmaresc", "urmăresc")]
        [TestCase("vamala", "vamală")]
        [TestCase("viata", "viața")]
        [TestCase("vietii", "vieții")]
        [TestCase("voiasca", "voiască")]
        [TestCase("voiati", "voiați")]
        [TestCase("vopseasca", "vopsească")]
        [TestCase("vorbeasca", "vorbească")]
        [TestCase("voteaza", "votează")]
        [TestCase("voua", "vouă")]
        [TestCase("vreti", "vreți")]
        public void Apply_AddsExpectedDiacritics(string text, string expected)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianDiacriticsRule");

            string result = rule.Apply(text);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(FeminineNounEndingWithIeVariationTestCases))]
        public void GivenFeminineNounEndingWithIe_WhenApplyingTheRule_ThenAllVariationsAreAsExpected(
            string inputNoun, string suffix, string expectedWithSuffix)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianDiacriticsRule");

            string result = rule.Apply(inputNoun + suffix);

            Assert.That(result, Is.EqualTo(expectedWithSuffix));
        }

        [Test]
        [TestCaseSource(nameof(MasculineNounVariationTestCases))]
        public void GivenMasculineAdjectiveOrNoun_WhenApplyingTheRule_ThenAllVariationsAreAsExpected(
            string inputNoun, string suffix, string expectedWithSuffix)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianDiacriticsRule");

            string result = rule.Apply(inputNoun + suffix);

            Assert.That(result, Is.EqualTo(expectedWithSuffix));
        }

        [Test]
        [TestCase("aparat")]
        [TestCase("comanda")]
        [TestCase("consuma")]
        [TestCase("costa")]
        [TestCase("doua")]
        [TestCase("dubla")]
        [TestCase("garda")]
        [TestCase("mutam")]
        [TestCase("natura")]
        [TestCase("necesitam")]
        [TestCase("palma")]
        [TestCase("pita")]
        [TestCase("scoala")]
        [TestCase("stima")]
        [TestCase("strada")]
        [TestCase("strigat")]
        [TestCase("suna")]
        [TestCase("suta")]
        [TestCase("terminam")]
        [TestCase("tipa")]
        [TestCase("tipi")]
        [TestCase("urma")]
        [TestCase("vina")]
        public void GivenDiacriticlessWord_WhenThereIsAmbiguity_ThenDiacriticsAreNotAdded(string text)
        {
            IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianDiacriticsRule");

            string result = rule.Apply(text);

            Assert.That(result, Is.EqualTo(text));
        }

        static IGrammarRule CreateRule(string typeName)
        {
            Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
            return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
        }
    }
}