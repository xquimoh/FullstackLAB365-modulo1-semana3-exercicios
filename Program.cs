using Estacionamento;

List<Carro> carros = new List<Carro>();

// Variável do tipo string nomeada 'opcao'
string opcao;
do {
    Console.WriteLine("\nOlá, bem-vinde ao Estacionamento Pare Aqui!\nSelecione a opção desejada:");
    Console.WriteLine("1 - Cadastrar carro");
    Console.WriteLine("2 - Marcar entrada");
    Console.WriteLine("3 - Marcar saída");
    Console.WriteLine("4 - Consultar histórico");
    Console.WriteLine("5 - Sair");
    opcao = Console.ReadLine();

    if (opcao == "1"){
        CadastrarCarro();
    }

    if (opcao == "2"){
        GerarTicket();
    }

    if (opcao == "3"){
        FecharTicket();
    }

    if (opcao == "4"){
        Historico();
    }
 

} while (opcao != "5");

// Outra forma de organização de código para o menu:
// string opcao;
// void Menu(){
    // Console.WriteLine("\nOlá, bem-vinde ao Estacionamento Pare Aqui!\nSelecione a opção desejada:");
    // Console.WriteLine("1 - Cadastrar carro");
    // Console.WriteLine("2 - Marcar entrada");
    // Console.WriteLine("3 - Marcar saída");
    // Console.WriteLine("4 - Consultar histórico");
    // Console.WriteLine("5 - Sair");
    // opcao = Console.ReadLine();
// }
// do {
    // Menu();
//} while (opcao != "5");

// Método CadastrarCarro
void CadastrarCarro() {
    Carro carro = new Carro();
    Console.WriteLine("Digite a placa");
    carro.Placa = Console.ReadLine();
    Console.WriteLine("Digite o modelo");
    carro.Modelo = Console.ReadLine();
    Console.WriteLine("Digite a cor");
    carro.Cor = Console.ReadLine();
    Console.WriteLine("Digite a marca");
    carro.Marca = Console.ReadLine();
    carros.Add(carro);
}

// Método ObterCarro
Carro ObterCarro(string placa) { // Carro é porque o método ObterCarro vai retornar a instância do objeto carro
    foreach (var carro in carros){ // foreach percorre os dados de uma lista, no caso, procura pelos dados de carro dentro da lista carros
        if (placa == carro.Placa){
            return carro;
        }
    }
    return null; // se não encontrar a placa, retornará null, porque o carro com a placa informada não existe na lista
}

// Método GerarTicket
void GerarTicket() {
    Console.WriteLine("Qual a placa do veículo?");
    string placa = Console.ReadLine();

    // Consultando o método ObterCarro para validar se a placa já está cadastrada (exercício 6)
    var carro = ObterCarro(placa);
    if (carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    foreach (var ticket in carro.Tickets){
        if (ticket.Ativo == true){
            Console.WriteLine("Veículo já está no estacionamento");
            return;
        }
    }
     Ticket ticketNovo = new Ticket();
     carro.Tickets.Add(ticketNovo);
     Console.WriteLine("Novo ticket gerado!");
}

void FecharTicket() {
    Console.WriteLine("Qual a placa do veículo?");
    string placa = Console.ReadLine();

    // Consultando o método ObterCarro para validar se a placa já está cadastrada (exercício 6)
    var carro = ObterCarro(placa);
    if (carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    Ticket ticketAberto = null;
    foreach (var ticket in carro.Tickets){
        if (ticket.Ativo == true){
            ticketAberto = ticket;
        }
    }
    if (ticketAberto == null){
        Console.WriteLine("Não há tickets em aberto para o veículo");
        return;
    }
     ticketAberto.FecharTicket();
}

void Historico() {
    Console.WriteLine("Qual a placa do veículo?");
    string placa = Console.ReadLine();

    // Consultando o método ObterCarro para validar se a placa já está cadastrada (exercício 6)
    var carro = ObterCarro(placa);
    if (carro == null){
        Console.WriteLine("Carro não cadastrado");
        return;
    }

    Console.WriteLine("Entrada                  |Saída                    |Ativo    |Valor   ");

    foreach (var ticket in carro.Tickets){
        if (ticket.Ativo == true) {
            Console.WriteLine($"{ticket.Entrada}      |--------------           |{ticket.Ativo.ToString()}    |R$ --,--");
        }
        else {
        Console.WriteLine($"{ticket.Entrada}      |{ticket.Saida}      |{ticket.Ativo.ToString()}    |R$ {ticket.CalcularValor()}   ");
        }
    }
}