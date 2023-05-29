using Application.Interfaces;
using Domain.Investimento;

namespace Application.Services.CDB
{
    public class CdbCalculoService : ICdbCalculoService
    {
        private const decimal TaxaBanco = 1.08m;
        private const decimal TaxaCdi = 0.009m;

        public InvestimentoCdbResult Calcular(InvestimentoCdb investimento)
        {
            decimal valorFinal = CalcularValorFinal(investimento.Valor, investimento.Meses);
            decimal rendimento = valorFinal - investimento.Valor;
            decimal imposto = CalcularImposto(investimento.Meses, rendimento);

            var result = new InvestimentoCdbResult
            {
                ValorBruto = Math.Round(valorFinal, 2),
                ValorLiquido = Math.Round(valorFinal - imposto, 2)
            };

            return result;
        }

        private decimal CalcularValorFinal(decimal valorInicial, int numMeses)
        {
            decimal taxaCdiBanco = TaxaCdi * TaxaBanco;
            decimal valorFinal = valorInicial;

            for (int i = 0; i < numMeses; i++)
            {
                valorFinal *= (1 + taxaCdiBanco);
            }

            return valorFinal;
        }

        public decimal CalcularImposto(int meses, decimal rendimento)
            => meses switch
            {
                <= 6 => (rendimento * 0.225m),
                <= 12 => (rendimento * 0.20m),
                <= 24 => (rendimento * 0.175m),
                _ => (rendimento * 0.15m)
            };
    }
}
