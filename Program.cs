using System;
using System.Collections.Generic;
using DesafioProjetoHospedagem.Models;

class Program
{
    static void Main()
    {
        Reserva reserva = new Reserva();
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("==== Sistema de Reserva de Hotel ====");
            Console.WriteLine("1. Cadastrar Suíte");
            Console.WriteLine("2. Cadastrar Hóspedes");
            Console.WriteLine("3. Definir Dias Reservados");
            Console.WriteLine("4. Mostrar Quantidade de Hóspedes");
            Console.WriteLine("5. Calcular Valor da Diária");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Tipo da suíte: ");
                    string tipo = Console.ReadLine();

                    Console.Write("Capacidade: ");
                    int capacidade = int.Parse(Console.ReadLine());

                    Console.Write("Valor da diária: ");
                    decimal valorDiaria = decimal.Parse(Console.ReadLine());

                    Suite suite = new Suite(tipo, capacidade, valorDiaria);
                    reserva.CadastrarSuite(suite);
                    Console.WriteLine("Suíte cadastrada com sucesso!\n");
                    break;

                case "2":
                    Console.Write("Quantos hóspedes deseja cadastrar? ");
                    int qtd = int.Parse(Console.ReadLine());

                    var hospedes = new List<Pessoa>();
                    for (int i = 0; i < qtd; i++)
                    {
                        Console.Write($"Nome do hóspede {i + 1}: ");
                        string nome = Console.ReadLine();
                        Console.Write($"Sobrenome do hóspede {i + 1}: ");
                        string sobrenome = Console.ReadLine();
                        hospedes.Add(new Pessoa(nome, sobrenome));
                    }

                    try
                    {
                        reserva.CadastrarHospedes(hospedes);
                        Console.WriteLine("Hóspedes cadastrados com sucesso!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}\n");
                    }
                    break;

                case "3":
                    Console.Write("Digite o número de dias reservados: ");
                    reserva.DiasReservados = int.Parse(Console.ReadLine());
                    Console.WriteLine("Dias reservados atualizados!\n");
                    break;

                case "4":
                    Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}\n");
                    break;

                case "5":
                    decimal valorTotal = reserva.CalcularValorDiaria();
                    Console.WriteLine($"Valor total da diária: R$ {valorTotal}\n");
                    break;

                case "6":
                    sair = true;
                    Console.WriteLine("Saindo do programa. Até mais!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.\n");
                    break;
            }
        }
    }
}
