using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaOOP
{
    public class Persona
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { 
                    if(nome.Length>2)
                    {
                         nome = value;
                    }
                else { nome = "user"; }
                }
        }
    }
    public class Conto : Persona
    {
        private bool chiu;
        public bool Chiu
        {
            get { return chiu; }
            set { chiu = value; }
        }

        private float _saldo;
        public float Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public void apri()
        {
            Chiu = false;
        }
        public void conto()
        {
            Saldo = 0;
            Chiu = true;
        }
        public float saldo()
        {
            return Saldo;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Conto conto = new Conto();

            Console.WriteLine("Inserisci il nome");
            string n = Console.ReadLine();
            switch(Console.ReadLine())
            {

            }
            conto.Nome = n;
            Console.WriteLine("Inserisci il saldo");
            float s = int.Parse(Console.ReadLine());

            conto.Saldo = s;

            Console.WriteLine($"Il saldo di {conto.Nome}: {conto.saldo()}");
            


            Console.ReadLine();
        }
    }
}
