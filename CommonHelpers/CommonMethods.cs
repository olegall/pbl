using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelpers
{
    public static class CommonMethods
    {
        public static string BytesToString(IEnumerable<byte> bytes)
        {
            var hex = new StringBuilder(bytes.Count() * 2);
            foreach (var b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        /// <summary>
        /// Заменяет одну последовательность байт на другую
        /// </summary>
        /// <param name="data"></param>
        /// <param name="searchAndReplacePairs"></param>
        public static void Replace(List<byte> data, Dictionary<byte[], byte[]> searchAndReplacePairs)
        {
            foreach (var searchAndReplace in searchAndReplacePairs)
            {
                for (var i = 0; i < data.Count;)
                {
                    var match = data.Skip(i).Take(searchAndReplace.Key.Length).SequenceEqual(searchAndReplace.Key);
                    if (match)
                    {
                        data.RemoveRange(i, searchAndReplace.Key.Length);
                        data.InsertRange(i, searchAndReplace.Value);
                        i += searchAndReplace.Value.Length;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
    }
}