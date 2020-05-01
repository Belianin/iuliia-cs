using System.Collections.Generic;
using System.Linq;
using Iuliia.Utils;

namespace Iuliia
{
    public static class IuliiaTranslator
    {
        private const int ENDING_LENGTH = 2;

        /// <summary>
        /// Транслитирирует кириллическую строку в латинскую
        /// </summary>
        /// <param name="source">Строка для транслитерации</param>
        /// <param name="scheme">Схема транслитерации</param>
        /// <returns></returns>
        public static string Translate(string source, Scheme scheme)
        {
            return string.Join(" ", source.Split().Select(w => TranslateWord(w, scheme)));
        }

        private static string TranslateWord(string word, Scheme scheme)
        {
            var wordInfo = SplitWord(word);
            if (scheme.TryTranslateEnding(wordInfo.Ending, out var translatedEnding))
                return $"{TranslateLetters(wordInfo.Stem, scheme)}{translatedEnding}";

            return TranslateLetters(word, scheme);
        }

        private static string TranslateLetters(string letters, Scheme scheme)
        {
            return string.Join(string.Empty, ReadLetters(letters).Select(scheme.TranslateLetter));
        }

        private static WordInfo SplitWord(string word)
        {
            if (word.Length <= ENDING_LENGTH)
                return new WordInfo(word, string.Empty);

            return new WordInfo(word[..^ENDING_LENGTH], word[^ENDING_LENGTH..]);
        }

        private static IEnumerable<LetterInfo> ReadLetters(string stem)
        {
            for (int i = 0; i < stem.Length; i++)
            {
                var previous = i > 0 ? stem[i - 1] : (char?) null;
                var next = i + 1 < stem.Length ? stem[i + 1] : (char?) null;
                
                yield return new LetterInfo(previous, stem[i], next);
            }
        }
    }
}