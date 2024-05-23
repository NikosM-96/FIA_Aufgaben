namespace Pruefungsaufgaben
{
	internal class Program
	{
		static void Main(string[] args)
		{

			// Region Rebsorte Jahrgang Geschmacksrichtung Abastz un Stk.
			int[,] absatz = {
			{123, 456, 78, 9, 46},
			{333, 321, 43, 3, 78},
			{444, 564, 65, 5, 233},
			{123, 432, 77, 6, 533},
			{666, 188, 21, 7, 122},
			{123, 744, 96, 2, 86},
			{666, 188, 21, 7, 122},
			{433, 644, 21, 8, 56},
			{834, 642, 34, 8, 453},
			{964, 222, 54, 8, 777},
			{408, 343, 67, 8, 211},
		};

			string sucheTopseller(int kriterium, int vorgabewert)
			{
				int max = 0;
				string code = "";

				for (int i = 0; i < absatz.GetLength(0); i++)
				{
					if (absatz[i, kriterium] == vorgabewert && absatz[i, 4] > max)
					{
						max = absatz[i, 4];
						code = $"{absatz[i, 0]}-{absatz[i, 1]}-{absatz[i, 2]}-{absatz[i, 3]}";
					}
				}

				return code;
			}

			Console.WriteLine(sucheTopseller(0, 123));
			Console.WriteLine(sucheTopseller(3, 8));

			Console.ReadLine();
		}
	}
}
