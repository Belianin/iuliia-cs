using System.Collections.Generic;
using System.Linq;

namespace Iuliia
{
    internal static class IuliiaEngine
    {
        private const int ENDING_LENGTH = 2;

        /// <summary>
        /// todo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="scheme"></param>
        /// <returns></returns>
        public static string Translate(string source, IuliiaScheme scheme)
        {
            return string.Join(" ", source.Split().Select(w => TranslateWord(w, scheme)));
        }

        private static string TranslateWord(string word, IuliiaScheme scheme)
        {
            var wordInfo = SplitWord(word);
            if (scheme.TryTranslateEnding(wordInfo.Ending, out var translatedEnding))
                return $"{TranslateLetters(wordInfo.Stem, scheme)}{translatedEnding}";

            return TranslateLetters(word, scheme);
        }

        private static string TranslateLetters(string letters, IuliiaScheme scheme)
        {
            return string.Join(string.Empty, ReadLetters(letters).Select(scheme.TranslateLetter));
        }

        private static WordInfo SplitWord(string word)
        {
            if (word.Length <= ENDING_LENGTH)
                return new WordInfo(word, string.Empty); // todo without string empty
            
            return new WordInfo(
                word.Substring(0, word.Length - ENDING_LENGTH),
                word.Substring(word.Length - ENDING_LENGTH)); // todo [^2..0]
        }

        private static IEnumerable<LetterInfo> ReadLetters(string stem)
        {
            for (int i = 0; i < stem.Length; i++)
            {
                yield return new LetterInfo(string.Empty, string.Empty, string.Empty);
            }
        }
    }

    internal class WordInfo
    {
        public string Stem { get; }
        public string Ending { get; }

        public WordInfo(string stem, string ending)
        {
            Stem = stem;
            Ending = ending;
        }
    }

    internal class LetterInfo
    {
        public string Previous { get; } // todo string or rune
        public string Current { get; }
        public string Next { get; }

        public LetterInfo(string previous, string current, string next)
        {
            Previous = previous;
            Current = current;
            Next = next;
        }
    }
}