using DesafioPOO.Models;

(Smartphone, Smartphone) CriarAparelhos()
{
    var iPhone = new Iphone("123456789", "12 Pro", "123456789");
    var nokia = new Nokia("987654321", "3310", "987654321");
    return (iPhone, nokia);
}

void RealizarLigacao(Smartphone origem, Smartphone destino)
{
    try
    {
        origem.Ligar(destino);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

// --- Testes Chamadas ---

void RealizarLigacaoComAparelhosLigados()
{
    Console.WriteLine("---RealizarLigacaoComAparelhosLigados");
    (Smartphone iPhone, Smartphone nokia) = CriarAparelhos();
    iPhone.LigarDispositivo();
    nokia.LigarDispositivo();
    iPhone.Ligar(nokia);
}

void RealizarLigacaoComAparelhoDeOrigemDesligado()
{
    Console.WriteLine("---RealizarLigacaoComAparelhoDeOrigemDesligado");
    (Smartphone origem, Smartphone destino) = CriarAparelhos();
    destino.LigarDispositivo();
    RealizarLigacao(origem, destino);
}

void RealizarLigacaoComAparelhoDeDestinoDesligado()
{
    Console.WriteLine("---RealizarLigacaoComAparelhoDeDestinoDesligado");
    (Smartphone origem, Smartphone destino) = CriarAparelhos();
    origem.LigarDispositivo();
    RealizarLigacao(origem, destino);
}

void AperelhoOrigemEmDuasLigacoes()
{
    Console.WriteLine("---AperelhoOrigemEmDuasLigacoes");
    (Smartphone origem, Smartphone destino) = CriarAparelhos();
    origem.LigarDispositivo();
    destino.LigarDispositivo();
    RealizarLigacao(origem, destino);
    RealizarLigacao(origem, destino);
}

void AperelhoDestinoEmDuasLigacoes()
{
    Console.WriteLine("---AperelhoOrigemEmDuasLigacoes");
    Smartphone origem2 = new Iphone("123456789", "13 Pro", "123456789");
    (Smartphone origem, Smartphone destino) = CriarAparelhos();
    origem.LigarDispositivo();
    origem2.LigarDispositivo();
    destino.LigarDispositivo();
    RealizarLigacao(origem, destino);
    RealizarLigacao(origem2, destino);
}

void DesligarEFazerOutraLigacao()
{
    Console.WriteLine("---DesligarEFazerOutraLigacao");
    Smartphone origem2 = new Iphone("123456789", "13 Pro", "123456789");
    (Smartphone origem, Smartphone destino) = CriarAparelhos();
    origem.LigarDispositivo();
    origem2.LigarDispositivo();
    destino.LigarDispositivo();
    RealizarLigacao(origem, destino);
    origem.FinalizarLigacao();
    RealizarLigacao(origem2, destino);
}

RealizarLigacaoComAparelhosLigados();
RealizarLigacaoComAparelhoDeOrigemDesligado();
RealizarLigacaoComAparelhoDeDestinoDesligado();
AperelhoOrigemEmDuasLigacoes();
AperelhoDestinoEmDuasLigacoes();