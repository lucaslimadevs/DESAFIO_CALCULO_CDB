using Application.Services.CDB;
using Domain.Investimento;

namespace Application.Tests.Services.CDB
{
    public class CdbCalculoServiceTests
    {
        private readonly CdbCalculoService _cdbCalculoService;

        public CdbCalculoServiceTests()
        {
            _cdbCalculoService = new CdbCalculoService();
        }

        [Fact]
        public void Calcular_6_meses_ReturnsInvestimentoCdbResult()
        {
            // Arrange
            var investimento = new InvestimentoCdb
            {
                Valor = 12000,
                Meses = 6
            };

            // Act
            var result = _cdbCalculoService.Calcular(investimento);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(12717.07m, result.ValorBruto, 4);
            Assert.Equal(12555.73m, result.ValorLiquido, 4);
        }

        [Fact]
        public void Calcular_12_meses_ReturnsInvestimentoCdbResult()
        {
            // Arrange
            var investimento = new InvestimentoCdb
            {
                Valor = 1000,
                Meses = 12
            };

            // Act
            var result = _cdbCalculoService.Calcular(investimento);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1123.08m, result.ValorBruto, 4);
            Assert.Equal(1098.47m, result.ValorLiquido, 4);
        }

        [Fact]
        public void Calcular_24_meses_ReturnsInvestimentoCdbResult()
        {
            // Arrange
            var investimento = new InvestimentoCdb
            {
                Valor = 1000,
                Meses = 24
            };

            // Act
            var result = _cdbCalculoService.Calcular(investimento);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1261.31m, result.ValorBruto, 4);
            Assert.Equal(1215.58m, result.ValorLiquido, 4);
        }

        [Theory]
        [InlineData(6, 500, 112.5)]
        [InlineData(12, 500, 100)]
        [InlineData(24, 500, 87.5)]
        [InlineData(36, 500, 75)]
        public void CalcularImposto_ReturnsCorrectValue(int meses, decimal rendimento, decimal expectedImposto)
        {
            // Arrange e Act
            var imposto = _cdbCalculoService.CalcularImposto(meses, rendimento);

            // Assert
            Assert.Equal(expectedImposto, imposto);
        }
    }
}