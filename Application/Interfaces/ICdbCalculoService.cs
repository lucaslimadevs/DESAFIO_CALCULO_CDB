using Domain.Investimento;

namespace Application.Interfaces
{
    public interface ICdbCalculoService
    {
        InvestimentoCdbResult Calcular(InvestimentoCdb investimento);
    }
}
