using OpenAI_API;
using Screen_Sound.Modelos;

namespace Screen_Sound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        TituloDaOpcao("Registro de Bandas");

        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        // inserindo algoritmo para IA

        // A chave gratuita tem que ser trocada de 3 em 3 meses
        var client = new OpenAIAPI("sua chave aqui");

        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 paragrafo. Adote um estilo informal.");
        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        banda.Resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
    }
}
