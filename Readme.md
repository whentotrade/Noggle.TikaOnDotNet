Tika on .NET
============

[![NuGet version](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text.svg)](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text)

The project provides a wrapper and helper functions around the [Tika](http://tika.apache.org/) Java text extraction library. 

## Getting Started 

- Add a Nuget dependency to [Noggle.TikaOnDotNet.Text](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/).
- Instantiate a new `TikaParser` object and call one of the `Extract` methods.

### Usage 
```cs
using Noggle.TikaOnDotNet.Text;

var textParser = new TikaParser();

//Parse document file
var wordDocContents = textParser.Extract(stringToFile);

//Parse URL
var webPageContents = textParser.Extract(new Uri("https://google.com"));

//Parsing .NET Stream
using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
{
    var streamDocResults = textParser.Extract(fileStream);
}
```


## Nuget

This project produces two nugets:

- **Noggle.TikaOnDotNet**: A straight [IKVM](http://www.ikvm.net/userguide/ikvmc.html) hosted port of Java Tika project.
Link: https://www.nuget.org/packages/Noggle.TikaOnDotnet/

- **Noggle.TikaOnDotNet.Text**: A wrapper with helper functions to use Tika to extract text and additional metadata from rich documents. Link: https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/

## How To Update

Start out by taking a look at the [Developer Guide](https://github.com/whentotrade/noggle.tikaondotnet/blob/master/Developers.md). 

## Source Reference
This project is an individual fork and extension of [TikaOnDotNet](https://github.com/KevM/tikaondotnet). It has upgraded .NET, Visual Stuio, FAKE And NUnit3 framwork dependencies as well as using newer Tika java version. There have been additional individual feature upgrades in the wrapper package Noggle.TikaOnDotNet.Text.
