using System;
using java.io;
using org.apache.tika.metadata;

namespace Noggle.TikaOnDotNet.Parser
{
    public interface ITika
    {
        /// <summary>
        ///     Extract the text from the given file and returns it as an <see cref="TextExtractionResult" /> object
        /// </summary>
        /// <param name="filePath">The file with its full path</param>
        /// <exception cref="TextExtractionException"></exception>
        TextExtractionResult Parse(string filePath);

        /// <summary>
        ///     Extract the text from the given byte array and returns it as an <see cref="TextExtractionResult" /> object
        /// </summary>
        /// <param name="data">Bytes of content from which you'd like Tika to extract text.</param>
        /// <exception cref="TextExtractionException"></exception>
        TextExtractionResult Parse(byte[] data);

        /// <summary>
        ///     Extract from the give uri and returns it as an <see cref="TextExtractionResult" /> object
        /// </summary>
        /// <param name="uri">Url to download and </param>
        /// <exception cref="TextExtractionException"></exception>
        TextExtractionResult Parse(Uri uri);

        /// <summary>
        ///     Extract the text from the inputstream and returns it as an <see cref="TextExtractionResult" /> object. 
        ///     Wraps .net stream into java.io.stream
        /// </summary>
        /// <param name="inputStream">Function returning an <see cref="InputStream"/> of content you with extracted.</param>
        /// <exception cref="TextExtractionException"></exception>
        TextExtractionResult Parse(System.IO.Stream inputStream);

        /// <summary>
        ///     Extract the text from the given inputstreams and returns it as an <see cref="TextExtractionResult" /> object. 
        ///     This is the lowest level overload which all the other overloads use under the hood.
        /// </summary>
        /// <param name="streamFactory">Function taking a <see cref="Metadata"/> and returning an <see cref="InputStream"/> of content you with extracted.</param>
        /// <exception cref="TextExtractionException"></exception>
        TextExtractionResult Parse(Func<Metadata, InputStream> streamFactory);

        /// <summary>
        ///     Extract the language from a text and returns it as <see cref="anguageExtractionResult"  /> object.
        /// </summary>
        /// <param name="text">Input text to check language as string.</param>
        LanguageExtractionResult GetLanguage(string text);

        /// <summary>
        ///     Extract the text from the given file and returns the content as <see cref="string" />
        /// </summary>
        /// <param name="filePath">The file with its full path</param>
        /// <exception cref="TextExtractionException"></exception>
        string ParseToString(string filePath);

        /// <summary>
        ///     Extract the text from the given byte array and returns the content as <see cref="string" />
        /// </summary>
        /// <param name="data">The byte array with data</param>
        /// <exception cref="TextExtractionException"></exception>
        string ParseToString(byte[] data);

        /// <summary>
        ///     Extract the text from the given URI URL and returns the content as <see cref="string" />
        /// </summary>
        /// <param name="url">The URI with URL to parse</param>
        /// <exception cref="TextExtractionException"></exception>
        string ParseToString(Uri url);

        /// <summary>
        ///     Extract the text from the given System.IO.Stream and returns the content as <see cref="string" />
        /// </summary>
        /// <param name="inputStream">The System IO Stream object</param>
        /// <exception cref="TextExtractionException"></exception>
        string ParseToString(System.IO.Stream inputStream);
    }
}
