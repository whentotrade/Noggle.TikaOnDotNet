Tika on .NET
============

[![NuGet version](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text.svg)](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text)

The project provides a simple wrapper around the [Tika](http://tika.apache.org/) Java text extraction library. 

This project produces two nugets:
- Noggle.TikaOnDotNet - A straight [IKVM](http://www.ikvm.net/userguide/ikvmc.html) hosted port of Java Tika project.

[![Install-Package Noggle.TikaOnDotNet](https://cldup.com/H-IdGdU75T.png)](https://www.nuget.org/packages/Noggle.TikaOnDotnet/)

- Noggle.TikaOnDotNet.Text - Use Tika to extract text and additional metadata from rich documents.

[![Install-Package Noggle.TikaOnDotNet.Text](https://cldup.com/_BM0b5jVjU.png)](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/)

## Getting Started 

- Add a Nuget dependency to [Noggle.TikaOnDotNet.Text](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/).
- Instantiate a new `TikaParser` object and call one of the `Extract` methods.

### Usage 
```cs
using Noggle.TikaOnDotNet.Text;

var textExtractor = new TikaParser();

var wordDocContents = textExtractor.Extract(@".\path\to\my favorite word.docx");
var webPageContents = textExtractor.Extract(new Uri("https://google.com"));
```

## How To Update as Developer

Start out by taking a look at the [Developer Guide](https://github.com/whentotrade/noggle.tikaondotnet/blob/master/Developers.md). 

## Original Source Reference
This project is an individual fork and extension of [TikaOnDotNet](https://github.com/KevM/tikaondotnet). It has upgraded .NET, Visual Stuio, FAKE And NUnit3 framwork dependencies as well as using a newer Tika java version. There have been additional individual feature upgrades.
