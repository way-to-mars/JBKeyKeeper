using JBKeyKeeper.Json;
using System.Collections.Generic;
using System.Linq;

namespace JBKeyKeeper
{
    public class JBKKContainerSealed
    {
        public string Format { get => JBKKDefs.FormatTAG.FormatSealed(); set { } }
        public JbbkType Type { get => JbbkType.SEALED; set { } }
        public string Name { get; set; }
        public IList<JBBKItemSealed> Items { get; set; }
    }

    public class JBBKItemSealed
    {
   //     public string Date { get; set; }
        public string Name { get; set; }
        public IList<JBBKPairSealed> Fields { get; set; }
    }

    public class JBBKPairSealed
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class JBKKContainerSealedExtensions
    {
        private const bool FCFlag = true;  // invariant

        private static JBBKPair Unseal(this JBBKPairSealed sealedPair) =>
            new JBBKPair
            {
                Name = sealedPair.Name.FormatSealed(undo: FCFlag),
                Value = sealedPair.Value.FormatSealed(undo: FCFlag)
            };

        private static JBBKItem Unseal(this JBBKItemSealed sealedItem) =>
            new JBBKItem
            {
    //            Date = sealedItem.Date.FormatSealed(undo: FCFlag),
                Name = sealedItem.Name.FormatSealed(undo: FCFlag),
                Fields = sealedItem.Fields.Select(pair => pair.Unseal()).ToList()
            };

        public static JBKKContainer Unseal(this JBKKContainerSealed sealedContainer) =>
            new JBKKContainer
            {
                // Format = sealedContainer.Format,
                Name = sealedContainer.Name.FormatSealed(undo: FCFlag),
                Items = sealedContainer.Items.Select(item => item.Unseal()).ToList()
            };
    }
}

