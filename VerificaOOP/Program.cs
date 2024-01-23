using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace VerificaOOP
{
    public class Persona
    {
        public string nome;

        public Persona()
        {

            nome = "user";
        }
        public string Nome
        {
            get { return nome; }
            set
            {
                if (nome.Length > 2)
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
            if (Saldo > p)
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
            if (Chiu == false)
            {
                return "aperto";
            }
            else
            {
                return "chiuso";
            }
        }

    }
    public class Banca
    {
        List<Conto> contos = new List<Conto>();
        //private Conto[] arr=new Conto[100];

        public void Apri()
        {
            contos.Add(new Conto());
            /*for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Conto();
            }*/
        }
        public int Ricerca(string _nome)
        {
            int pos = -1;
            for (int i = 0; i < contos.Count; i++)
            {
                if (contos[i].Nome == "user")
                {
                    contos[i].Nome = _nome;
                    pos = i;
                    break;
                }
                else if (contos[i].Nome == _nome)
                {
                    pos = i;
                    break;
                }
               
            }
            return pos;
        }
        public void ApriConto(string _nome)
        {
            int pos = Ricerca(_nome);
            contos[pos].apri();
            contos[pos].Nome=_nome;
            Console.WriteLine($"Il conto di {_nome} è stato aperto");
               
            
        }
        public void ChiudiConto(string _nome)
        {
            int pos = Ricerca(_nome);
            contos[pos].chiudi();
            contos[pos].Nome = _nome;
            Console.WriteLine($"Il conto di {_nome} è stato aperto");
        }
        public void DepositaSuConto(string _nome, float c)
        {
            int pos = Ricerca(_nome);
            contos[pos].deposita(c);
            Console.WriteLine($"Sul conto sono stati depositati {contos[pos].Saldo} euro");
        }

        public void PrelevaDalConto(string _nome, float c)
        {
            int pos = Ricerca(_nome);
            contos[pos].preleva(c);
            Console.WriteLine($"Dal conto sono stati prelevati {contos[pos].Saldo} euro");
        }
        public void VediSaldoConto(string _nome)
        {
            int pos = Ricerca(_nome);
            Console.WriteLine($"Il saldo equivale {contos[pos].saldo()} euro");
        }
        public void VediInfoConto(string _nome)
        {
            int pos = Ricerca(_nome);
            Console.WriteLine($"Info:\nStato conto:{contos[pos].stato()}\nSaldo:{contos[pos].saldo()} euro");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Conto conto = new Conto();
            Banca banca = new Banca();

            string nome = "";

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
                        Console.WriteLine("CONTO");
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
                else if (r == "2")
                {
                    while (uscita == false)
                    {
                        Console.Clear();
                        Console.WriteLine("BANCA");
                        Console.WriteLine("1) Apri conto");
                        Console.WriteLine("2) Chiudi conto");
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
                                    Console.WriteLine("Inserisci nome");
                                    nome=Console.ReadLine();
                                    banca.Apri();
                                    banca.ApriConto(nome);
                                    Console.ReadLine();
                                }
                                break;

                            case "2":
                                Console.WriteLine("Inserisci nome");
                                banca.ChiudiConto(nome);
                                Console.WriteLine("Il conto è stato chiuso");
                                Console.ReadLine();
                                break;

                            case "3":
                                Console.WriteLine("Inserisci nome");
                                nome = Console.ReadLine();
                                Console.WriteLine("Inserisci la somma da depositare");
                                float c = float.Parse(Console.ReadLine());
                                banca.DepositaSuConto(nome,c);
                                Console.ReadLine();
                                break;

                            case "4":
                                Console.WriteLine("Inserisci nome");
                                nome = Console.ReadLine();
                                Console.WriteLine("Inserisci la somma da prelevare");
                                float n = float.Parse(Console.ReadLine());
                                banca.PrelevaDalConto(nome, n);
                                Console.ReadLine();
                                break;

                            case "5":
                                Console.WriteLine("Inserisci nome");
                                nome = Console.ReadLine();
                                banca.VediSaldoConto(nome);
                                Console.ReadLine();
                                break;

                            case "6":
                                Console.WriteLine("Inserisci nome");
                                nome = Console.ReadLine();
                                banca.VediInfoConto(nome);
                                Console.ReadLine();
                                break;

                            default:
                                uscita = true;
                                break;
                        }
                    }
                }
                else { }
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
