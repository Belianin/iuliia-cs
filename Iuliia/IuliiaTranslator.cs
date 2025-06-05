using System;
using System.Collections.Generic;
using System.Linq;

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
            var sourceSpan = source.AsSpan();
            var stringBuilder = new ValueStringBuilder(source.Length); // частоты букв

            var wordStart = 0;
            for (var i = 0; i < sourceSpan.Length; i++)
            {
                var c = sourceSpan[i];
                if (!char.IsLetter(c))
                {
                    if (wordStart - i != 0)
                        TranslateWord(wordStart, i - 1, sourceSpan, scheme, ref stringBuilder);

                    stringBuilder.Append(c);
                    wordStart = i + 1;
                }
            }

            if (wordStart - sourceSpan.Length != 0)
                TranslateWord(wordStart, sourceSpan.Length - 1, sourceSpan, scheme, ref stringBuilder);

            return stringBuilder.ToString();
        }

        private static void TranslateWord(int start, int end, ReadOnlySpan<char> word, Scheme scheme,
            ref ValueStringBuilder stringBuilder)
        {
            if (end - start <= ENDING_LENGTH)
                TranslateLetters(start, end, word, scheme, ref stringBuilder);
            else
            {
                if (TryTranslateEnding(scheme, word.Slice(end - 1, 2), out var ending))
                {
                    TranslateLetters(start, end - 2, word, scheme, ref stringBuilder);
                    stringBuilder.Append(ending);
                }
                else
                    TranslateLetters(start, end, word, scheme, ref stringBuilder);
            }
        }

        private static void TranslateLetters(int start, int end, ReadOnlySpan<char> word, Scheme scheme,
            ref ValueStringBuilder stringBuilder)
        {
            if (start - end == 0)
            {
                stringBuilder.Append(TranslateLetter(scheme, word.Slice(start, 1), word[start],
                    word.Slice(start, 1)));
                return;
            }

            stringBuilder.Append(
                TranslateLetter(
                    scheme,
                    word.Slice(start, 1),
                    word[start],
                    word.Slice(start, 2)));
            
            for (var i = start + 1; i <= end - 1; i++)
            {
                stringBuilder.Append(
                    TranslateLetter(
                        scheme, 
                        word.Slice(i - 1, 2),
                        word[i],
                        word.Slice(i, 2)));
            }

            stringBuilder.Append(
                TranslateLetter(
                    scheme,
                    word.Slice(end - 1, 2),
                    word[end], 
                    word.Slice(end, 1)));
        }
        
        private static string TranslateLetter(Scheme scheme, ReadOnlySpan<char> prev, char current, ReadOnlySpan<char> next)
        {
            foreach (var kvp in scheme.PreviousMapping)
            {
                if (prev.SequenceEqual(kvp.Item1.Span))
                    return kvp.Item2;
            }
            foreach (var kvp in scheme.NextMapping)
            {
                if (next.SequenceEqual(kvp.Item1.Span))
                    return kvp.Item2;
            }

            return scheme.LetterMapping.TryGetValue(current, out var letter) ? letter : current.ToString();
        }

        
        private static bool TryTranslateEnding(Scheme scheme, ReadOnlySpan<char> ending, out string translated)
        {
            foreach (var kvp in scheme.EndingMapping)
            {
                if (kvp.Item1.Span.SequenceEqual(ending)) // todo
                {
                    translated = kvp.Item2;
                    return true;
                }
            }

            translated = null;
            return false;
        }
    }
}