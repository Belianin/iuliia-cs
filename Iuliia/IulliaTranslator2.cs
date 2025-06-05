using System;
using System.Text;

namespace Iuliia;

public class IuliiaTranslator2
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
        var stringBuilder = new StringBuilder();

        var wordStart = 0;
        for (var i = 0; i < sourceSpan.Length; i++)
        {
            var c = sourceSpan[i];
            if (c == ' ')
            {
                if (wordStart - i != 0)
                {
                    TranslateWord(wordStart, i - 1, sourceSpan);
                    stringBuilder.Append(' ');
                }

                wordStart = i + 1;
                // i += 2;
            }
        }
        if (wordStart - sourceSpan.Length != 0)
        {
            TranslateWord(wordStart, sourceSpan.Length - 1, sourceSpan);
        }
        
        return stringBuilder.ToString();
        
        void TranslateWord(int start, int end, ReadOnlySpan<char> word)
        {
            if (end - start <= ENDING_LENGTH)
                TranslateLetters(start, end, word);
            else
            {
                if (scheme.TryTranslateEnding2(word.Slice(end - 1, 2), out var ending))
                {
                    TranslateLetters(start, end - 2, word);
                    stringBuilder.Append(ending);
                }
                else
                {
                    TranslateLetters(start, end, word);
                }
            }
        }

        void TranslateLetters(int start, int end, ReadOnlySpan<char> word)
        {
            // stringBuilder.Append(scheme.TranslateLetter(word.Slice(start, start + 3)); todo
            if (start - end == 2)
            {
                // todo   
            }

            // stringBuilder.Append(scheme.TranslateLetter2(word.Slice(start, 2)));
            for (var i = start; i <= end; i++) 
            {
                stringBuilder.Append(scheme.TranslateLetter(
                    i > start ? word[i-1] : null,
                    word[i],
                    i < end ? word[i + 1] : null));
                // stringBuilder.Append(scheme.TranslateLetter(
                //     i > start ? word[i-1] : null,
                //     word[i],
                //     i < end ? word[i + 1] : null));
                // if (i > start)
                // {
                //     if (i + 1 <= end)
                //         stringBuilder.Append(scheme.TranslateLetter2(word.Slice(i - 1, 3)));
                //     else
                //         stringBuilder.Append(scheme.TranslateLetterNoNext(word.Slice(i - 1, 2)));
                // }
                // else
                // {
                //     if (i + 1 <= end)
                //         stringBuilder.Append(scheme.TranslateLetter2(word.Slice(i, 2)));
                //     else
                //         stringBuilder.Append(scheme.TranslateLetter2(word.Slice(i, 1))); // todo
                // }
            }
            // stringBuilder.Append(scheme.TranslateLetter2(word.Slice(end - 1, 2)));
        }
    }
}