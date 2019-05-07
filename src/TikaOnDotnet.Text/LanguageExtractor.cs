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
        public LanguageExtractionResult GetLanguage(string text)
        {

            var ldetector = new OptimaizeLangDetector().loadModels();
            var lresult = ldetector.detect(text);

            var language = lresult.getLanguage() ?? "";
            var confidence = lresult.getConfidence().name() ?? "";

            return new LanguageExtractionResult
            {
                Language = language,
                Confidence = confidence
            };

        }

    }
}
