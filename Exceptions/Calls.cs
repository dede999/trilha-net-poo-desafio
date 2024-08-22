namespace DesafioPOO.Exceptions
{
    namespace Calls
    {
        public class LigacaoNaoCompleta : Exception
        {
            public LigacaoNaoCompleta(string message) : base(message) {}
        }
        
        public class LinhaOcupada : Exception
        {
            public LinhaOcupada() : base("O número ligado está ocupado") {}
        }
        
        public class LigacaoNaoPermitida : Exception
        {
            public LigacaoNaoPermitida(string message) : base(message) {}
        }
    }    
}
