﻿using JBKeyKeeper.Json;
using System.Collections.Generic;
using System.Linq;

namespace JBKeyKeeper
{
    internal class JBKKContainer
    {
        public string Format { get { return JBKKDefs.FormatTAG; } set { } }
        public JbbkType Type { get { return JbbkType.OPEN; } set { } }      // Format and Type are serialazable constants
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
                Name = pair.Name.FormatSealed(undo: FCFlag),
                Value = pair.Value.FormatSealed(undo: FCFlag)
            };

        private static JBBKItemSealed Seal(this JBBKItem item) =>
            new JBBKItemSealed
            {
                Date = item.Date.FormatSealed(undo: FCFlag),
                Name = item.Name.FormatSealed(undo: FCFlag),
                Fields = item.Fields.Select(pair => pair.Seal()).ToList()
            };

        public static JBKKContainerSealed Seal(this JBKKContainer container) =>
            new JBKKContainerSealed
            {
                Format = container.Format,
                Name = container.Name.FormatSealed(undo: FCFlag),
                History = container.History.Select(item => item.Seal()).ToList()
            };
    }
}

