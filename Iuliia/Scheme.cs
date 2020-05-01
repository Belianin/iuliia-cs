using System.Collections.Generic;

namespace Iuliia
{
    public class Scheme
    {
        private readonly IDictionary<char, string> letterMapping;
        private readonly IDictionary<string, string> previousMapping;
        private readonly IDictionary<string, string> nextMapping;
        private readonly IDictionary<string, string> endingMapping;

        public IReadOnlyCollection<Sample> Samples { get; }
        public string Name { get; }
        
        public Scheme(
            string name,
            IDictionary<char, string> letterMapping,
            IDictionary<string, string> previousMapping,
            IDictionary<string, string> nextMapping,
            IDictionary<string, string> endingMapping,
            IReadOnlyCollection<Sample> samples)
        {
            Name = name;
            this.letterMapping = letterMapping;
            this.previousMapping = previousMapping;
            this.nextMapping = nextMapping;
            this.endingMapping = endingMapping;
            Samples = samples;
        }

        private string TranslateLetter(char? previous, char current, char? next)
        {
            if (previous != null && previousMapping.TryGetValue($"{previous}{current}", out var letter))
                return letter;
            if (next != null && nextMapping.TryGetValue($"{current}{next}", out letter))
                return letter;
            if (letterMapping.TryGetValue(current, out letter))
                return letter;
            return letter;
        }
        
        public string TranslateLetter(LetterInfo letterInfo)
        {
            return TranslateLetter(letterInfo.Previous, letterInfo.Current, letterInfo.Next);
        }

        public bool TryTranslateEnding(string ending, out string translated)
        {
            return endingMapping.TryGetValue(ending, out translated);
        }
    }
}