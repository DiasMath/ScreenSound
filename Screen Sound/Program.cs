using Screen_Sound.Menus;
using Screen_Sound.Modelos;

internal class Program
{
    private static void Main(string[] args)
    {
        Banda ira = new("Ira");
        ira.AdicionarNota(new Avaliacao(10));
        ira.AdicionarNota(new Avaliacao(8));
        ira.AdicionarNota(new Avaliacao(6));

        Dictionary<string, Banda> bandasRegistradas = new();

        bandasRegistradas.Add(ira.Nome, ira);

        Dictionary<int, Menu> opcoes = new();
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuMostrarBandasRegistradas());
        opcoes.Add(4, new MenuAvaliarBanda());
        opcoes.Add(5, new MenuExibirDetalhes());
        opcoes.Add(-1, new MenuSair());



        void ExibirLogo()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

");
            Console.WriteLine("Bem Vindo ao Screen Sound!");

        }

        void ExibirMenu()
        {
            ExibirLogo();

            Console.WriteLine("\nEscolha a Opção desejada:");
            Console.WriteLine("1 - Registar uma Banda");
            Console.WriteLine("2 - Registrar o album de uma banda");
            Console.WriteLine("3 - Mostrar todas as bandas");
            Console.WriteLine("4 - Avaliar uma banda");
            Console.WriteLine("5 - Exibir os detalhes de uma banda");
            Console.WriteLine("-1 - Sair");


            Console.Write("\nDigite sua Opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
                menuASerExibido.Executar(bandasRegistradas);

                if (opcaoEscolhidaNumerica > 0) ExibirMenu();
            }
            else
            {
                Console.WriteLine("Opção Inválida!");
            }
        }

        ExibirMenu();
    }
}