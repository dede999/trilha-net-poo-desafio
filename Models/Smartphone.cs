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

        private void GerirExcessao(bool ehOrigem)
        {
            string mensagem = ehOrigem ? "O dispositivo de origem" : "O dispositivo chamado";
            var typeString = ehOrigem ? "LigacaoNaoPermitida" : "LigacaoNaoCompleta";
            var type = Type.GetType("DesafioPOO.Exceptions.Calls." + typeString);
            Exception exc = null;

            if (!Ligado)
            {
                exc = Activator.CreateInstance(type!, mensagem + " está desligado") as Exception;
            }
            if (EmLigacao)
            {
                exc = Activator.CreateInstance(type!, mensagem + " já está em ligação") as Exception;
            }

            if (exc != null)
            {
                throw exc;
            }
        }

        public void Ligar(Smartphone receptor)
        {
            GerirExcessao(true);
            Console.WriteLine("Ligando...");
            receptor.ReceberLigacao();
            EmLigacao = true;
        }

        public void ReceberLigacao()
        {
            GerirExcessao(false);
            Console.WriteLine("Recebendo ligação...");
            EmLigacao = true;
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}