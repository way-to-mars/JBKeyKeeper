using System.Collections.Generic;
using System.Linq;

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

    internal class JBBKPair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal static class JBKKContainerExtensions
    {
        private const bool FCFlag = false;

        private static JBBKPairSealed Seal(this JBBKPair pair) =>
            new JBBKPairSealed
            {
                Name = pair.Name.FormatCringe(undo: FCFlag),
                Value = pair.Value.FormatCringe(undo: FCFlag)
            };

        private static JBBKItemSealed Seal(this JBBKItem item) =>
            new JBBKItemSealed
            {
                Date = item.Date.FormatCringe(undo: FCFlag),
                Name = item.Name.FormatCringe(undo: FCFlag),
                Fields = item.Fields.Select(pair => pair.Seal()).ToList()
            };

        public static JBKKContainerSealed Seal(this JBKKContainer container) =>
            new JBKKContainerSealed
            {
                Format = container.Format,
                Name = container.Name.FormatCringe(undo: FCFlag),
                History = container.History.Select(item => item.Seal()).ToList()
            };
    }
}

