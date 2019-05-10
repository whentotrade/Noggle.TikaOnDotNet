using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using org.apache.tika.io;
using Noggle.TikaOnDotNet.Parser;
using Noggle.TikaOnDotNet.Parser.Stream;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noggle.TikaOnDotNet.Tests
{
    [TestFixture]
    public class Penetration
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
        public void ParallelTestWithCentralParser()
        {
            var plist = new List<KeyValuePair<string, string>>();

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>(_filePathParent+"files/Tika.pptx", "Tika Test Presentation"));
            list.Add(new KeyValuePair<string, string>(_filePathParent+"files/Tika.docx", "formatted in interesting ways"));
            list.Add(new KeyValuePair<string, string>(_filePathParent+"files/Tika.xlsx", "Use the force duke"));

            for (int i = 0; i < 1000; i++)
            {
                plist.AddRange(list);
            }

            Parallel.ForEach(plist, (test) =>
            {
                var result = tika.Parse(test.Key);
                result.Text.Should().Contain(test.Value);

                var result2 = tika.ParseToString(test.Key);
                result2.Should().Contain(test.Value);

            });
            

        }

        [Test]
        public void ParallelTestWithLokalParser()
        {
            var plist = new List<KeyValuePair<string, string>>();

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>(_filePathParent + "files/Tika.pptx", "Tika Test Presentation"));
            list.Add(new KeyValuePair<string, string>(_filePathParent + "files/Tika.docx", "formatted in interesting ways"));
            list.Add(new KeyValuePair<string, string>(_filePathParent + "files/Tika.xlsx", "Use the force duke"));

            for (int i = 0; i < 1000; i++)
            {
                plist.AddRange(list);
            }

            Parallel.ForEach(plist, (test) =>
            {
                var tika2 = new Tika();
                var result = tika2.Parse(test.Key);
                result.Text.Should().Contain(test.Value);

                var result2 = tika.ParseToString(test.Key);
                result2.Should().Contain(test.Value);

            });


        }


    }
}
