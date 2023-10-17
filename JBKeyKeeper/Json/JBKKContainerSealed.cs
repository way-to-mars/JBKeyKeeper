using System.Collections.Generic;
using System.Linq;

namespace JBKeyKeeper
{
    internal class JBKKContainerSealed
    {
        public const string TAG = "JsonBasedKeyKeeper";
        public string Format { get; set; }
        public string Name { get; set; }
        public IList<JBBKItemSealed> History { get; set; }
    }

    internal class JBBKItemSealed
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public IList<JBBKPairSealed> Fields { get; set; }
    }

    internal class JBBKPairSealed
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    internal static class JBKKContainerSealedExtensions
    {
        private const bool FCFlag = true;

        private static JBBKPair Unseal(this JBBKPairSealed sealedPair) =>
            new JBBKPair
            {
                Name = sealedPair.Name.FormatCringe(undo: FCFlag),
                Value = sealedPair.Value.FormatCringe(undo: FCFlag)
            };

        private static JBBKItem Unseal(this JBBKItemSealed sealedItem) =>
            new JBBKItem
            {
                Date = sealedItem.Date.FormatCringe(undo: FCFlag),
                Name = sealedItem.Name.FormatCringe(undo: FCFlag),
                Fields = sealedItem.Fields.Select(pair => pair.Unseal()).ToList()
            };

        public static JBKKContainer Unseal(this JBKKContainerSealed sealedContainer) =>
            new JBKKContainer
            {
                Format = sealedContainer.Format,
                Name = sealedContainer.Name.FormatCringe(undo: FCFlag),
                History = sealedContainer.History.Select(item => item.Unseal()).ToList()
            };
    }
}

