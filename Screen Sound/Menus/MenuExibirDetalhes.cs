using Screen_Sound.Modelos;

namespace Screen_Sound.Menus;

internal class MenuExibirDetalhes : Menu
{
    public void Executar(Dictionary<string, Banda> bandasRegistradas)
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