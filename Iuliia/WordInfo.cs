namespace Iuliia
{
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
}