using System; 
using FluentAssertions;
using NUnit.Framework;
using Noggle.TikaOnDotNet.Parser;

namespace Noggle.TikaOnDotNet.Tests
{
    [TestFixture]
    public class sad_text_extraction
    {
        private Tika _cut;
        private string _filePathParent;

        [SetUp]
        public virtual void SetUp()
        {
            _cut = new Tika();
            _filePathParent = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        [Test]
        public void issue_81_file_1()
        {
            var filePath = _filePathParent +"sad-files/EI-73-1018-2_5632837.doc";

            Action act = () => _cut.Parse(filePath);

            act.Should().Throw<TextExtractionException>();

            //act.ShouldThrow<TextExtractionException>();
        }

        [Test]
        public void issue_81_file_2()
        {
            var filePath = _filePathParent +"sad-files/EI-73-1027-3_5632849.doc";

            Action act = () => _cut.Parse(filePath);

            act.Should().Throw<TextExtractionException>();
            //act.ShouldThrow<TextExtractionException>();
        }
    }
}
