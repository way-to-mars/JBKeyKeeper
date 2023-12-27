using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace JBKeyKeeper
{
    public class JBKKContainer2
    {
        public IList<JBBKItem2> Items { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            });
    }

    public class JBBKItem2
    {
        public string Name { get; set; }
        public IList<JBBKSubItem2> SubItems { get; set; }
    }

    public class JBBKSubItem2
    {
        public string Name { get; set; }
        public IList<JBBKPair2> Pairs { get; set; }
    }

    public class JBBKPair2
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class JBKKContainerExtensions2
    {
        public static JBKKContainer2 Sealed(this JBKKContainer2 container) =>
            container.Seal(undo: false);
        public static JBKKContainer2 UnSealed(this JBKKContainer2 container) =>
            container.Seal(undo: true);
        private static JBKKContainer2 Seal(this JBKKContainer2 container, bool undo)
        {
            int index = 0;
            return new JBKKContainer2{
                Items = container.Items
                        .Select(item =>
                            new JBBKItem2
                            {
                                Name = item.Name.FormatSealed(undo, ++index),
                                SubItems = item.SubItems
                                    .Select(subItem =>
                                        new JBBKSubItem2
                                        {
                                            Name = subItem.Name.FormatSealed(undo, ++index),
                                            Pairs = subItem.Pairs
                                                .Select(pair =>
                                                    new JBBKPair2
                                                    {
                                                        Name = pair.Name.FormatSealed(undo,++index),
                                                        Value = pair.Value.FormatSealed(undo, ++index)
                                                    }
                                                )
                                                .ToList()
                                        }
                                        )
                                    .ToList()
                            }
                        )
                        .ToList()
                };
        }

        public static string Serialize(this JBKKContainer2 container, out bool completed)
        {
            completed = true;
            try
            {
                return JsonSerializer.Serialize(container.Sealed(),
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    });
            }
            catch
            {
                completed = false;
                return "";
            }
        }

        public static JBKKContainer2 Deserialize(this string source, out bool completed)
        {
            completed = true;
            try
            {
                return JsonSerializer.Deserialize<JBKKContainer2>(source).UnSealed();
            }
            catch
            {
                completed = false;
                return new JBKKContainer2 { };
            }
        }
    }
}
