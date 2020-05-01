using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Iuliia;
using NUnit.Framework;

namespace Iullia.Tests
{
    [TestFixture]
    public class SchemasTests
    {
        [Test, TestCaseSource(typeof(SchemasTestCasesFactory))]
        public void Scheme_Should_TranslateOwnSamples(Sample sample, Scheme scheme)
        {
            Assert.AreEqual(sample.Translated, Engine.Translate(sample.Original, scheme));
        }
    }
    
    public class SchemasTestCasesFactory : IEnumerable<TestCaseData>
    {
        public IEnumerator<TestCaseData> GetEnumerator()
        {
            return typeof(Schemas)
                .GetProperties()
                .Select(p => (Scheme) p.GetValue(null))
                .SelectMany(scheme => scheme.Samples.Select(sample =>
                    new TestCaseData(sample, scheme).SetArgDisplayNames(scheme.Name)))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}