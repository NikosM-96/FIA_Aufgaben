namespace ConsoleMwstSumme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleMwstSumme");

            Beleg beleg = new Beleg();
            beleg.AddTestPosition(8);

            Console.WriteLine(beleg);

            Console.ReadLine();
        }
    }

    class Position
    {
        private int ArtikelNr;
        private double Preis;
        private string Steuersatz;

        public Position(int artikelNr, double preis, string steuersatz)
        {
            ArtikelNr = artikelNr;
            Preis = preis;
            Steuersatz = steuersatz;
        }

        public override string ToString()
        {
            return $"{ArtikelNr,8} {Preis.ToString("N2"),6} {Steuersatz}";
        }

        public static Position ErzeugeTestPosition(Random random)
        {
            return new Position(random.Next(10000, 90000),
                                random.Next(10, 1001) / 100.0,
                                random.Next(0, 2) == 0 ? "B" : "A");
        }

        public double GetPreis()
        {
            return Preis;
        }

        public string GetSteuersatz()
        {
            return Steuersatz;
        }
    }

    class Beleg
    {
        private DateTime Ausgestellt;
        private double Summe;
        private double SummeNetto;
        private double SummeSteuerA;
        private double SummeSteuerB;
        private int SteuersatzA;
        private int SteuersatzB;

        List<Position> positionen = new List<Position>();

        public Beleg(int steuersatzA = 7, int steuersatzB = 19)
        {
            Ausgestellt = DateTime.Now;
            SteuersatzA = steuersatzA;
            SteuersatzB = steuersatzB;
        }

        public void AddPosition(Position position)
        {
            positionen.Add(position);
        }

        public void AddTestPosition(int anzahl)
        {
            Random r = new Random(123);

            for (int i = 0; i < anzahl; i++)
            {
                Position position = Position.ErzeugeTestPosition(r);
                AddPosition(position);
            }

            BerechneSummen();
        }

        private void BerechneSummen()
        {
            double summe = 0;
            double summeNetto = 0;
            double summeSteuerA = 0;
            double summeSteuerB = 0;

            for (int i = 0; i < positionen.Count; i++)
            {
                double preis = positionen[i].GetPreis();
                summe += preis;

                string steuersatz = positionen[i].GetSteuersatz();
                if (steuersatz == "A")
                {
                    double nettoPreis = preis * 100 / 107;
                    summeNetto += nettoPreis;
                    summeSteuerA += preis - nettoPreis;
                }
                else if (steuersatz == "B")
                {
                    double nettoPreis = preis * 100 / 119;
                    summeNetto += nettoPreis;
                    summeSteuerB += preis - nettoPreis;
                }
            }

            Summe = summe;
            SummeNetto = summeNetto;
            SummeSteuerA = summeSteuerA;
            SummeSteuerB = summeSteuerB;
        }

        public override string ToString()
        {
            string str = "";
            str += $"Beleg vom: {Ausgestellt}";
            foreach (Position p in positionen)
            {
                str += $"\n{p}";
            }
            str += "\n----------------------------";
            str += $"\nSumme: {Summe.ToString("N2").PadLeft(9)}";
            str += $"\nNetto: {SummeNetto.ToString("N2").PadLeft(9)}";
            str += $"\nMwSt A {SteuersatzA}% {SummeSteuerA.ToString("N2").PadLeft(6)}";
            str += $"\nMwSt B {SteuersatzB}% {SummeSteuerB.ToString("N2").PadLeft(5)}";


            return str;
        }

    }
}
