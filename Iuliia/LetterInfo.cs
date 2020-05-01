namespace Iuliia
{
    public class LetterInfo
    {
        public char? Previous { get; } // todo string or rune
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