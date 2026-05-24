using DataApplications.Entities;

namespace Sistema_de_delivery_cardapio.Domain.Interfaces;

public interface IRestauranteRepository
{
    void Adicionar(Restaurante restaurante);
    void Atualizar(Restaurante restaurante);
    List<Restaurante> ListarTodos();
    List<Restaurante> ListarAbertos();
    Restaurante? BuscarPorId(Guid id);
}
