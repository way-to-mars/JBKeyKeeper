using System.Collections.Generic;


namespace JBKeyKeeper
{
    internal class JBKKContainer
    {
        public const string TAG = "JsonBasedKeyKeeper";
        public string Format { get; set; }
        public string Name { get; set; }
        public IList<JBBKItem> History { get; set; }
    }

    internal class JBBKItem
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public IList<JBBKPair> Fields { get; set; }
    }

    internal class JBBKPair { 
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
