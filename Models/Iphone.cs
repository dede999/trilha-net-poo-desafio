namespace DesafioPOO.Models
{
    public class Iphone : Smartphone
    {
        public Iphone(string numero, string modelo, string imei) : base(numero, modelo, imei, 128)
        {}

        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine("Instalando aplicativo {0} no Iphone {1}", nomeApp, Modelo);
        }
    }
}