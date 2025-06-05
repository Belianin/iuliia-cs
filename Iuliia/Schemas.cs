using System.Diagnostics.CodeAnalysis;
using Iuliia.Dto;

namespace Iuliia
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Schemas
    {
        /// <summary>
        /// Схема транслитерации, которую использует Википедия. Сделана на основе BGN/PCGN со значительными модификациями.
        /// Самая продуманная, звучит лучше всех и выглядит приятнее большинства прочих схем.
        /// </summary>
        public static Scheme Wikipedia { get; } = SchemeReader.Read(Properties.Resources.WIKIPEDIA);
        
        /// <summary>
        /// Схема транслитерации, которую использует Московский метрополитен.
        /// Визуально самая приятная из всех, хотя уступает Википедии по фонетической точности.
        /// Придумана в Студии Лебедева, официально нигде не описана.
        /// </summary>
        public static Scheme Mosmetro { get; } = SchemeReader.Read(Properties.Resources.MOSMETRO);
        
        /// <summary>
        /// Правила Яндекса для адресов. Слегка улучшенная версия Яндекс.Денег.
        /// </summary>
        public static Scheme YandexMaps { get; } = SchemeReader.Read(Properties.Resources.YANDEX_MAPS);
        
        /// <summary>
        /// Правила Яндекса для банковских карт. Простая и удобная схема.
        /// </summary>
        public static Scheme YandexMoney { get; } = SchemeReader.Read(Properties.Resources.YANDEX_MONEY);
        
        /// <summary>
        /// Инструкция Минсвязи о порядке обработки международных телеграмм. Некрасивая, зато без апострофов.
        /// </summary>
        public static Scheme Telegram { get; } = SchemeReader.Read(Properties.Resources.TELEGRAM);
        
        /// <summary>
        /// Великая праматерь всех схем. Используется в научных работах. Из неё вырос ГОСТ 16876-71.
        /// Достойна уважения за вклад в историю, но страшная.
        /// </summary>
        public static Scheme Scientific { get; } = SchemeReader.Read(Properties.Resources.SCIENTIFIC);
        
        /// <summary>
        /// Схема транслитерации американской Библиотеки Конгресса. Страшноватая. Есть варианты с диакритикой и без.
        /// </summary>
        public static Scheme ALA_LC  { get; } = SchemeReader.Read(Properties.Resources.ALA_LC);
        public static Scheme ALA_LC_ALT { get; } = SchemeReader.Read(Properties.Resources.ALA_LC_ALT);
        
        /// <summary>
        /// Древняя схема транслитерации ООН для географических названий. Почти без диакритики, но зачем-то оставила Ё с точками.
        /// </summary>
        public static Scheme BGN_PCGN { get; } = SchemeReader.Read(Properties.Resources.BGN_PCGN);
        public static Scheme BGN_PCGN_ALT { get; } = SchemeReader.Read(Properties.Resources.BGN_PCGN_ALT);
        
        /// <summary>
        /// Схема транслитерации Британской библиотеки. Используется издательством Oxford University Press.
        /// Изящно схлопывает окончания ИЙ и ЫЙ, в остальном так себе.
        /// </summary>
        public static Scheme BS_2979 { get; } = SchemeReader.Read(Properties.Resources.BS_2979);
        
        public static Scheme BS_2979_ALT { get; } = SchemeReader.Read(Properties.Resources.BS_2979_ALT);
        public static Scheme GOST_16876 { get; } = SchemeReader.Read(Properties.Resources.GOST_16876);
        public static Scheme GOST_16876_ALT { get; } = SchemeReader.Read(Properties.Resources.GOST_16876_ALT);
        
        /// <summary>
        /// Стандарт для транслитерации имён собственных на дорожных знаках.
        /// Неплохая, с одинарными апострофами. Много внимания написанию Е и Ё.
        /// </summary>
        public static Scheme GOST_52290 { get; } = SchemeReader.Read(Properties.Resources.GOST_52290);
        public static Scheme GOST_52535 { get; } = SchemeReader.Read(Properties.Resources.GOST_52535);
        
        /// <summary>
        /// Правила упрощенной транслитерации русского письма латинским алфавитом.
        /// Для библиотек и издательств. В меру приятная.
        /// Расслабленная: есть альтернативы для многих букв, можно без апострофов.
        /// </summary>
        public static Scheme GOST_7034 { get; } = SchemeReader.Read(Properties.Resources.GOST_7034);
        
        /// <summary>
        /// Универсальная схема транслитерации, международный стандарт ISO 9:1995.
        /// Громоздкая, зато обратимая. Вариант с диакритикой.
        /// </summary>
        public static Scheme GOST_779 { get; } = SchemeReader.Read(Properties.Resources.GOST_779);
        
        /// <summary>
        /// Универсальная схема транслитерации, международный стандарт ISO 9:1995.
        /// Громоздкая, зато обратимая. Вариант без диакритики.
        /// </summary>
        public static Scheme GOST_779_ALT { get; } = SchemeReader.Read(Properties.Resources.GOST_779_ALT);
        
        /// <summary>
        /// Стандарт Международной организации гражданской авиации.
        /// Используется МВД для ФИО в водительских удостоверениях, а МИД — в загранпаспортах.
        /// Подходит для гринкарты и вида на жительство. Используется некоторыми платёжными системами.
        /// </summary>
        public static Scheme ICAO_DOC_9303 { get; } = SchemeReader.Read(Properties.Resources.ICAO_DOC_9309);
        public static Scheme ISO_9_1954 { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1954);
        public static Scheme ISO_9_1968 { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1968);
        public static Scheme ISO_9_1968_ALT { get; } = SchemeReader.Read(Properties.Resources.ISO_9_1968_ALT);
        public static Scheme MVD_310 { get; } = SchemeReader.Read(Properties.Resources.MVD_310);
        public static Scheme MVD_310_FR { get; } = SchemeReader.Read(Properties.Resources.MVD_310_FR);
        public static Scheme MVD_782 { get; } = SchemeReader.Read(Properties.Resources.MVD_782);
        
        /// <summary>
        /// Схема транслитерации ООН для географических названий. Основана на ГОСТ 16876-71.
        /// Такая же страшная, но до сих пор не отменена.
        /// </summary>
        public static Scheme UNGEGN_1987 { get; } = SchemeReader.Read(Properties.Resources.UNGEGN_1987);
    }
}