using System;
using System.Collections.Generic;
using System.Linq;
using Iuliia.Utils;

namespace Iuliia
{
    public class Scheme
    {
        private readonly Dictionary<char, string> letterMapping;
        private readonly Dictionary<string, string> previousMapping;
        private readonly Dictionary<string, string> nextMapping;
        private readonly Dictionary<string, string> endingMapping;

        public IReadOnlyCollection<Sample> Samples { get; }
        public string Name { get; }
        
        public Scheme(
            string name,
            IDictionary<char, string> letterMapping,
            IDictionary<string, string> previousMapping,
            IDictionary<string, string> nextMapping,
            IDictionary<string, string> endingMapping,
            IEnumerable<Sample> samples)
        {
            Name = name;
            this.letterMapping = GetMapping(letterMapping);
            this.previousMapping = GetPreviousMapping(previousMapping);
            this.nextMapping = GetNextMapping(nextMapping);
            this.endingMapping = GetEndingMapping(endingMapping);
            Samples = samples?.ToArray() ?? Array.Empty<Sample>();
        }

        private static Dictionary<char, string> GetMapping(IDictionary<char, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<char, string>();

            var result = new Dictionary<char, string>(mapping);

            // do not use deconstruct (key, value) syntax for compatibility with netstandard2.0
            foreach (var pair in mapping)
                result[char.ToUpper(pair.Key)] = pair.Value.Capitalize();

            return result;
        }

        private static Dictionary<string, string> GetPreviousMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();

            var result = new Dictionary<string, string>(mapping);

            foreach (var pair in mapping)
            {
                result[pair.Key.Capitalize()] = pair.Value;
                result[pair.Key.ToUpper()] = pair.Value.Capitalize();
            }

            return result;
        }

        private static Dictionary<string, string> GetNextMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();

            var result = new Dictionary<string, string>(mapping);

            foreach (var pair in mapping)
            {
                result[pair.Key.Capitalize()] = pair.Value.Capitalize();
                result[pair.Key.ToUpper()] = pair.Value.Capitalize();
            }

            return result;
        }

        private static Dictionary<string, string> GetEndingMapping(IDictionary<string, string> mapping)
        {
            if (mapping == null)
                return new Dictionary<string, string>();

            var result = new Dictionary<string, string>(mapping);

            foreach (var pair in mapping)
                result[pair.Key.ToUpper()] = pair.Value.ToUpper();

            return result;
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
        
        internal string TranslateLetter(LetterInfo letterInfo) => 
            TranslateLetter(letterInfo.Previous, letterInfo.Current, letterInfo.Next);

        internal bool TryTranslateEnding(string ending, out string translated)
        {
            return endingMapping.TryGetValue(ending, out translated);
        }
    }
}