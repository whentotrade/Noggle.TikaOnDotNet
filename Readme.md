Tika on .NET
============

[![NuGet version](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text.svg)](https://badge.fury.io/nu/Noggle.TikaOnDotNet.Text)

This project is a simple wrapper around the very excellent and robust
[Tika](http://tika.apache.org/) text extraction Java library. This project produces two nugets:
- TikaOnDotNet - A straight [IKVM](http://www.ikvm.net/userguide/ikvmc.html) hosted port of Java Tika project.

[![Install-Package Noggle.TikaOnDotNet](https://cldup.com/H-IdGdU75T.png)](https://www.nuget.org/packages/Noggle.TikaOnDotnet/)

- Noggle.TikaOnDotNet.Text - Use Tika to extract text from rich documents.

[![Install-Package Noggle.TikaOnDotNet.Text](https://cldup.com/_BM0b5jVjU.png)](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/)

## Getting Started 

The best way to get started is to:
- Add a Nuget dependency to [Noggle.TikaOnDotNet.Text](https://www.nuget.org/packages/Noggle.TikaOnDotNet.Text/).
- Instantiate a new `TikaParser` object and call one of the `Extract` methods.

### Usage 
```cs
using Noggle.TikaOnDotNet.Text;

var textExtractor = new TikaParser();

var wordDocContents = textExtractor.Extract(@".\path\to\my favorite word.docx");
var webPageContents = textExtractor.Extract(new Uri("https://google.com"));
```

Take a look at [our tests](https://github.com/KevM/tikaondotnet/tree/master/src/TikaOnDotNet.Tests) for more usage examples. 

## How To Contribute

Have an idea to make this project better? Great! Start out by taking a look at our [Contributing Guide](https://github.com/KevM/tikaondotnet/blob/master/Contributing.md).

## Having A Problem?

Search in the [Issues](https://github.com/KevM/tikaondotnet/issues?q=is%3Aopen+is%3Aissue)
as your problem may be a common one. If don't find your problem please [create an
issue](https://github.com/KevM/tikaondotnet/issues/new). Contributors here will
chime in when they can.