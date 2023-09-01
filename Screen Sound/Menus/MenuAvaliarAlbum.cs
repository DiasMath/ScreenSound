using Screen_Sound.Modelos;

namespace Screen_Sound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);

        TituloDaOpcao("Avaliar album");

        Console.Write("Digite a Banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite o titulo do album: ");
            string tituloAlbum = Console.ReadLine()!;

            if(banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Equals(tituloAlbum));
                Console.Write($"Digite a nota para a banda {nomeDaBanda}: ");

                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);

                Console.WriteLine($"\nA nota {nota.Nota} para o album {tituloAlbum} foi registrada com sucesso!");
                Thread.Sleep(3000);
                Console.Clear();
            } else
            {
                Console.WriteLine($"\nO album {tituloAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }  
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
