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