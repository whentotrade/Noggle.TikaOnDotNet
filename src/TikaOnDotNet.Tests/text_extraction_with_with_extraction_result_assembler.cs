using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using org.apache.tika.metadata;
using Noggle.TikaOnDotNet.Parser;

namespace Noggle.TikaOnDotNet.Tests
{
    [TestFixture]
    public class text_extraction_with_with_extraction_result_assembler
    {
        private Tika _cut;
        private string _filePathParent;

        [SetUp]
        public virtual void SetUp()
        {
            _cut = new Tika();
            _filePathParent = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }
        public class CustomResult
        {
            public string Text { get; set; }
            public IDictionary<string, string[]> Metadata { get; set; }
        }

        public static CustomResult CreateCustomResult(string text, Metadata metadata)
        {
            var metaDataDictionary = metadata.names().ToDictionary(name => name, metadata.getValues);

            return new CustomResult
            {
                Metadata = metaDataDictionary,
                Text = text,
            };
        }

        [Test]
        public void should_extract_author_list_from_pdf()
        {
            var textExtractionResult = _cut.Parse(_filePathParent + "files/file_author.pdf", CreateCustomResult);

            textExtractionResult.Metadata["meta:author"].Should().ContainInOrder("Bernal, M. A.", "deAlmeida, C. E.", "Incerti, S.", "Champion, C.", "Ivanchenko, V.", "Francis, Z.");
        }
    }
}