using System.IO;
using System.Linq;
using System.Text.Json;

namespace Iuliia
{
    public static class Schemas
    {
        public static Scheme Wikipedia { get; }
        public static Scheme Mosmetro { get; }
        public static Scheme YandexMaps { get; }
        public static Scheme YandexMoney { get; }
        /// <summary>
        /// Инструкция Минсвязи о порядке обработки международных телеграмм. Некрасивая, зато без апострофов.
        /// </summary>
        public static Scheme Telegram { get; }
        public static Scheme Scientific { get; }
        public static Scheme ALA_LC  { get; }
        public static Scheme ALA_LC_ALT { get; }
        public static Scheme BGN_PCGN { get; }
        public static Scheme BGN_PCGN_ALT { get; }
        public static Scheme BS_2979 { get; }
        public static Scheme BS_2979_ALT { get; }
        public static Scheme GOST_16876 { get; }
        public static Scheme GOST_16876_ALT { get; }
        public static Scheme GOST_52290 { get; }
        public static Scheme GOST_52535 { get; }
        public static Scheme GOST_7034 { get; }
        public static Scheme GOST_779 { get; }
        public static Scheme GOST_779_ALT { get; }
        public static Scheme ICAO_DOC_9303 { get; }
        public static Scheme ISO_9_1954 { get; }
        public static Scheme ISO_9_1968 { get; }
        public static Scheme ISO_9_1968_ALT { get; }
        public static Scheme MVD_310 { get; }
        public static Scheme MVD_310_FR { get; }
        public static Scheme MVD_782 { get; }
        public static Scheme UNGEGN_1987 { get; }

        static Schemas()
        {
            Wikipedia = LoadScheme("wikipedia.json");
            Mosmetro = LoadScheme("mosmetro.json");
            YandexMaps = LoadScheme("yandex_maps.json");
            YandexMoney = LoadScheme("yandex_money.json");
            Telegram = LoadScheme("telegram.json");
            Scientific = LoadScheme("scientific.json");
            ALA_LC = LoadScheme("ala_lc.json");
            ALA_LC_ALT = LoadScheme("ala_lc_alt.json");
            BGN_PCGN = LoadScheme("bgn_pcgn.json");
            BGN_PCGN_ALT = LoadScheme("bgn_pcgn_alt.json");
            BS_2979 = LoadScheme("bs_2979.json");
            BS_2979_ALT = LoadScheme("bs_2979_alt.json");
            GOST_16876 = LoadScheme("gost_16876.json");
            GOST_16876_ALT = LoadScheme("gost_16876_alt.json");
            GOST_52290 = LoadScheme("gost_52290.json");
            GOST_52535 = LoadScheme("gost_52535.json");
            GOST_7034 = LoadScheme("gost_7034.json");
            GOST_779 = LoadScheme("gost_779.json");
            GOST_779_ALT = LoadScheme("gost_779_alt.json");
            ICAO_DOC_9303 = LoadScheme("icao_doc_9303.json");
            ISO_9_1954 = LoadScheme("iso_9_1954.json");
            ISO_9_1968 = LoadScheme("iso_9_1968.json");
            ISO_9_1968_ALT = LoadScheme("iso_9_1968_alt.json");
            MVD_310 = LoadScheme("mvd_310.json");
            MVD_310_FR = LoadScheme("mvd_310_fr.json");
            MVD_782 = LoadScheme("mvd_782.json");
            UNGEGN_1987 = LoadScheme("ungegn_1987.json");
        }

        private static Scheme LoadScheme(string filename)
        {
            var file = File.ReadAllText($"Schemas/{filename}");
            
            var dto = JsonSerializer.Deserialize<SchemeDto>(file);
            
            return new Scheme(
                dto.Name,
                dto.Mapping.ToDictionary(k => k.Key[0], v => v.Value),
                dto.PreviousMapping,
                dto.NextMapping,
                dto.EndingMapping,
                dto.Samples.Select(s => new Sample(s[0], s[1])).ToArray());
        }
    }
}