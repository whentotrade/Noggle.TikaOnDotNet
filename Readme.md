Tika on .NET
============

[![NuGet version](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Parser.svg)](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Parser)

The project provides a .NET wrapper with simple helper functions around the [Tika](http://tika.apache.org/) text extraction library. To use the Tika Java libraries in your .NET application via IKVM. 

## Getting Started 

- Add a Nuget dependency to [Noggle.TikaOnDotNet.Parser](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Parser/).
- Instantiate a new `Tika` object and call one of the `Parser` methods.

### Usage 
```cs
using Noggle.TikaOnDotNet.Parser;

var tika = new Tika();

//simple text extraction from File/URL/Stream
string textFromFile = tika.ParseToString(stringToFile);
string textFromStream = tika.ParseToString(streamObject);
string textFromByteArray =tika.ParseToString(byteArrayObject);

//Parse a document and extract text and metadata from File/URL/Stream
var localFileContents = tika.Parse(stringToFile);
var webPageContents = tika.Parse(new Uri("https://google.com"));
var streamDocResults = tika.Parse(new FileStream(file, FileMode.Open, FileAccess.Read));

//Detect Language from string
var lang = tika.GetLanguage(textString);

```


## Nuget

This project produces two nugets:

- **Noggle.TikaOnDotNet**: A straight [IKVM](http://www.ikvm.net/userguide/ikvmc.html) hosted port of Java Tika project.
Link: https://www.nuget.org/packages/Noggle.TikaOnDotnet/

- **Noggle.TikaOnDotNet.Parser**: A wrapper with helper functions to use Tika to extract text and additional metadata from rich documents. Link: https://www.nuget.org/packages/Noggle.TikaOnDotNet.Parser/

## How To Update

Start out by taking a look at the [Developer Guide](https://github.com/whentotrade/noggle.tikaondotnet/blob/master/Developers.md). 

## Source Reference
This project is an individual fork and extension of [TikaOnDotNet](https://github.com/KevM/tikaondotnet). It has upgraded .NET, Visual Stuio, FAKE And NUnit3 framwork dependencies as well as using newer Tika java version. There have been additional individual feature upgrades in the wrapper package Noggle.TikaOnDotNet.Parser. Original version was done by KevM as TikaOnDotNet.Text package.
