using Screen_Sound.Modelos;

namespace Screen_Sound.Menus;

internal class MenuRegistrarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        TituloDaOpcao("Registro de Albuns");
        Console.Write("Digite a banda cujo album deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Agora digite o titulo do album: ");
            string tituloAlbum = Console.ReadLine()!;
            Banda banda = bandasRegistradas[nomeDaBanda];
            banda.AdicionarAlbum(new Album(tituloAlbum));

            Console.WriteLine($"O album {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
