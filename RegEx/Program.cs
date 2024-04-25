using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics.CodeAnalysis;
namespace RegEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
            //Ex2();
            //Ex3();
            //Ex4();
            //Ex5();
        }

        public static void Ex1()
        {
            string names = Console.ReadLine();
            var validNames = new List<string>();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            MatchCollection matches = Regex.Matches(names, pattern);


            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
        public static void Ex2()
        {
            string numbers = Console.ReadLine();
            string pattern = @"\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
            var matches = Regex.Matches(numbers, pattern);
            foreach(Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
        public static void Ex3()
        {
            string dates = Console.ReadLine();
            string pattern = @"(?<day>[0-9]{2})(?<separator>[-/.])(?<month>[aA-zZ]{3})\2(?<year>[0-9]{4})";
            Regex rx = new Regex(pattern);

            MatchCollection matches = Regex.Matches(dates, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Day:{match.Groups["day"].Value} Month:{match.Groups["month"].Value} Year:{match.Groups["year"].Value}");
            }

            
        }
        public static void Ex4()
        {
            string input = Console.ReadLine();
            var txt = new List<string>();
            while(input != "Purchase")
            {
                txt.Add(input);
                input = Console.ReadLine();
            }
            string furnitures = String.Join(" ", txt);
            string pattern = @">>(?<furniture>\w+)<<(?<price>\d+.?\d*)\!(?<times>\d)";
            MatchCollection matches = Regex.Matches(furnitures, pattern);
            Console.WriteLine("Bought furniture: ");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["furniture"].Value);
            }
            Console.WriteLine("Total money spent: ");
            double sum = 0;
            foreach(Match match in matches)
            {
                sum += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["times"].Value);
            }
            Console.WriteLine(sum);
        }
        public static void Ex5()
        {
            string input = Console.ReadLine();
            string pattern = @"%(?<name>[A-Z][a-z]+)%<(?<product>[A-Z][a-z]+)>\|(?<times>\d)\|(?<price>\d+.?\d+?)\$";
            double total = 0;
            Regex rx = new Regex(pattern);
            while (input != "end of shift")
            {
                if (rx.IsMatch(input))
                {
                    Match match = rx.Match(input);
                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {int.Parse(match.Groups["times"].Value) * double.Parse(match.Groups["price"].Value):f2}");
                    total += Math.Round(int.Parse(match.Groups["times"].Value) * double.Parse(match.Groups["price"].Value), 2);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Total income:" + total);
        }
    }
}
