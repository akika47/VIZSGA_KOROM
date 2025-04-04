using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoapp.Model
{
    public class Auto
    {
        private int sorszam;
        private string marka;
        private string modell;
        private int gyartasiev;
        private string szin;
        private int eladottdb;
        private int atlagar;

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Modell { get => modell; set => modell = value; }
        public int Gyartasiev { get => gyartasiev; set => gyartasiev = value; }
        public string Szin { get => szin; set => szin = value; }
        public int Eladottdb { get => eladottdb; set => eladottdb = value; }
        public int Atlagar { get => atlagar; set => atlagar = value; }

        public Auto(string[] sor)
        {
            sorszam = int.Parse(sor[0]);
            marka = sor[1];
            modell = sor[2];
            gyartasiev = int.Parse(sor[3]);
            szin = sor[4];
            eladottdb = int.Parse(sor[5]);
            atlagar = int.Parse(sor[6]);
        }

        static public List<Auto> LoadCars(string path)
        {
            List<Auto> temp = new List<Auto>();
            File.ReadAllLines(path).Skip(1).ToList().ForEach(x =>
            {
                temp.Add(new Auto(x.Split(";")));
            });
            return temp;
        }
    }
}
