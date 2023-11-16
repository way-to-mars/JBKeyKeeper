using JBKeyKeeper.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBKeyKeeper
{
    public class JBKKContainer
    {
        // public string Format { get => JBKKDefs.FormatTAG; set { } }
        // public JbbkType Type { get => JbbkType.OPEN; set { } }      // Format and Type are serialazable constants
        public string Name { get; set; }
        public IList<JBBKItem> Items { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"JBKKContainer:\nName = {Name}\nItems: [\n");
            foreach ( JBBKItem item in Items )
            {
                sb.Append( item.ToString() );
            }
            sb.Append("]\n");
            return sb.ToString();
        }
    }

    public class JBBKItem
    {
      //  public string Date { get; set; }
        public string Name { get; set; }
        public IList<JBBKPair> Fields { get; set; }            
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"  {{\n    Name: {Name}\n    Fields: [\n");
            foreach (JBBKPair pair in Fields)
                sb.Append($"      {{\n        Name: {pair.Name}\n        Value: {pair.Value}\n      }}\n");
            sb.Append("    ]\n  }}\n");
            return sb.ToString();
        }
    }

    public class JBBKPair
    {
        public string Name { get; set; }
        public string Value { get; set; }

        
    }

    public static class JBKKContainerExtensions
    {
        private const bool FCFlag = false;  // invariant

        private static JBBKPairSealed Seal(this JBBKPair pair) =>
            new JBBKPairSealed
            {
                Name = pair.Name.FormatSealed(undo: FCFlag),
                Value = pair.Value.FormatSealed(undo: FCFlag)
            };

        private static JBBKItemSealed Seal(this JBBKItem item) =>
            new JBBKItemSealed
            {
               // Date = item.Date.FormatSealed(undo: FCFlag),
                Name = item.Name.FormatSealed(undo: FCFlag),
                Fields = item.Fields.Select(pair => pair.Seal()).ToList()
            };

        public static JBKKContainerSealed Seal(this JBKKContainer container) =>
            new JBKKContainerSealed
            {
               // Format = container.Format,
                Name = container.Name.FormatSealed(undo: FCFlag),
                Items = container.Items.Select(item => item.Seal()).ToList()
            };
    }
}

