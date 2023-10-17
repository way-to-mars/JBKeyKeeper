using System;
using System.Collections.Generic;
using System.Linq;

namespace JBKeyKeeper
{
    public static class StringExtensions
    {
        private const int key = 17 * 31;
        public static string FormatCringe(this string inputString, bool undo = false)
        {
            if (undo)
            {
                string knownLengthString = inputString.UnRenameHex();
                int unkey = key * (knownLengthString.Length / 4);
                return knownLengthString.DeShuffle(unkey).FromUTFCodeString();
            }

            return inputString.ToUTFCodeString().Shuffle(key * inputString.Length).RenameHex();
        }

        private static int[] GetShuffleExchanges(int size, int key)
        {
            int[] exchanges = new int[size - 1];
            var rand = new Random(key);
            for (int i = size - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                exchanges[size - 1 - i] = n;
            }
            return exchanges;
        }

        private static string Shuffle(this string toShuffle, int key)
        {
            int size = toShuffle.Length;
            char[] chars = toShuffle.ToArray();
            var exchanges = GetShuffleExchanges(size, key);
            for (int i = size - 1; i > 0; i--)
            {
                int n = exchanges[size - 1 - i];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }
            return new string(chars);
        }

        private static string DeShuffle(this string shuffled, int key)
        {
            int size = shuffled.Length;
            char[] chars = shuffled.ToArray();
            var exchanges = GetShuffleExchanges(size, key);
            for (int i = 1; i < size; i++)
            {
                int n = exchanges[size - i - 1];
                char tmp = chars[i];
                chars[i] = chars[n];
                chars[n] = tmp;
            }
            return new string(chars);
        }

        private static string ToUTFCodeString(this string str)
        {
            List<string> output = new List<string>();
            for (var i = 0; i < str.Length; i++)
                output.Add(string.Format("{0:X4}", (ushort)str[i]));
            return string.Concat(output);
        }

        private static string FromUTFCodeString(this string str)
        {
            List<char> output = new List<char>();
            for (var i = 0; i < str.Length; i += 4)
                output.Add((char)Convert.ToUInt16(str.Substring(i, 4), 16));
            return string.Concat(output);
        }

        private static string RenameHex(this string hexString)
        {
            return hexString.Replace("04", "Q").Replace("44", "W").Replace("000", "X").Replace("00", "Y").Replace("0", "Z");
        }

        private static string UnRenameHex(this string hexString)
        {
            return hexString.Replace("Z", "0").Replace("Y", "00").Replace("X", "000").Replace("W", "44").Replace("Q", "04");
        }
    }
}
