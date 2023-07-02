// Função para exibir Logo da aplicação
void Logo(){

    string saudacao = "Boas vindas ao Screen Sound!";

    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(saudacao);
}

// Função para exibição do Menu
void Menu(){

    Logo();
    Console.WriteLine("\nEscolha uma opção do menu:");
    Console.WriteLine("1 - Adicionar nova banda");
    Console.WriteLine("2 - Listar todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir média de uma banda");
    Console.WriteLine("5 - Sair " + "\n");

    int opcao = int.Parse(Console.ReadLine()!);

    switch(opcao)
    {
        case 1:AdicionarNovaBanda();
            break;
        case 2:ListarBandas();
            break;
        case 3:AvaliarBanda();
            break;
        case 4:ExibirMediaDaBanda();
            break;
        case 5:Sair();
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;

    }
}

//  Criando coleção de bandas
Dictionary<string, List<double>> colecaoDeBandas = new Dictionary<string, List<double>>();

// Função para adicionar uma nova banda
void AdicionarNovaBanda(){
    Console.Clear();
    TituloOpcao("Adicionar Banda");
    Console.WriteLine("Digite o nome da banda que deseja adicionar:");

    string nomeDaBanda = Console.ReadLine()!;
    colecaoDeBandas.Add(nomeDaBanda, new List<double>());

    Console.WriteLine("\n"+ $"A banda {nomeDaBanda} foi adicionada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    Menu();
}

// Função para listar todas as bandas cadastradas
void ListarBandas(){
    Console.Clear();
    TituloOpcao("Listar bandas");
    foreach (string banda in colecaoDeBandas.Keys ){
        Console.WriteLine($"Banda: {banda}");
    }
    Thread.Sleep(2000);
    Console.Clear();
    Menu();
}

// Função para avaliar uma banda
void AvaliarBanda(){
    Console.Clear();
    TituloOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if(colecaoDeBandas.ContainsKey(nomeBanda)){
        Console.Write($"Digite a nota para avaliar a banda {nomeBanda}:");
        double nota = double.Parse(Console.ReadLine()!);
        colecaoDeBandas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}!");
        Thread.Sleep(5000);
        Console.Clear();
        Menu();

    }else{
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

// Função para exibir média da banda
void ExibirMediaDaBanda(){
    Console.Clear();
    TituloOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda para saber a média dela: ");
    string nomeBanda = Console.ReadLine()!;
    double somatorioNotas = 0;
    if(colecaoDeBandas.ContainsKey(nomeBanda)){
        foreach(double nota in colecaoDeBandas[nomeBanda]){
            somatorioNotas += nota;
        }
        double media  = somatorioNotas / colecaoDeBandas[nomeBanda].Count;
        Console.WriteLine($"A média da banda {nomeBanda} é {Math.Round(media,1)}!");
        Thread.Sleep(5000);
        Console.Clear();
        Menu();

    }else{
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal:");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}

// Função para sair da aplicação
void Sair(){
    Console.WriteLine("Obrigado por utilizar o Screen Sound!");
    Console.WriteLine("Encerrando aplicação ...");
    Thread.Sleep(1000);
    Environment.Exit(0);
}

// Função para padronizar layout do título
void TituloOpcao(string titulo){
    int quantidadeLetras = titulo.Length;
    string asteristicos = string.Empty.PadLeft(quantidadeLetras,'*');
    Console.WriteLine(asteristicos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteristicos + "\n");
}

// Iniciando a aplicação
Menu();