using System;
using System.Linq;
using System.Text.Json;

public class Project {

    public static void QuestUm() {
        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE) {
            K = K + 1;
            SOMA = SOMA + K;
        }
        Console.WriteLine(SOMA);
    }

    public class QuestTres {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

    public static bool QuestDois(int numero) {
        int a = 0;
        int b = 1;

        while (b < numero) {
            int tempo = a;
            a = b;
            b = tempo + b;
        }
        return b == numero || numero == 0;
    }

    public static void QuestQuatro() {
        double faturamentoSP = 67836.43;
        double faturamentoRJ = 36678.66;
        double faturamentoMG = 29229.88;
        double faturamentoES = 27165.48;
        double faturamentoOutros = 19849.53;
        double faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG + faturamentoES + faturamentoOutros;
        double porcentagemSP = (faturamentoSP / faturamentoTotal) * 100;
        double porcentagemRJ = (faturamentoRJ / faturamentoTotal) * 100;
        double porcentagemMG = (faturamentoMG / faturamentoTotal) * 100;
        double porcentagemES = (faturamentoES / faturamentoTotal) * 100;
        double porcentagemOutros = (faturamentoOutros / faturamentoTotal) * 100;

        Console.WriteLine($"Fat SP {porcentagemSP:F2}%");
        Console.WriteLine($"Fat RJ {porcentagemRJ:F2}%");
        Console.WriteLine($"Fat MG {porcentagemMG:F2}%");
        Console.WriteLine($"Fat ES {porcentagemES:F2}%");
        Console.WriteLine($"Fat Outros {porcentagemOutros:F2}%");
    }

    public static string QuestCindo(string input) {
        char[] charArray = new char[input.Length];
        int index = 0;

        for (int i = input.Length - 1; i >= 0; i--) {
            charArray[index] = input[i];
            index++;
        }
        return new string(charArray);
    }

    public static void Main(string[] args) {
        int numero = 15;
        //questão um
        QuestUm();
        Console.WriteLine("");
        //questão dois
        if (QuestDois(numero)) {
            Console.WriteLine("Pertence ao Fibonacci" + numero);
        } else {
            Console.WriteLine("Não pertence pertence ao Fibonacci " + numero);
        }
        Console.WriteLine("");
        //questão quatro
        QuestQuatro();
        Console.WriteLine("");
        //questão cinco
        string input = "Christian";
        string invert = QuestCindo(input);
        Console.WriteLine(invert);

        Console.WriteLine("");
        //questão três

        string faturamentoJson = @"[
	{
		""dia"": 1,
		""valor"": 22174.1664
	},
	{
		""dia"": 2,
		""valor"": 24537.6698
	},
	{
		""dia"": 3,
		""valor"": 26139.6134
	},
	{
		""dia"": 4,
		""valor"": 0.0
	},
	{
		""dia"": 5,
		""valor"": 0.0
	},
	{
		""dia"": 6,
		""valor"": 26742.6612
	},
	{
		""dia"": 7,
		""valor"": 0.0
	},
	{
		""dia"": 8,
		""valor"": 42889.2258
	},
	{
		""dia"": 9,
		""valor"": 46251.174
	},
	{
		""dia"": 10,
		""valor"": 11191.4722
	},
	{
		""dia"": 11,
		""valor"": 0.0
	},
	{
		""dia"": 12,
		""valor"": 0.0
	},
	{
		""dia"": 13,
		""valor"": 3847.4823
	},
	{
		""dia"": 14,
		""valor"": 373.7838
	},
	{
		""dia"": 15,
		""valor"": 2659.7563
	},
	{
		""dia"": 16,
		""valor"": 48924.2448
	},
	{
		""dia"": 17,
		""valor"": 18419.2614
	},
	{
		""dia"": 18,
		""valor"": 0.0
	},
	{
		""dia"": 19,
		""valor"": 0.0
	},
	{
		""dia"": 20,
		""valor"": 35240.1826
	},
	{
		""dia"": 21,
		""valor"": 43829.1667
	},
	{
		""dia"": 22,
		""valor"": 18235.6852
	},
	{
		""dia"": 23,
		""valor"": 4355.0662
	},
	{
		""dia"": 24,
		""valor"": 13327.1025
	},
	{
		""dia"": 25,
		""valor"": 0.0
	},
	{
		""dia"": 26,
		""valor"": 0.0
	},
	{
		""dia"": 27,
		""valor"": 25681.8318
	},
	{
		""dia"": 28,
		""valor"": 1718.1221
	},
	{
		""dia"": 29,
		""valor"": 13220.495
	},
	{
		""dia"": 30,
		""valor"": 8414.61
	}
]";
        var faturamento = JsonSerializer.Deserialize<List<QuestTres>>(faturamentoJson);
        var faturamentoComValor = faturamento.Where(d => d.Dia > 0).ToList();
        int diasAcima;

        double menorValor, maiorValor, mediaMensal;

        if (faturamentoComValor.Any()) {
            menorValor = faturamentoComValor.Min(d => d.Valor);
            maiorValor = faturamentoComValor.Max(d => d.Valor);
            mediaMensal = faturamentoComValor.Average(d => d.Valor);
            diasAcima = faturamentoComValor.Count(d => d.Valor > mediaMensal);

            Console.WriteLine("Valores acima da media:" + maiorValor);
            Console.WriteLine("Valores abaixo da media:" + menorValor);
            Console.WriteLine("Valores da media:" + mediaMensal);
            Console.WriteLine("Faturamento diario:" + diasAcima);
        } else {
            Console.WriteLine("Não há faturamento com valor positivo.");
        }
    }
}