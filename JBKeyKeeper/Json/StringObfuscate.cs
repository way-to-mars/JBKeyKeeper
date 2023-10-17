using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JBKeyKeeper
{
    internal class StringObfuscate
    {
        private static String key = "Zx" + Math.Log(2) / 3;

        public static String obfuscate(String s)
        {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = (char)(s.ElementAt(i) + key.ElementAt(i % key.Length));
            }

            return new String(result);
        }

        public static String unobfuscate(String s)
        {
            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = (char)(s.ElementAt(i) - key.ElementAt(i % key.Length));
            }

            return new String(result);
        }

    }
}
