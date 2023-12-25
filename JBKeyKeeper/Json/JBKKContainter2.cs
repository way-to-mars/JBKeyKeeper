using System.Collections.Generic;
using System.Text;

namespace JBKeyKeeper
{
    public class JBKKContainer2
    {
        public IList<JBBKItem2> Items { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("JBKKContainer Items: [\n");
            foreach (JBBKItem2 item in Items)
                sb.Append(item);
            sb.Append("]\n");
            return sb.ToString();
        }
    }

    public class JBBKItem2
    {
        public string Name { get; set; }
        public IList<JBBKSubItem2> Items { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"\t{Name}\n");
            foreach (JBBKSubItem2 item in Items)
                sb.Append(item);
            return sb.ToString();
        }
    }

    public class JBBKSubItem2
    {
        public string Name { get; set; }
        public IList<JBBKPair2> Fields { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"\t\t{Name}\n");
            foreach (JBBKPair2 item in Fields)
                sb.Append($"\t\t\tName: {item.Name}" +
                          $"\tValue: {item.Value}\n");
            return sb.ToString();
        }
    }

    public class JBBKPair2
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
