using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Noggle.TikaOnDotNet.Parser;
using System.Diagnostics;

namespace Noggle.TikaOnDotNet.Tests
{
    [TestFixture]
    public class StreamDetection
    {
        private Tika tika;
        private string _filePathParent;

        [SetUp]
        public virtual void SetUp()
        {
            tika = new Tika();
            _filePathParent = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        [Test]
        public void StreamParsing()
        {
            string filePath=_filePathParent + "files/Tika.rtf";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {

                var result = tika.Parse(fileStream);

                result.Text.Should().Contain("pack of pickled almonds");
            }

        }
        [Test]
        public void Simple_File_To_String_Parsing()
        {
            string text = tika.ParseToString(_filePathParent + "files/Tika.rtf");

            text.Should().Contain("pack of pickled almonds");
        }

    }
}
