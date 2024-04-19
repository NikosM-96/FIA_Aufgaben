using System.Net.NetworkInformation;

namespace DeviceManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleGeräteverwaltung");
            Console.WriteLine();

            List<Device> devices = new List<Device>();


            Standort standort = new Standort("building54", "raum77");
            Device device = new Device();
            device.Inventarnummer = "4432";
            device.Hersteller = "hersteller";
            device.Bezeichnung = "4D2Z";
            device.Standort = standort;



            Standort standort2 = new Standort("building54545", "18");
            Device device2 = new Device("3231", "hersteller2", "5Y1B", standort2);


            Standort standort3 = new Standort("building121", "522");
            NetworkDevice networkDevice = new NetworkDevice();
            networkDevice.Inventarnummer = "5334";
            networkDevice.Hersteller = "dsdsd";
            networkDevice.Bezeichnung = "5E2V";
            networkDevice.Standort = standort3;
            networkDevice.Mac = "sd:3d3:dd3:3d";
            networkDevice.Ip = "192.168.91.55";

            devices.Add(device);
            devices.Add(device2);
            devices.Add(networkDevice);

            foreach (Device d in devices)
            {
                Console.WriteLine(d.ToString());
                Console.WriteLine();
            }


            Console.ReadLine();

        }
    }

    public interface IErreichbar
    {
        string GetStatus();
    }

    public class Device
    {
        public string Inventarnummer { get; set; }
        public string Hersteller { get; set; }
        public string Bezeichnung { get; set; }
        public Standort Standort { get; set; }


        public override string ToString()
        {
            string str = "";
            str += $"Inventarnummer: {Inventarnummer}";
            str += $"\nHersteller: {Hersteller}";
            str += $"\nBezeichnung: {Bezeichnung}";
            str += $"\nGebäude: {Standort.Building}";
            str += $"\nRaum: {Standort.Raum}";


            return str;
        }

        public Device(string inventarnummer, string hersteller, string bezeichnung, Standort standort)
        {
            Inventarnummer = inventarnummer;
            Hersteller = hersteller;
            Bezeichnung = bezeichnung;
            Standort = standort;
        }

        public Device() { }
    }

    public class NetworkDevice : Device, IErreichbar
    {
        public string Mac { get; set; }
        public string Ip { get; set; }

        public override string ToString()
        {
            string str = "";
            str += $"Inventarnummer: {Inventarnummer}";
            str += $"\nHersteller: {Hersteller}";
            str += $"\nBezeichnung: {Bezeichnung}";
            str += $"\nGebäude: {Standort.Building}";
            str += $"\nRaum: {Standort.Raum}";
            str += $"\nMac: {Mac}";
            str += $"\nIP: {Ip}";
            str += $"\nStatus: {GetStatus()}";


            return str;
        }

        public string GetStatus()
        {
            PingReply reply = new Ping().Send(Ip, 200);
            return reply.Status.ToString();
        }

        public NetworkDevice(string inventarnummer, string hersteller, string bezeichnung, Standort standort, string mac, string ip)
                            : base(inventarnummer, hersteller, bezeichnung, standort)
        {
            Mac = mac;
            Ip = ip;
        }

        public NetworkDevice() { }
    }

    public class Standort
    {
        public string Building { get; set; }
        public string Raum { get; set; }

        public override string ToString()
        {
            string str = "";
            str += $"Gebäude: {Building}";
            str += $"\nRaum: {Raum}";


            return str;
        }

        public Standort(string building, string raum)
        {
            Building = building;
            Raum = raum;
        }

        public Standort() { }
    }

}
