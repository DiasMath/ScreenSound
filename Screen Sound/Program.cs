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
            Console.WriteLine("9 - Sair");


            Console.Write("\nDigite sua Opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    MenuRegistrarBanda menu1 = new();
                    menu1.Executar(bandasRegistradas);
                    ExibirMenu();
                    break;
                case 2:
                    MenuRegistrarAlbum menu2 = new();
                    menu2.Executar(bandasRegistradas);
                    ExibirMenu();
                    break;
                case 3:
                    MenuMostrarBandasRegistradas menu3 = new();
                    menu3.Executar(bandasRegistradas);
                    ExibirMenu();
                    break;
                case 4:
                    MenuAvaliarBanda menu4 = new();
                    menu4.Executar(bandasRegistradas);
                    ExibirMenu();
                    break;
                case 5:
                    MenuExibirDetalhes menu5 = new();
                    menu5.Executar(bandasRegistradas);
                    ExibirMenu();
                    break;
                case 9:
                    MenuSair menu9 = new();
                    menu9.Executar(bandasRegistradas);
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }

        }

        ExibirMenu();
    }
}