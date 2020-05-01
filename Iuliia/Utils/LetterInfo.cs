namespace Iuliia
{
    internal class LetterInfo
    {
        public char? Previous { get; } // Rune
        public char Current { get; }
        public char? Next { get; }

        public LetterInfo(char? previous, char current, char? next)
        {
            Previous = previous;
            Current = current;
            Next = next;
        }
    }
}