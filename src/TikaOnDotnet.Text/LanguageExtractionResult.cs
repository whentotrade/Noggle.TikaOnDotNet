using System.Collections.Generic;
using System.Text;

namespace Noggle.TikaOnDotNet.Parser
{
   
    public class LanguageExtractionResult
    {
        /// <summary>
        /// Language code extracted from the source data
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Confidence of detected language
        /// </summary>
        public string Confidence { get; set; }

       
    }
}
