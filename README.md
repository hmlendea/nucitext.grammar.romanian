[![Donate](https://img.shields.io/badge/-%E2%99%A5%20Donate-%23ff69b4)](https://hmlendea.go.ro/fund.html)
[![Latest Release](https://img.shields.io/github/v/release/hmlendea/nucitext.grammar.romanian)](https://github.com/hmlendea/nucitext.grammar.romanian/releases/latest)
[![Build Status](https://github.com/hmlendea/nucitext.grammar.romanian/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hmlendea/nucitext.grammar.romanian/actions/workflows/dotnet.yml)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://gnu.org/licenses/gpl-3.0)

# NuciText.Grammar.Romanian

Romanian grammar correction package for [NuciText.Grammar](https://github.com/hmlendea/nucitext.grammar).

It applies a deterministic rule pipeline tuned for Romanian chat and informal text:

- slang expansion
- typo correction
- diacritics and orthography normalization
- spacing and punctuation cleanup
- emoji normalization
- fraction glyph replacement

## Features

- Fixes common Romanian typing mistakes (for example: `acm` -> `acum`, `supsol` -> `subsol`)
- Adds Romanian diacritics in high-confidence contexts (for example: `daca` -> `dacă`, `esti` -> `ești`)
- Converts `tz` before vowels to `ț` (for example: `tzara` -> `țara`)
- Expands chat slang (for example: `nush` -> `nu știu`, `pt` -> `pentru`)
- Normalizes spacing and punctuation (for example: `salut,lume` -> `salut, lume`)
- Normalizes chat emoji formatting (for example: `xd` -> `xD`)
- Replaces common fractions with glyphs (for example: `1/2` -> `½`)
- Trims leading/trailing whitespace and compresses exaggerated repeated characters

## Installation

[![Get it from NuGet](https://raw.githubusercontent.com/hmlendea/readme-assets/master/badges/stores/nuget.png)](https://nuget.org/packages/NuciText.Grammar.Romanian)

### .NET CLI

```bash
dotnet add package NuciText.Grammar.Romanian
```

### Package Manager

```powershell
Install-Package NuciText.Grammar.Romanian
```

## Requirements

- .NET SDK/runtime with support for `net10.0`

## Quick Start

```csharp
using NuciText.Grammar;
using NuciText.Grammar.Romanian;

IGrammarCorrector corrector = new RomanianGrammarCorrector();

string input = "daca vrei poti sa vi la mn";
string output = corrector.Correct(input);

// output: "dacă vrei poți să vii la mine"
```

## What Is Included

- `RomanianGrammarCorrector`: entry point implementing `IGrammarCorrector`
- `RomanianGrammarRuleSet`: Romanian rule set (`LanguageCode = "ro"`) used by the corrector

Current rule pipeline:

1. Trim whitespace
2. Compress very long repeated character runs
3. `tz` -> `ț` before vowels
4. Replace Romanian slang expressions
5. Add Romanian diacritics and orthographic fixes
6. Normalize selected proper nouns
7. Normalize spacing around punctuation and emoticons
8. Normalize emoji casing/format
9. Fix common Romanian chat typos
10. Re-apply diacritic normalization
11. Insert commas in selected conversational expressions
12. Replace common ASCII fractions with Unicode fraction glyphs
13. Replace selected noun endings from `u` to `ul`

## Scope And Limitations

- The package is intentionally rule-based, deterministic, and fast.
- It focuses on high-confidence fixes for Romanian informal/chat-style text.
- It is not a full syntactic parser and does not attempt deep grammatical rewriting.
- Some transformations are context-sensitive but still heuristic; review output for critical or formal content.

## Development

### Build

```bash
dotnet build NuciText.Grammar.Romanian.sln
```

### Test

```bash
dotnet test NuciText.Grammar.Romanian.sln
```

### Release

```bash
dotnet pack -c Release
```

## Contributing

Contributions are welcome.

Please:

- keep the changes cross-platform
- keep the public APIs intact, unless the change is intentionally breaking
- keep the pull requests focused and consistent with the existing style
- update the documentation when the behaviour changes
- add or update the tests for any new behaviour

## Related Projects

- [NuciText.Grammar](https://github.com/hmlendea/nucitext.grammar)
- [NuciText.Grammar.English](https://github.com/hmlendea/nucitext.grammar.english)

## License

Licensed under the GNU General Public License v3.0 or later.
See [LICENSE](./LICENSE) for details.
