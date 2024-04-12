using System.IO;
using System.Xml.Serialization;
using static FIA_Aufgaben.Program;

namespace FIA_Aufgaben
{
    internal class Program
    {

        static XmlSerializer xml = new XmlSerializer(typeof(List<Spieler>));

        static List<Spieler> spielerListe;



        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleFussball");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(Menu());

                Console.WriteLine();

                Console.Write("Ihre Wahl: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SpielerListeInitialisieren();
                        break;
                    case "2":
                        SpielerAnzeigen();
                        break;
                    case "3":
                        AddPlayer();
                        break;
                    case "4":
                        ModifySpieler();
                        break;
                    case "5":
                        RemoveSpielerListe();
                        break;
                    case "6":
                        SpielerSpeichern();
                        break;
                    case "7":
                        SpielerEinlesen();
                        break;
                    case "exit":
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;

                }

                Console.WriteLine();
            }
        }

        static void SpielerAnzeigen()
        {

            if (spielerListe == null)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Liste");
                return;
            }

            if (spielerListe.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Spieler");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Spieler anzeigen... {spielerListe.Count}");

            foreach (Spieler spieler in spielerListe)
            {
                Console.WriteLine();
                Console.WriteLine($"Index: {spielerListe.IndexOf(spieler)}");
                Console.WriteLine(spieler);
            }
        }

        static void AddPlayer()
        {

            if (spielerListe == null)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Liste");
                return;
            }

            string vorname;
            string name;
            string verein;
            string geburtstag;
            string nummer;

            Console.Write("Vorname: ");
            vorname = Console.ReadLine();

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.Write("Verein: ");
            verein = Console.ReadLine();

            Console.Write("Geburtstag: ");
            geburtstag = Console.ReadLine();

            Console.Write("Nummer: ");
            nummer = Console.ReadLine();

            DateTime dateTime;

            try
            {
                dateTime = Convert.ToDateTime(geburtstag);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                return;
            }



            Spieler spieler = new Spieler(vorname, name, verein, dateTime, Convert.ToInt32(nummer));

            spielerListe.Add(spieler);
        }

        static void SpielerListeInitialisieren()
        {
            spielerListe = new List<Spieler>();

            Console.WriteLine();
            Console.WriteLine("SpielerListe initialisieren...");
        }

        static void RemoveSpielerListe()
        {

            if (spielerListe == null)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Liste");
                return;
            }

            spielerListe.Clear();

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.WriteLine();
        }

        static void ModifySpieler()
        {

            if (spielerListe == null)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Liste");
                return;
            }

            if (spielerListe.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Keine Spieler");
                return;
            }

            int index;
            Console.Write("Index: ");
            try
            {
                index = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                return;
            }


            Console.Write("Vorname: ");
            string vorname = Console.ReadLine();
            spielerListe[index].Vorname = string.IsNullOrEmpty(vorname) ? spielerListe[index].Vorname : vorname;

            Console.Write("Name: ");
            string name = Console.ReadLine();
            spielerListe[index].Name = string.IsNullOrEmpty(name) ? spielerListe[index].Name : name;

            Console.Write("Verein: ");
            string verein = Console.ReadLine();
            spielerListe[index].Verein = string.IsNullOrEmpty(verein) ? spielerListe[index].Verein : verein;

            Console.Write("Geburtstag: ");
            string geburtstag = Console.ReadLine();
            spielerListe[index].Geburtstag = string.IsNullOrEmpty(geburtstag)
                ? spielerListe[index].Geburtstag
                : Convert.ToDateTime(geburtstag);

            Console.Write("Nummer: ");
            string strNummer = Console.ReadLine();
            spielerListe[index].Nummer = string.IsNullOrEmpty(strNummer)
                ? spielerListe[index].Nummer
                : Convert.ToInt32(strNummer);

        }

        static string StringEinlesen(string strText)
        {
            return Console.ReadLine();
        }

        static string Menu()
        {

            string menu = "1: Liste initialisieren" +
                "\n2: Spieler anzeigen" +
                "\n3: Spieler hinzufügen" +
                "\n4: Spieler ändern" +
                "\n5: Liste löschen" +
                "\n6: SpielerSpeichern" +
                "\n7: SpielerEinlesen" +
                "\nexit: Beenden";

            return menu;
        }

        static void SpielerSpeichern()
        {
            Console.WriteLine("SpielerSpeichern: ");
            StreamWriter streamW = new StreamWriter("Spieler.xml");
            xml.Serialize(streamW, spielerListe);
            streamW.Close();
            Console.WriteLine("Anzahl Spieler gespeichert: " + spielerListe.Count);
        }

        static void SpielerEinlesen()
        {
            Console.WriteLine("SpielerEinlesen: ");
            StreamReader streamR = new StreamReader("Spieler.xml");
            spielerListe = (List<Spieler>)xml.Deserialize(streamR);
            streamR.Close();
            Console.WriteLine("Anzahl Spieler eingelesen: " + spielerListe.Count);
        }

    }

    [Serializable]
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

