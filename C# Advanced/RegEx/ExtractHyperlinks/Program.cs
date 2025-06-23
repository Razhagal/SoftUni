using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a([^>]*?)href\s*=\s*(""|'|\s?)(.+?)\2(?=\s{1}|>)";
            Regex rgx = new Regex(pattern);

            //            string input = @"<!DOCTYPE html>
            //< html >
            //< head >
            //  < title > Hyperlinks </ title >
            //  < link href = ""theme.css"" rel = ""stylesheet"" />
            //   </ head >
            //   < body >
            //   < ul >< li >< a   href = ""/""  id = ""home"" > Home </ a ></ li >< li >< a
            // class=""selected"" href=/courses>Courses</a>
            //</li><li><a href =
            //'/forum' > Forum </ a ></ li >< li >< a class=""href""
            //onclick=""go()"" href= ""#"">Forum</a></li>
            //<li><a id = ""js"" href =
            //""javascript:alert('hi yo')"" class=""new"">click</a></li>
            //<li><a id = 'nakov' href =
            //http://www.nakov.com class='new'>nak</a></li></ul>
            //<a href = ""#empty"" ></ a >
            //< a id=""href"">href='fake'<img src = 'http://abv.bg/i.gif'
            //alt='abv'/></a><a href = ""#"" > &lt; a href = 'hello' & gt;</a>
            //<!-- This code is commented:
            //  <a href = ""#commented"" > commentex hyperlink</a> -->
            //</body>
            //";
            string input = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            while (!input.Equals("END"))
            {
                builder.Append(input);

                input = Console.ReadLine();
            }


            MatchCollection matches = rgx.Matches(builder.ToString());

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[3].Value);
            }
        }
    }
}