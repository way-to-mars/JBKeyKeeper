using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Net.WebRequestMethods;

namespace JBKeyKeeper
{
    public class JBKKContainer2
    {
        public IList<JBKKItem2> Items { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            });
    }

    public class JBKKItem2
    {
        public string Name { get; set; }
        public IList<JBKKSubItem2> SubItems { get; set; }
    }

    public class JBKKSubItem2
    {
        public string Name { get; set; }
        // optional
        public string Uri { get; set; }
        public IList<JBKKPair2> Pairs { get; set; }

        public static JBKKSubItem2 Build(string name, List<JBKKPair2> pairs)
        {
            return new JBKKSubItem2() { Name = name, Uri = "", Pairs = pairs };            
        }

        public static JBKKSubItem2 Build(string name, string uri, List<JBKKPair2> pairs)
        {
            return new JBKKSubItem2() { Name = name, Uri = uri, Pairs = pairs };
        }

    }

    public class JBKKPair2
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class JBKKContainerExtensions2
    {
        public static JBKKContainer2 Sealed(this JBKKContainer2 container) => container.Seal(undo: false);

        public static JBKKContainer2 UnSealed(this JBKKContainer2 container) => container.Seal(undo: true);

        private static JBKKContainer2 Seal(this JBKKContainer2 container, bool undo)
        {
            int index = 0;
            return new JBKKContainer2
            {
                Items = container.Items
                        .Select(item =>
                            new JBKKItem2
                            {
                                Name = item.Name.FormatSealed(undo, ++index),
                                SubItems = item.SubItems
                                    .Select(subItem =>
                                        new JBKKSubItem2
                                        {
                                            Name = subItem.Name.FormatSealed(undo, ++index),
                                            Uri = subItem.Uri.FormatSealed(undo, ++index),
                                            Pairs = subItem.Pairs
                                                .Select(pair =>
                                                    new JBKKPair2
                                                    {
                                                        Name = pair.Name.FormatSealed(undo, ++index),
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

        public static JBKKContainer2 AsCopy(this JBKKContainer2 container)
        {
            JBKKContainer2 aCopy = new() { Items = new List<JBKKItem2>() };
            foreach (var originItem in container.Items)
            {
                JBKKItem2 copyItem = new() { Name = originItem.Name, SubItems = new List<JBKKSubItem2>() };
                foreach (var originSubItem in originItem.SubItems)
                {
                    JBKKSubItem2 copySubItem = new() { Name = originSubItem.Name, Uri = originSubItem.Uri, Pairs = new List<JBKKPair2>() };
                    foreach (var originPair in originSubItem.Pairs)
                        copySubItem.Pairs.Add(new JBKKPair2 { Name = originPair.Name, Value = originPair.Value });
                    copyItem.SubItems.Add(copySubItem);
                }
                aCopy.Items.Add(copyItem);
            }
            return aCopy;
        }
    }
}
