
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CossineSimilarity
{
    class Program
    {
        static void Main(string[] args)
        {
            var frase1 = @"A carteira do carteiro tem cartas dentro";
            var frase2 = @"A carta que está dentro do carteira do carteiro";
            var fraseVetor1 = ConvertArrayDouble(frase1);
            var fraseVetor2 = ConvertArrayDouble(frase2);
            var score = Accord.Math.Distance.Cosine(fraseVetor1, fraseVetor2);
            
            Console.WriteLine(score);
        }

        private static double[] ConvertArrayDouble(string frase)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            frase = rgx.Replace(frase, "");
            var vetor = frase.Split(" ");

            return vetor.GroupBy(x => x).Select(x => (double)x.Count()).ToArray();

        }
    }
}
