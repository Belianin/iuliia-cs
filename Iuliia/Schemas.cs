namespace Iuliia
{
    public static class Schemas
    {
        public static Scheme Wikipedia { get; } = SchemeReader.Read("wikipedia.json");
        public static Scheme Mosmetro { get; } = SchemeReader.Read("mosmetro.json");
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
            YandexMaps = SchemeReader.Read("yandex_maps.json");
            YandexMoney = SchemeReader.Read("yandex_money.json");
            Telegram = SchemeReader.Read("telegram.json");
            Scientific = SchemeReader.Read("scientific.json");
            ALA_LC = SchemeReader.Read("ala_lc.json");
            ALA_LC_ALT = SchemeReader.Read("ala_lc_alt.json");
            BGN_PCGN = SchemeReader.Read("bgn_pcgn.json");
            BGN_PCGN_ALT = SchemeReader.Read("bgn_pcgn_alt.json");
            BS_2979 = SchemeReader.Read("bs_2979.json");
            BS_2979_ALT = SchemeReader.Read("bs_2979_alt.json");
            GOST_16876 = SchemeReader.Read("gost_16876.json");
            GOST_16876_ALT = SchemeReader.Read("gost_16876_alt.json");
            GOST_52290 = SchemeReader.Read("gost_52290.json");
            GOST_52535 = SchemeReader.Read("gost_52535.json");
            GOST_7034 = SchemeReader.Read("gost_7034.json");
            GOST_779 = SchemeReader.Read("gost_779.json");
            GOST_779_ALT = SchemeReader.Read("gost_779_alt.json");
            ICAO_DOC_9303 = SchemeReader.Read("icao_doc_9303.json");
            ISO_9_1954 = SchemeReader.Read("iso_9_1954.json");
            ISO_9_1968 = SchemeReader.Read("iso_9_1968.json");
            ISO_9_1968_ALT = SchemeReader.Read("iso_9_1968_alt.json");
            MVD_310 = SchemeReader.Read("mvd_310.json");
            MVD_310_FR = SchemeReader.Read("mvd_310_fr.json");
            MVD_782 = SchemeReader.Read("mvd_782.json");
            UNGEGN_1987 = SchemeReader.Read("ungegn_1987.json");
        }
    }
}