using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Noggle.TikaOnDotNet.Text;
using System.Diagnostics;

namespace Noggle.TikaOnDotNet.Tests
{
    [TestFixture]
    public class text_extraction
    {
        private TikaParser _cut;
        private string _filePathParent;

        [SetUp]
        public virtual void SetUp()
        {
            _cut = new TikaParser();
            _filePathParent = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        [Test]
        public void non_existing_files_should_fail_with_exception()
        {
            string fileName = _filePathParent + "files/doesnotexist.mp3";


            Action act = () => _cut.Extract(fileName);

            act.Should().Throw<TextExtractionException>().Which.Message.Should().Contain(fileName);

            //act.ShouldThrow<TextExtractionException>()
            //    .Which.Message.Should().Contain(fileName);
        }

        [Test]
        public void non_existing_uri_should_fail_with_exception()
        {
            const string uri = "http://example.com/does/not/really/exist/mp3/repo/zzzarble.mp3";

            Action act = () => _cut.Extract(new Uri(uri));

            act.Should().Throw<TextExtractionException>();
            //act.ShouldThrow<TextExtractionException>();
        }

        [Test]
        public void should_extract_mp4()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/badgers.mp4");

            textExtractionResult.ContentType.Should().Be("video/mp4");
        }

        [Test]
        public void should_be_able_to_delete_the_mp4_after_extraction()
        {
            var original = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), _filePathParent + @"files\badgers.mp4"));
            var mp4 = original.CopyTo(Path.Combine(Directory.GetCurrentDirectory(), _filePathParent + @"files\badgers.bak.mp4"));

            _cut.Extract(_filePathParent + "files/badgers.bak.mp4");

            mp4.Delete();
            mp4.Exists.Should().BeFalse();
        }

        [Test]
        public void extract_by_filepath_should_add_filepath_to_metadata()
        {
            string filePath = (_filePathParent + "files/apache.jpg");

            var textExtractionResult = _cut.Extract(filePath);

            textExtractionResult.Metadata["FilePath"].Should().Be(filePath);
        }

        [Test]
        public void should_extract_contained_filenames_from_zips()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/tika.zip");

            textExtractionResult.Text.Should().Contain("Tika.docx");
            textExtractionResult.Text.Should().Contain("Tika.pptx");
            textExtractionResult.Text.Should().Contain("tika.xlsx");
        }

        [Test]
        public void should_extract_contained_filenames_and_text_from_zips()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/tika.zip");

            var fileNames = new List<string>(new[] { "Tika.docx", "Tika.pptx", "tika.xlsx" });

            //verify all expected files are there
            fileNames.ForEach(name => textExtractionResult.Text.Should().Contain(name));

            //we should find the same string once for every file in the zip. if we split the string on file names
            // this should break out the content into different strings to confirm the phrase is found in each extracted text content,
            // not just multiple times in one file.
            var splits = textExtractionResult.Text.Split(fileNames.ToArray(), StringSplitOptions.None);
            var foundCount = splits.Count(s => s.Contains("Use the force duke"));
            foundCount.Should().Be(fileNames.Count);
        }

        [Test]
        public void should_extract_from_jpg()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/apache.jpg");

            textExtractionResult.Text.Trim().Should().BeEmpty();

            textExtractionResult.Metadata["Software"].Should().Contain("Paint.NET");
        }

        [Test]
        public void should_extract_from_rtf()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.rtf");

            textExtractionResult.Text.Should().Contain("pack of pickled almonds");
        }

        [Test]
        public void should_extract_from_pdf()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.pdf");

            textExtractionResult.Text.Should().Contain("pack of pickled almonds");
        }

        [Test]
        public void should_extract_from_docx()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.docx");

            textExtractionResult.Text.Should().Contain("formatted in interesting ways");
        }

        [Test]
        public void should_extract_from_pptx()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.pptx");

            textExtractionResult.Text.Should().Contain("Tika Test Presentation");
        }

        [Test]
        public void should_extract_from_xlsx()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.xlsx");

            textExtractionResult.Text.Should().Contain("Use the force duke");
        }

        [Test]
        public void should_extract_from_doc()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.doc");

            textExtractionResult.Text.Should().Contain("formatted in interesting ways");
        }

        [Test]
        public void should_extract_from_ppt()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.ppt");

            textExtractionResult.Text.Should().Contain("This document is used for testing");
        }

        [Test]
        public void should_extract_from_xls()
        {
            var textExtractionResult = _cut.Extract(_filePathParent + "files/Tika.xls");

            textExtractionResult.Text.Should().Contain("Use the force duke");
        }

        [Test]
        public void should_extract_from_xls_with_byte()
        {
            var data = File.ReadAllBytes(_filePathParent+"files/Tika.xls");
            var textExtractionResult = _cut.Extract(data);

            textExtractionResult.Text.Should().Contain("Use the force duke");
        }

        [Test]
        public void should_extract_from_uri()
        {
            const string url = "http://google.com/";
            var textExtractionResult = _cut.Extract(new Uri(url));

            textExtractionResult.Text.Should().Contain("Google");
            textExtractionResult.Metadata["Uri"].Should().Be(url);
        }

        [Test]
        public void should_extract_msg()
        {

            var textExtractionResult = _cut.Extract(_filePathParent + "/files/Tika.msg");

            textExtractionResult.Text.Should().Contain("This is my test file");
            textExtractionResult.Metadata["subject"].Should().Be("This is the subject");
        }

        [Test]
        public void should_extract_uri_contents()
        {
            const string url = "https://en.wikipedia.org/wiki/Apache_Tika";

            var textExtractionResult = _cut.Extract(new Uri(url));

            textExtractionResult.Text.Should().Contain("Apache Tika is a content detection and analysis framework");
            textExtractionResult.Metadata["Uri"].Should().Be(url);
        }
    }
}