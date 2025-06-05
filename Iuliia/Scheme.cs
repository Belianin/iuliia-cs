using System;
using System.Collections.Generic;
using System.Linq;

namespace Iuliia
{
    public class Scheme
    {
        internal readonly Dictionary<char, string> LetterMapping; // not IDictionary
        internal readonly ValueTuple<ReadOnlyMemory<char>, string>[] PreviousMapping;
        internal readonly ValueTuple<ReadOnlyMemory<char>, string>[] NextMapping;
        internal readonly ValueTuple<ReadOnlyMemory<char>, string>[] EndingMapping;

        public IReadOnlyCollection<Sample> Samples { get; }
        public string Name { get; }
        
        public Scheme(
            string name,
            Dictionary<char, string> letterMapping,
            IDictionary<string, string> previousMapping,
            IDictionary<string, string> nextMapping,
            IDictionary<string, string> endingMapping,
            IEnumerable<Sample> samples)
        {
            Name = name;
            this.LetterMapping = letterMapping ?? new Dictionary<char, string>();
            Samples = samples != null ? samples.ToArray() : Array.Empty<Sample>();

            PreviousMapping = previousMapping.Select(x => (x.Key.ToString().AsMemory(), x.Value)).ToArray();
            NextMapping = nextMapping.Select(x => (x.Key.ToString().AsMemory(), x.Value)).ToArray();
            EndingMapping = endingMapping.Select(x => (x.Key.ToString().AsMemory(), x.Value)).ToArray();
        }
    }
}