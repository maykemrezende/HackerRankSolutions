using System;
using System.Linq;

namespace HackerrankChallenges.ChallengesSolutions
{
	public static class PaoDeMetroSolution
    {
		private static bool Ok(int sliceLength, int k, int[] breads, int n)
		{
			int pessoasAtendidas = 0;

			// para cada pão
			for (int i = 0; i < k; i++)
			{
				// adiciono a pessoas atendidas o número de pedaços em que podem ser divididos
				pessoasAtendidas += breads[i] / sliceLength;

				//se esse número superar a quantidade de pessoas
				if (pessoasAtendidas >= n) 
					return true;
			}

			// se nem todas as pessoas puderam ser atendidas
			return false;
		}

		private static int BinarySearch(int n, int k, int[] breads, int maxBreadLength)
		{
			int intervalStart = 1; 
			int intervalFinish = maxBreadLength; 
			int answer = 0;

			while (intervalStart <= intervalFinish)
			{
				// meio do intervalo da busca binária
				int sliceLength = (intervalStart + intervalFinish) / 2;

				// se posso atender às pessoas com fatias do tamanho que especifiquei
				if (Ok(sliceLength, k, breads, n))
				{
					answer = Math.Max(sliceLength, answer);

					// vamos pra direita
					intervalStart = sliceLength + 1;
				}

				// se não, vamos pra esquerda
				else 
					intervalFinish = sliceLength - 1;
			}

			return answer;
		}


		// o algoritmo de busca binário é um algoritmo de time complexity de O(log N) que pressupõe que a coleção está ordenada, 
		// como vamos iterá-lo N = K vezes verificando se cada tamanho de pão é suficiente, esse algoritmo leva uma complexidade de O(N log N)
		// n = numero de pessoas, k = número de pães, breads são o tamanho dos pães
		public static void PaoDeMetroAnswer(int n, int k, int[] breads)
		{
			n = 10;
			k = 4;
			breads = new int [] { 120, 89, 230, 177 };

			var maxBreadLength = breads.Max();
			breads = breads.OrderBy(p => p).ToArray();

			Console.WriteLine("{0}", BinarySearch(n, k, breads, maxBreadLength));
			Console.ReadLine();
		}
	}
}
