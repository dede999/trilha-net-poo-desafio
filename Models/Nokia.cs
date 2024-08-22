namespace DesafioPOO.Models
{
    public class Nokia: Smartphone
    {
        public Nokia(string numero, string modelo, string imei) : base(numero, modelo, imei, 256)
        {
        }

        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine("Instalando aplicativo {0} no Nokia {1}", nomeApp, Modelo);
        }
    }
}