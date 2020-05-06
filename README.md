# `Iuliia`
> Transliterate Cyrillic → Latin in every possible way

> This is the C# port of the Python [iuliia](https://github.com/nalgeon/iuliia-py) package

Transliteration means representing Cyrillic data (mainly names and geographic locations) with Latin letters. It is used for international passports, visas, green cards, driving licenses, mail and goods delivery etc.

`Iuliia` makes transliteration as easy as:

```cs
IuliiaTranslator.Translate("Юлия Щеглова", Schemas.Mosmetro);
> "Yuliya Scheglova"
```

## Why use `Iuliia`

- [20 transliteration schemas](https://github.com/nalgeon/iuliia) (rule sets), including all main international and Russian standards.
- Correctly implements not only the base mapping, but all the special rules for letter combinations and word endings.
- Simple API and zero third-party dependencies.

## Installation

```sh
Install-Package Iuliia -Version 2.0.2
```

[Nuget package](https://www.nuget.org/packages/Iuliia/)

## Usage

```cs
IuliiaTranslator.Translate("Юлия Щеглова", Schemas.Mosmetro);
> "Yuliya Scheglova"
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Make sure to add or update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
