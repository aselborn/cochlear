using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cochlear
{
    static class Numbers
    {
        public static string textString = "asd123qwe457rty89234";
        public static string textString2 = "567zx01245cvbnm";

        static Dictionary<string, int> result = new Dictionary<string, int>();

        internal static void parseTextFile(string pathToFile)
        {
            String[] FileContent = File.ReadAllLines(pathToFile);
            List<String> content = FileContent.ToList();
            PrintMap(content);
        }

        public static void DoNumbers()
        {

            List<String> content = new List<string>();

            content.Add(textString);
            content.Add(textString2);

            PrintMap(content);
           
        }

        private static void PrintMap(List<string> inputs)
        {
            List<string> my = new List<string>();
            StringBuilder bu = new StringBuilder();
            Regex rgx = new Regex("[^Z0-9.]");

            int start = 0;

            List<String> inpStrings = new List<string>();
            foreach(string input in inputs)
            {
                string filtered = rgx.Replace(input, "|").Replace(".", "");
                inpStrings = filtered.Split(new char[] { '|' }).ToList();

                foreach (String inp in inpStrings)
                {
                    if (inp.Length > 0)
                    {
                        int cnt = 0;
                        while (cnt < inp.Length - 1)
                        {
                            if (cnt == 0)
                            {
                                start = Int32.Parse(inp.Substring(0, 1));
                                bu.Append(start);
                            }

                            int next = Int32.Parse(inp.Substring(cnt + 1, 1));

                            if (next - start == 1)
                            {
                                bu.Append(next);
                                start = next;
                            } else
                            {
                                int p = inp.IndexOf(next.ToString());
                                if ( (inp.Length - p) != 1)
                                {
                                    start = Int32.Parse(inp.Substring(p, 1));
                                    
                                    my.Add(bu.ToString());
                                    bu.Length = 0;
                                    bu.Append(start);
                                }

                            }
                            cnt++;
                        }

                        my.Add(bu.ToString());
                        bu.Length = 0;
                    }
                }

            }

            my = my.Where(p => !string.IsNullOrWhiteSpace(p)).ToList();

            List<int> resultInts = my.ConvertAll(p => Int32.Parse(p));
            resultInts.Sort((a, b) => -1 * a.CompareTo(b));

            var noGroups = resultInts.GroupBy(i => i).OrderByDescending(g => g.Count());
            foreach (var grp in noGroups)
            {
                var number = grp.Key;
                var total = grp.Count();

                Console.WriteLine("{0}, {1}", number.ToString(), total.ToString());

            }

           
        }




    }
}
