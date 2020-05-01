using System.Collections.Generic;
using Iuliia.Utils;

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
            this.letterMapping = letterMapping ?? new Dictionary<char, string>();
            this.previousMapping = previousMapping ?? new Dictionary<string, string>();
            this.nextMapping = nextMapping ?? new Dictionary<string, string>();
            this.endingMapping = endingMapping ?? new Dictionary<string, string>();
            Samples = samples ?? new Sample[0];
        }

        private string TranslateLetter(char? previous, char current, char? next)
        {
            var previousKey = previous == null ? current.ToString() : $"{previous}{current}";
            if (previousMapping.TryGetValue(previousKey, out var letter))
                return letter;
            
            var nextKey = next == null ? current.ToString() : $"{current}{next}";
            if (nextMapping.TryGetValue(nextKey, out letter))
                return letter;
            
            return letterMapping.TryGetValue(current, out letter) ? letter : current.ToString();
        }
        
        internal string TranslateLetter(LetterInfo letterInfo)
        {
            return TranslateLetter(letterInfo.Previous, letterInfo.Current, letterInfo.Next);
        }

        internal bool TryTranslateEnding(string ending, out string translated)
        {
            return endingMapping.TryGetValue(ending, out translated);
        }
    }
}