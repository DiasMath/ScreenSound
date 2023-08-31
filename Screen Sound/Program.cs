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
                    RegistrarBanda();
                    break;
                case 2:
                    RegistrarAlbum();
                    break;
                case 3:
                    MostrarBandasRegistradas();
                    break;
                case 4:
                    AvaliarBanda();
                    break;
                case 5:
                    ExibirDetalhes();
                    break;
                case 9:
                    Console.WriteLine("\nTchau!");
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }

        }

        void RegistrarAlbum()
        {
            Console.Clear();
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
                ExibirMenu();
            }

            ExibirMenu();
        }

        void RegistrarBanda()
        {
            Console.Clear();

            TituloDaOpcao("Registro de Bandas");

            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            Banda banda = new(nomeDaBanda);
            bandasRegistradas.Add(nomeDaBanda, banda);
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");

            Thread.Sleep(2000);
            Console.Clear();

            ExibirMenu();
        }

        void MostrarBandasRegistradas()
        {
            Console.Clear();

            TituloDaOpcao("Exibindo todas as bandas registradas");

            foreach (string banda in bandasRegistradas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
            Console.ReadKey();

            Console.Clear();
            ExibirMenu();
        }

        void TituloDaOpcao(string titulo)
        {
            int qtdLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

        void AvaliarBanda()
        {
            Console.Clear();
            TituloDaOpcao("Avaliar Banda");
            Console.Write("Digite a Banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];
                Console.Write($"Digite a nota para a banda {nomeDaBanda}: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                banda.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} para a banda {nomeDaBanda} foi registrada com sucesso!");

                Thread.Sleep(3000);
                Console.Clear();
                ExibirMenu();

            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
            }
        }

        void ExibirDetalhes()
        {
            Console.Clear();
            TituloDaOpcao("Exibir detalhes da Banda");
            Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];
                Console.WriteLine($"\nA média da Banda {nomeDaBanda} é: {banda.Media}");

                Console.WriteLine("\nDigite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();

            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
            }


        }

        ExibirMenu();
    }
}