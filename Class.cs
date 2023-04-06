using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App
{
    public static class Extensao
    {
        public static string ParseHome(this string path)
        {
            string home = (Environment.OSVersion.Platform == PlatformID.Unix ||
                Environment.OSVersion.Platform == PlatformID.MacOSX) ?
                Environment.GetEnvironmentVariable("HOME") :
                Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            return path.Replace("~", home);
        }
    }
    public class Class
    {
        public static void Desafio1()
        {
            Console.WriteLine("------ Desafio 1 ------");
            int indice = 13, soma = 0, k = 0;
            while (k < indice)
            {
                k += 1;
                soma += k;
            }
            Console.WriteLine("Soma: " + soma);
        }
        public static void Desafio2()
        {
            Console.WriteLine("------ Desafio 2 ------");
            int numero;
            List<int> Fibonacci = new List<int> { 0, 1 };
            Console.Write("Digite um número: ");
            numero = int.Parse(Console.ReadLine());

            for (int i = 0; i < 30; i++)
            {
                int ultimoN = Fibonacci.Count - 1;
                int pUltimo = Fibonacci.Count - 2;

                int resultado = ultimoN + pUltimo;

                Fibonacci.Add(resultado);
            }
            foreach (var i in Fibonacci)
            {
                if (numero != i)
                {
                    Console.WriteLine("Não pertence a sequência!");
                }
                else
                {
                    Console.WriteLine("Pertence a sequência!");
                    break;
                }
            }
        }
        public static void Desafio3()
        {
            Console.WriteLine("------ Desafio 3 ------");
            Console.Write("Digite o nome do arquivo.json que esteja na home do seu usuario: ");
            string arquivo = Console.ReadLine();
            var path = $@"~/{arquivo}".ParseHome();
            try
            {
                int mDia = 0, meDia = 0;
                List<int> sDia = new List<int>();
                double mValor = 0, meValor = 0, soma = 0, media = 0;
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();
                    JsonDocument doc = JsonDocument.Parse(jsonString);
                    JsonElement root = doc.RootElement;
                    JsonElement diasValores = root;
                    foreach (JsonElement item in diasValores.EnumerateArray())
                    {
                        int dia = item.GetProperty("dia").GetInt32();
                        double valor = item.GetProperty("valor").GetDouble();
                        if (valor > mValor)
                        {
                            mValor = valor;
                            mDia = dia;
                        }
                        if (valor < meValor)
                        {
                            meValor = valor;
                            meDia = dia;
                        }
                        soma += valor;
                        media = soma / 30;

                        if(valor > media)
                        {
                            sDia.Add(dia);
                        }
                        Console.WriteLine($"Dia: {dia}, Valor: {valor}");
                    }
                    Console.WriteLine($"O maior valor é {mValor} no dia {mDia}.");
                    Console.WriteLine($"O menor valor é {meValor} no dia {meDia}.");
                    Console.WriteLine($"O faturamento foi superior que a médias em: {sDia.Count} dias");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("O arquivo não pode ser lido: " + e.Message);
            }

        }
        public static void Desafio4()
        {
            double SP = 67836.43, RJ = 36678.66, MG = 29229.88, ES = 27165.48, Outros = 19849.53;

            double Soma = SP + RJ + MG + ES + Outros;
            Console.WriteLine(Porcentagem(SP, Soma).ToString("F2"));
            Console.WriteLine(Porcentagem(RJ, Soma).ToString("F2"));
            Console.WriteLine(Porcentagem(MG, Soma).ToString("F2"));
            Console.WriteLine(Porcentagem(ES, Soma).ToString("F2"));
            Console.WriteLine(Porcentagem(Outros, Soma).ToString("F2"));
        }
        public static double Porcentagem(double valor, double soma)
        {
            double porcentagem = (valor / soma) * 100;

            return porcentagem;
        }
        public static void Desafio5()
        {
            Console.Write("Digite uma frase: ");
            string texto = Console.ReadLine();
            char[] f = texto.ToCharArray();
            
            for (int i = 0, j = f.Length - 1; i < j; i++, j--)
            {
                char temp = f[i];
                f[i] = f[j];
                f[j] = temp;
            }
            string frase = new string(f);
            Console.WriteLine(frase);
        }
    }
}
