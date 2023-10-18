using JBKeyKeeper.Json;
using System.Collections.Generic;
using System.Linq;

namespace JBKeyKeeper
{
    internal class JBKKContainerSealed
    {
        public string Format { get => JBKKDefs.FormatTAG; set { } }
        public JbbkType Type { get => JbbkType.SEALED; set { } }
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
                Name = sealedPair.Name.FormatSealed(undo: FCFlag),
                Value = sealedPair.Value.FormatSealed(undo: FCFlag)
            };

        private static JBBKItem Unseal(this JBBKItemSealed sealedItem) =>
            new JBBKItem
            {
                Date = sealedItem.Date.FormatSealed(undo: FCFlag),
                Name = sealedItem.Name.FormatSealed(undo: FCFlag),
                Fields = sealedItem.Fields.Select(pair => pair.Unseal()).ToList()
            };

        public static JBKKContainer Unseal(this JBKKContainerSealed sealedContainer) =>
            new JBKKContainer
            {
                Format = sealedContainer.Format,
                Name = sealedContainer.Name.FormatSealed(undo: FCFlag),
                History = sealedContainer.History.Select(item => item.Unseal()).ToList()
            };
    }
}

