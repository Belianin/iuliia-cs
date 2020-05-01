using System.Linq;
using Iuliia;
using NUnit.Framework;

namespace Iullia.Tests
{
    [TestFixture]
    public class SchemasTests
    {
        [Test]
        public void TelegramScheme_Should_TranslateCorrect()
        {
            var original = "Юлия, съешь ещё этих мягких французских булок из Йошкар-Олы, да выпей алтайского чаю";
            var expected = "Iuliia, sesh esce etih miagkih francuzskih bulok iz Ioshkar-Oly, da vypei altaiskogo chaiu";

            Assert.AreEqual(expected, Engine.Translate(original, Schemas.Telegram));
        }

        [Test, TestCaseSource(nameof(SchemeCases))]
        public void Scheme_Should_TranslateOwnSamples(Scheme scheme)
        {
            foreach (var sample in scheme.Samples)
            {
                Assert.AreEqual(sample.Translated, Engine.Translate(sample.Original, scheme), scheme.Name);
            }
        }

        private static readonly object[][] SchemeCases =
            typeof(Schemas).GetProperties().Select(p => new[] {p.GetValue(null)}).ToArray();
    }
}