using DesafioPOO.Exceptions.Calls;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        protected string Modelo { get; }
        protected string IMEI { get; }
        protected int Memoria { get; set; }
        protected bool Ligado { get; set; }
        protected bool EmLigacao { get; set; }

        protected Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
            Ligado = false;
            EmLigacao = false;
        }
        
        public void LigarDispositivo()
        {
            Ligado = true;
        }
        
        public void DesligarDispositivo()
        {
            Ligado = false;
        }

        public void Ligar(Smartphone receptor)
        {
            if (!Ligado)
            {
                throw new LigacaoNaoPermitida("O dispositivo de origem está desligado");
            }
            if (EmLigacao)
            {
                throw new LigacaoNaoPermitida("O dispositivo de origem já está em ligação");
            }
            Console.WriteLine("Ligando...");
            receptor.ReceberLigacao();
            EmLigacao = true;
        }

        public void ReceberLigacao()
        {
            if (!Ligado)
            {
                throw new LigacaoNaoCompleta("O dispositivo chamado está desligado");
            }
            if (EmLigacao)
            {
                throw new LigacaoNaoCompleta("O dispositivo chamado já está em ligação");
            }
            Console.WriteLine("Recebendo ligação...");
            EmLigacao = true;
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}