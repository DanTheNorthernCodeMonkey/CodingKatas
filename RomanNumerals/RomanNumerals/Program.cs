using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
	public class Program
	{
		static readonly Dictionary<char, int> RomanNumeralValues = new Dictionary<char, int>
		{
			{'I',1},
			{'V',5},
			{'X',10},
			{'L',50},
			{'C',100},
			{'D',500},
			{'M',1000}
		};

		static readonly Dictionary<string, int> TestData = new Dictionary<string, int>
		{
			{"I",1},
			{"IV",4},
			{"XI",11},
			{"LIII",53},
			{"CD",400},
			{"DCIV",604},
			{"MCCXXIV",1224},
			{"CCXVIII",218},
			{"LXVI",66},
			{"XXXVII",37},
			{"XCIV",94}
		};

		public static void Main()
		{
			foreach (var test in TestData)
			{
				Console.WriteLine(test.Key + " " + RomanNumeralConverter(test.Key));
			}

			Console.ReadLine();
		}

		public static int RomanNumeralConverter(string romanNumeral)
		{
			var result = 0;
			var previous = 0;

			foreach (var numeral in romanNumeral.ToCharArray())
			{
				var current = RomanNumeralValues.FirstOrDefault(x => x.Key == numeral).Value;

				if (current <= previous)
					result += current;

				if (current > previous)
				{
					result -= previous;

					result += current - previous;
				}

				previous = current;
			}
			return result;
		}
	}
}
