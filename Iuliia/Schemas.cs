using Iuliia.Dto;

namespace Iuliia
{
    public static class Schemas
    {
        public static Scheme Wikipedia { get; } = SchemeReader.Read(Properties.Resources.WIKIPEDIA);
        public static Scheme Mosmetro { get; } = SchemeReader.Read(Properties.Resources.MOSMETRO);
        public static Scheme YandexMaps { get; } = SchemeReader.Read(Properties.Resources.YANDEX_MAPS);
        public static Scheme YandexMoney { get; } = SchemeReader.Read(Properties.Resources.YANDEX_MONEY);
        /// <summary>
        /// Инструкция Минсвязи о порядке обработки международных телеграмм. Некрасивая, зато без апострофов.
        /// </summary>
        public static Scheme Telegram { get; } = SchemeReader.Read(Properties.Resources.TELEGRAM);
        public static Scheme Scientific { get; } = SchemeReader.Read(Properties.Resources.SCIENTIFIC);
        public static Scheme ALA_LC  { get; } = SchemeReader.Read(Properties.Resources.ALA_LC);
        public static Scheme ALA_LC_ALT { get; } = SchemeReader.Read(Properties.Resources.ALA_LC_ALT);
        public static Scheme BGN_PCGN { get; } = SchemeReader.Read(Properties.Resources.BGN_PCGN);
        public static Scheme BGN_PCGN_ALT { get; } = SchemeReader.Read(Properties.Resources.BGN_PCGN_ALT);
        public static Scheme BS_2979 { get; } = SchemeReader.Read(Properties.Resources.BS_2979);
        public static Scheme BS_2979_ALT { get; } = SchemeReader.Read(Properties.Resources.BS_2979_ALT);
        public static Scheme GOST_16876 { get; } = SchemeReader.Read(Properties.Resources.GOST_16876);
        public static Scheme GOST_16876_ALT { get; } = SchemeReader.Read(Properties.Resources.GOST_16876_ALT);
        public static Scheme GOST_52290 { get; } = SchemeReader.Read(Properties.Resources.GOST_52290);
        public static Scheme GOST_52535 { get; } = SchemeReader.Read(Properties.Resources.GOST_52535);
        public static Scheme GOST_7034 { get; } = SchemeReader.Read(Properties.Resources.GOST_7034);
        public static Scheme GOST_779 { get; } = SchemeReader.Read(Properties.Resources.GOST_779);
        public static Scheme GOST_779_ALT { get; } = SchemeReader.Read(Properties.Resources.GOST_779_ALT);
        public static Scheme ICAO_DOC_9303 { get; } = SchemeReader.Read(Properties.Resources.ICAO_DOC_9309);
        public static Scheme ISO_9_1954 { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1954);
        public static Scheme ISO_9_1968 { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1968);
        public static Scheme ISO_9_1968_ALT { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1968_ALT);
        public static Scheme MVD_310 { get; } = SchemeReader.Read(Properties.Resources.MVD_310);
        public static Scheme MVD_310_FR { get; } = SchemeReader.Read(Properties.Resources.MVD_310_FR);
        public static Scheme MVD_782 { get; } = SchemeReader.Read(Properties.Resources.MVD_782);
        public static Scheme UNGEGN_1987 { get; } = SchemeReader.Read(Properties.Resources.UNGEGN_1987);
    }
}