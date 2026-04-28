using System;
using NUnit.Framework;

namespace NuciText.Grammar.Romanian.UnitTests.Rules;

[TestFixture]
public class RomanianDiacriticsRuleTests
{
    [TestCase("as prefera", "aș prefera")]
    [TestCase("ca am", "că am")]
    [TestCase("ca imi", "că îmi")]
    [TestCase("esti", "ești")]
    [TestCase("daca", "dacă")]
    [TestCase("faceti", "faceți")]
    [TestCase("functionala", "funcțională")]
    [TestCase("functioneaza", "funcționează")]
    [TestCase("functioneaza,", "funcționează,")]
    [TestCase("impreuna", "împreună")]
    [TestCase("linistit", "liniștit")]
    [TestCase("mineaza", "minează")]
    [TestCase("niste", "niște")]
    [TestCase("orasu", "orașu")]
    [TestCase("pamant", "pământ")]
    [TestCase("piata", "piață")]
    [TestCase("poti", "poți")]
    [TestCase("poti sa", "poți să")]
    [TestCase("prefera sa", "prefera să")]
    [TestCase("pokemon", "Pokémon")]
    public void Apply_AddsExpectedDiacritics(string text, string expected)
    {
        IGrammarRule rule = CreateRule("NuciText.Grammar.Romanian.Rules.RomanianDiacriticsRule");

        string result = rule.Apply(text);

        Assert.That(result, Is.EqualTo(expected));
    }

    static IGrammarRule CreateRule(string typeName)
    {
        Type ruleType = typeof(RomanianGrammarCorrector).Assembly.GetType(typeName, throwOnError: true)!;
        return (IGrammarRule)Activator.CreateInstance(ruleType, nonPublic: true)!;
    }
}