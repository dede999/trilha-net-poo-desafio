namespace DesafioPOO.Exceptions
{
    namespace Calls
    {
        public class LigacaoNaoCompleta : Exception
        {
            public LigacaoNaoCompleta(string message) : base(message) {}
        }
        
        public class LigacaoNaoPermitida : Exception
        {
            public LigacaoNaoPermitida(string message) : base(message) {}
        }
    }    
}
