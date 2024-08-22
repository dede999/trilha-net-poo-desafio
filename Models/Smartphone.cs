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
        private Smartphone ConenctadoCom { get; set; }

        protected Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
            Ligado = false;
            ConenctadoCom = null;
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
            if (ConenctadoCom != null)
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
            receptor.ReceberLigacao(this);
            ConenctadoCom = receptor;
        }

        public void ReceberLigacao(Smartphone origem)
        {
            GerirExcessao(false);
            Console.WriteLine("Recebendo ligação...");
            ConenctadoCom = origem;
        }
        
        public void FinalizarLigacao(int level = 0)
        {
            if (level > 1)
            {
                return;
            }
            if (ConenctadoCom == null)
            {
                throw new LigacaoNaoCompleta("Não há ligação para finalizar");
            }
            var conectado = ConenctadoCom;
            ConenctadoCom = null;
            conectado.FinalizarLigacao(level + 1);
            Console.WriteLine("Finalizando ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
    }
}