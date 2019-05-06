using System;

namespace Noggle.TikaOnDotNet.Text
{
    public class TextExtractionException : Exception
    {
        public TextExtractionException(string message) : base(message)
        {

        }

        public TextExtractionException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
