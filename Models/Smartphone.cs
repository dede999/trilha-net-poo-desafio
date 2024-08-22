namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        protected string Modelo { get; }
        protected string IMEI { get; }
        protected int Memoria { get; set; }
        protected bool Ligado { get; set; }

        protected Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
            Ligado = false;
        }
        
        public void LigarDispositivo()
        {
            Ligado = true;
        }
        
        public void DesligarDispositivo()
        {
            Ligado = false;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}