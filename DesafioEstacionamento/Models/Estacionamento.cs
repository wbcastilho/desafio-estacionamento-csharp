using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {                   
            string? placa = "";

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();

            if (placa != null)
                this.veiculos.Add(placa);
            else
                Console.WriteLine("Placa inválida");
        }

        public void RemoverVeiculo()
        {
            string? placa = "";                     

            Console.WriteLine("Digite a placa do veículo para remover:");                    

            if (placa != null)
            {
                placa = Console.ReadLine();

                 // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa!.ToUpper()))
                {                   
                    int horas = 0;
                    decimal valorTotal = 0; 

                    Console.WriteLine("Informe a quantidade de horas que o veículo permaneceu estacionado:");
                    horas = Convert.ToInt32(Console.ReadLine());

                    valorTotal = this.precoInicial + (precoPorHora * horas);
                   
                    this.veiculos.Remove(placa!);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ " + valorTotal.ToString("0.00"));
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Placa inválida");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");               
                foreach (var item in this.veiculos)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}