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

        public Persona() 
        {

            nome = "user";
        }    
        public string Nome
        {
            get { return nome; }
            set
            {
                if ( nome.Length > 2)
                {
                    nome = value;
                }
                else
                {
                }
            }
        }
    }
    public class Conto : Persona
    {
        private bool chiu;
        private float _saldo;

        public Conto()
        {
            chiu = true;
            _saldo = 0;
        }
        public bool Chiu
        {
            get { return chiu; }
            set { chiu = value; }
        }

        
        public float Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
        public void apri()
        {
            Chiu = false;
        }
        public void chiudi()
        {
            Saldo = 0;
            Chiu = true;
        }
        public void deposita(float c) 
        {
            Saldo += c;
        }
        public void preleva(float p)
        {
            if(Saldo>p)
            {
                Saldo -= p;
            }
            else
            {
                Console.WriteLine("Non puoi prelevare questa somma perchè il suo saldo non è sufficiente");
            }

           
        }
        public float saldo()
        {
            return Saldo;
        }

        public string stato()
        {
            if(Chiu==false)
            {
                return "aperto";
            }
            else 
            {
                return "chiuso";
            }
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Conto conto = new Conto();

            Console.WriteLine("Inserisci il nome");
            string n = Console.ReadLine();
            conto.Nome = n;

            bool uscita = false;

            Console.WriteLine("Menu:\n1)Conto\n2)Banca");
            string r=Console.ReadLine();

            if(r=="1" || r=="2")
            {
                if (r == "1")
                {
                    while (uscita == false)
                    {
                        Console.Clear();
                        Console.WriteLine("1) Apri conto");
                        Console.WriteLine("2) Azzera il conto");
                        Console.WriteLine("3) Deposita sul conto");
                        Console.WriteLine("4) Preleva dal conto");
                        Console.WriteLine("5) Vedi saldo sul conto");
                        Console.WriteLine("6) Visualizza info conto");
                        Console.WriteLine("Altri Tasti) Esci");

                        switch (Console.ReadLine())
                        {
                            case "1":
                                if (conto.Chiu == false)
                                {
                                    Console.WriteLine("Il conto è già aperto");
                                }
                                else if (conto.Chiu == true)
                                {
                                    conto.apri();
                                    Console.WriteLine("Il conto è stato aperto");
                                    Console.ReadLine();
                                }
                                break;

                            case "2":
                                conto.chiudi();
                                Console.WriteLine("Il conto è stato chiuso");
                                Console.ReadLine();
                                break;

                            case "3":
                                Console.WriteLine("Inserisci la somma da depositare");
                                float c = int.Parse(Console.ReadLine());
                                conto.deposita(c);
                                Console.WriteLine("Il saldo è stato incrementato");
                                Console.ReadLine();
                                break;

                            case "4":
                                Console.WriteLine("Inserisci la somma da prelevare");
                                float p = int.Parse(Console.ReadLine());
                                conto.preleva(p);
                                Console.WriteLine("Il saldo è stato decrementato");
                                Console.ReadLine();
                                break;

                            case "5":
                                Console.WriteLine($"Saldo attuale: {conto.saldo()} euro");
                                Console.ReadLine();
                                break;

                            case "6":
                                Console.WriteLine($"Nome: {conto.Nome}\nStato conto: {conto.stato()}\nSaldo: {conto.Saldo}");
                                Console.ReadLine();
                                break;

                            default:
                                uscita = true;
                                break;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine("Puoi scegliere solo tra 1 o 2");
                Console.WriteLine("Menu:\n1) Conto\n2) Banca");
                r = Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
