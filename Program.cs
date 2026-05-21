using System;
using System.Collections.Generic;
using PROJETO_POO_CRUD.Models;
using PROJETO_POO_CRUD.Repository;

TarefaRepository repo = new TarefaRepository();
bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("======= GERENCIADOR DE TAREFAS (TO-DO LIST) =======");
    Console.WriteLine("1. Adicionar Nova Tarefa");
    Console.WriteLine("2. Listar Todas as Tarefas");
    Console.WriteLine("3. Editar Tarefa");
    Console.WriteLine("4. Marcar Tarefa como Concluída");
    Console.WriteLine("5. Excluir Tarefa");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("--- ADICIONAR TAREFA ---");
            Tarefa novaTarefa = new Tarefa();
            Console.Write("Título da tarefa: ");
            novaTarefa.TextoTarefa = Console.ReadLine(); // Atualizado
            Console.Write("Descrição da tarefa: ");
            novaTarefa.Descricao = Console.ReadLine();

            if (!string.IsNullOrEmpty(novaTarefa.TextoTarefa)) repo.Inserir(novaTarefa);
            else Console.WriteLine("[X] O título da tarefa não pode ser vazio.");
            ExibirMensagemEGuardar();
            break;

        case "2":
            ExibirListaDeTarefas();
            ExibirMensagemEGuardar();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("--- EDITAR TAREFA ---");
            Tarefa tarefaEditar = new Tarefa();
            Console.Write("Informe o ID da tarefa que deseja editar: ");
            if (int.TryParse(Console.ReadLine(), out int idEditar))
            {
                tarefaEditar.Id = idEditar;
                Console.WriteLine("\n(Deixe em branco o campo que NÃO deseja alterar)");
                Console.Write("Novo Título: ");
                tarefaEditar.TextoTarefa = Console.ReadLine(); // Atualizado
                Console.Write("Nova Descrição: ");
                tarefaEditar.Descricao = Console.ReadLine();
                repo.Editar(tarefaEditar);
            }
            else Console.WriteLine("[X] ID inválido.");
            ExibirMensagemEGuardar();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("--- CONCLUIR TAREFA ---");
            Console.Write("Informe o ID da tarefa a ser concluída: ");
            if (int.TryParse(Console.ReadLine(), out int idConcluir)) repo.MarcarComoConcluida(idConcluir);
            else Console.WriteLine("[X] ID inválido.");
            ExibirMensagemEGuardar();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine("--- EXCLUIR TAREFA ---");
            Console.Write("Informe o ID da tarefa a ser excluída: ");
            if (int.TryParse(Console.ReadLine(), out int idExcluir)) repo.Excluir(idExcluir);
            else Console.WriteLine("[X] ID inválido.");
            ExibirMensagemEGuardar();
            break;

        case "6":
            continuar = false;
            Console.WriteLine("\nSaindo do sistema... Até logo!");
            break;

        default:
            Console.WriteLine("\n[X] Opção inválida!");
            Console.ReadKey();
            break;
    }
}

void ExibirListaDeTarefas()
{
    Console.Clear();
    Console.WriteLine("--- LISTA DE TAREFAS ---");
    List<Tarefa> tarefas = repo.Listar();

    if (tarefas.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada no momento.");
        return;
    }

    foreach (var t in tarefas)
    {
        string status = t.Concluida ? "[✓] Concluída" : "[ ] Pendente";
        Console.WriteLine($"ID: {t.Id} | {status} | Título: {t.TextoTarefa}"); // Atualizado
        if (!string.IsNullOrEmpty(t.Descricao)) Console.WriteLine($"   Descrição: {t.Descricao}");
        Console.WriteLine($"   Criada em: {t.DataCriacao:dd/MM/yyyy HH:mm}");
        Console.WriteLine(new string('-', 50));
    }
}

void ExibirMensagemEGuardar()
{
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
}