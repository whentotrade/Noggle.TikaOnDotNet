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
    public class LanguageDetection
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
        public void ShouldBeGerman()
        {
            string text = "Dies is eine Autobahn mit Verkehrsleitung.";

            var lang = _cut.GetLanguage(text).Language;

            lang.Should().Be("de");

        }

        [Test]
        public void ShouldBeEnglish()
        {
            string text = "This is made in Hamburg with fresh cheese on top.";

            var lang = _cut.GetLanguage(text).Language;
            
            lang.Should().Be("en");

        }

        [Test]
        public void ShouldNotBeEnglish()
        {
            string text = "Manchmal avoid pour pas Voila Hamburg is good.";

            var lang = _cut.GetLanguage(text).Language;

            lang.Should().NotBe("en");

        }
    }
}
