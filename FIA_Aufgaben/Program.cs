using System.Collections;

namespace FIA_Aufgaben
{
    internal class Program
    {

        static List<Spieler> spielerListe = new List<Spieler>();
        static ArrayList spielerListeArrayList = new ArrayList();

        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleFussball");
            Console.WriteLine();

            Console.WriteLine("1: Liste initialisieren");
            Console.WriteLine("2: Spieler anzeigen");
            Console.WriteLine("3: Spieler hinzufügen");
            Console.WriteLine("4: Spieler ändern");
            Console.WriteLine("5: Liste löschen");
            Console.WriteLine("exit: Beenden");

            Console.WriteLine();

            Console.Write("Ihre Wahl: ");
            //string choice = Console.ReadLine();

            Spieler spieler1 = new Spieler();

            spieler1.Vorname = "Mats";
            spieler1.Name = "Hummels";
            spieler1.Verein = "BVB";
            spieler1.Geburtstag = new DateTime(1989, 05, 31);
            spieler1.Nummer = 15;
            
            Spieler spieler2 = new Spieler();
            spieler2.Vorname = "Dsds";
            spieler2.Name = "Dsds";
            spieler2.Verein = "RRR";
            spieler2.Geburtstag = Convert.ToDateTime("05.02.1992");
            spieler2.Nummer = 17;

            Spieler spieler3 = new Spieler("Gdfd", "Ewes", "TTT", new DateTime(1992, 08, 12), 21);

            Console.WriteLine(spieler1);
            Console.WriteLine();
            Console.WriteLine(spieler2);
            Console.WriteLine();
            Console.WriteLine(spieler3);

            //spielerListe.Add(spieler1);
            spielerListe.Add(spieler1, spieler2, spieler3);


            foreach (Spieler spieler in spielerListe)
            {
                Console.WriteLine();
                Console.WriteLine($"Index: {spielerListe.IndexOf(spieler)}");
                Console.WriteLine(spieler.ToString());
            }

            Console.ReadLine();

        }

        public class Spieler
        {
            public string Vorname;
            public string Name;
            public string Verein;
            public DateTime Geburtstag;
            public int Nummer;
            public int Alter;

            public int GetAlter()
            {
                int nAlter = 0;

                DateTime dtNow = DateTime.Now;
                DateTime dtGeb = Convert.ToDateTime(Geburtstag);

                nAlter = dtNow.Year - dtGeb.Year;

                if ((dtGeb.Month > dtNow.Month) || ((dtGeb.Month == dtNow.Month) && (dtGeb.Day > dtNow.Day)))
                {
                    nAlter -= 1;
                }


                return nAlter;
            }

            public override string ToString()
            {
                string result = "";

                result += $"Vorname: {Vorname}";
                result += $"\nName: {Name}";
                result += $"\nVerein: {Verein}";
                result += $"\nGeburtstag: {Geburtstag}";
                result += $"\nNummer: {Nummer}";
                result += $"\nAlter: {GetAlter()}";


                return result;
            }

            public Spieler(string vorname, string name, string verein, DateTime geburtstag, int nummer)
            {
                Vorname = vorname;
                Name = name;
                Verein = verein;
                Geburtstag = geburtstag;
                Nummer = nummer;
                Alter = GetAlter();
            }

            public Spieler() { }
        }


    }
}
