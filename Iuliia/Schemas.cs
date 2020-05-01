using Iuliia.Dto;

namespace Iuliia
{
    public static class Schemas
    {
        public static Scheme Wikipedia { get; } = SchemeReader.Read("wikipedia.json");
        public static Scheme Mosmetro { get; } = SchemeReader.Read("mosmetro.json");
        public static Scheme YandexMaps { get; } = SchemeReader.Read("yandex_maps.json");
        public static Scheme YandexMoney { get; } = SchemeReader.Read("yandex_money.json");
        /// <summary>
        /// Инструкция Минсвязи о порядке обработки международных телеграмм. Некрасивая, зато без апострофов.
        /// </summary>
        public static Scheme Telegram { get; } = SchemeReader.Read("telegram.json");
        public static Scheme Scientific { get; } = SchemeReader.Read("scientific.json");
        public static Scheme ALA_LC  { get; } = SchemeReader.Read("ala_lc.json");
        public static Scheme ALA_LC_ALT { get; } = SchemeReader.Read("ala_lc_alt.json");
        public static Scheme BGN_PCGN { get; } = SchemeReader.Read("bgn_pcgn.json");
        public static Scheme BGN_PCGN_ALT { get; } = SchemeReader.Read("bgn_pcgn_alt.json");
        public static Scheme BS_2979 { get; } = SchemeReader.Read("bs_2979.json");
        public static Scheme BS_2979_ALT { get; } = SchemeReader.Read("bs_2979_alt.json");
        public static Scheme GOST_16876 { get; } = SchemeReader.Read("gost_16876.json");
        public static Scheme GOST_16876_ALT { get; } = SchemeReader.Read("gost_16876_alt.json");
        public static Scheme GOST_52290 { get; } = SchemeReader.Read("gost_52290.json");
        public static Scheme GOST_52535 { get; } = SchemeReader.Read("gost_52535.json");
        public static Scheme GOST_7034 { get; } = SchemeReader.Read("gost_7034.json");
        public static Scheme GOST_779 { get; } = SchemeReader.Read("gost_779.json");
        public static Scheme GOST_779_ALT { get; } = SchemeReader.Read("gost_779_alt.json");
        public static Scheme ICAO_DOC_9303 { get; } = SchemeReader.Read("icao_doc_9303.json");
        public static Scheme ISO_9_1954 { get; } = SchemeReader.Read("iso_9_1954.json");
        public static Scheme ISO_9_1968 { get; } = SchemeReader.Read("iso_9_1968.json");
        public static Scheme ISO_9_1968_ALT { get; } = SchemeReader.Read("iso_9_1968_alt.json");
        public static Scheme MVD_310 { get; } = SchemeReader.Read("mvd_310.json");
        public static Scheme MVD_310_FR { get; } = SchemeReader.Read("mvd_310_fr.json");
        public static Scheme MVD_782 { get; } = SchemeReader.Read("mvd_782.json");
        public static Scheme UNGEGN_1987 { get; } = SchemeReader.Read("ungegn_1987.json");
    }
}