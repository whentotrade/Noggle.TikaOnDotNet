using System;
using System.IO;
using System.Linq;
using System.Net;
using java.io;
using org.apache.tika.io;
using org.apache.tika.metadata;
using Noggle.TikaOnDotNet.Parser.Stream;
using Exception = System.Exception;
using org.apache.tika.langdetect;

namespace Noggle.TikaOnDotNet.Parser
{
    public partial class Tika : ITika
    {
        public string ParseToString(string filePath)
        {
            return Parse(filePath, LegacyResultAssembler).Text ?? "";
        }


        public TextExtractionResult Parse(string filePath)
        {
            return Parse(filePath, LegacyResultAssembler);
        }

        public TExtractionResult Parse<TExtractionResult>(
            string filePath,
            Func<string, Metadata, TExtractionResult> extractionResultAssembler
            )
        {
            try
            {
                return Parse(FileStreamFactory, extractionResultAssembler);
            }
            catch (Exception ex)
            {
                throw new TextExtractionException("Extraction of text from the file '{0}' failed.".ToFormat(filePath), ex);
            }

            InputStream FileStreamFactory(Metadata metadata)
            {
                var inputStream = new FileInputStream(filePath);

                var result = TikaInputStream.get(inputStream);
                metadata.add("FilePath", filePath);
                return result;
            }
        }
        public string ParseToString(byte[] data)
        {
            return Parse(data, LegacyResultAssembler).Text ?? "";
        }

        public TextExtractionResult Parse(byte[] data)
        {
            return Parse(data, LegacyResultAssembler);
        }

        public TExtractionResult Parse<TExtractionResult>(byte[] data, Func<string, Metadata, TExtractionResult> extractionResultAssembler)
        {
            return Parse(metadata => TikaInputStream.get(data, metadata), extractionResultAssembler);
        }

        public string ParseToString(Uri uri)
        {
            return Parse(uri, LegacyResultAssembler).Text ?? "";
        }

        public TextExtractionResult Parse(Uri uri)
        {
            return Parse(uri, LegacyResultAssembler);
        }

        public TExtractionResult Parse<TExtractionResult>(
            Uri uri,
            Func<string, Metadata, TExtractionResult> extractionResultAssembler
        )
        {
            return Parse(UrlStreamFactory, extractionResultAssembler);

            InputStream UrlStreamFactory(Metadata metadata)
            {
                metadata.add("Uri", uri.ToString());
                var pageBytes = new WebClient().DownloadData(uri);

                return TikaInputStream.get(pageBytes, metadata);
            }
        }

        public string ParseToString(System.IO.Stream inputStream)
        {
            return Parse(inputStream).Text ?? "";
        }

        public TextExtractionResult Parse(System.IO.Stream inputStream)
        {
            return Parse(inputStream, LegacyResultAssembler);
            //var javaInputStream = new ikvm.io.InputStreamWrapper(inputStream); //or directly use the filestream
            //return Parse(metadata2 => TikaInputStream.get(javaInputStream));
        }

        public TExtractionResult Parse<TExtractionResult>(
            System.IO.Stream inputStream,
            Func<string, Metadata, TExtractionResult> extractionResultAssembler
            )
        {
            try
            {
                return Parse(SystemStreamFactory, extractionResultAssembler);
            }
            catch (Exception ex)
            {
                throw new TextExtractionException("Extraction of text from stream failed.", ex);
            }

            InputStream SystemStreamFactory(Metadata metadata)
            {
                var ioStream = new ikvm.io.InputStreamWrapper(inputStream);
                var result = TikaInputStream.get(ioStream);
                return result;
            }
        }

        public TextExtractionResult Parse(Func<Metadata, InputStream> streamFactory)
        {
            return Parse(streamFactory, LegacyResultAssembler);
        }

        public TExtractionResult Parse<TExtractionResult>(Func<Metadata, InputStream> streamFactory, Func<string, Metadata, TExtractionResult> extractionResultAssembler)
        {
            var streamExtractor = new StreamTextExtractor();
            using (var outputStream = new MemoryStream())
            {
                var metadata = streamExtractor.Extract(streamFactory, outputStream);
                outputStream.Position = 0;

                using (var reader = new StreamReader(outputStream))
                {
                    var text = reader.ReadToEnd();
                    return extractionResultAssembler(text, metadata);
                }
            }
        }

        private static TextExtractionResult LegacyResultAssembler(string text, Metadata metadata)
        {
            var metaDataDictionary = metadata.names()
                .ToDictionary(name => name, name => string.Join(", ", metadata.getValues(name)));
            var contentType = metaDataDictionary["Content-Type"];

            return new TextExtractionResult
            {
                Metadata = metaDataDictionary,
                Text = text,
                ContentType = contentType
            };
        }
    }
}
