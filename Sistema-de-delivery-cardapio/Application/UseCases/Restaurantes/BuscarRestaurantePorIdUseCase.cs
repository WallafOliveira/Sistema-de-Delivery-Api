using System;
using System.Threading.Tasks;
using Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Restaurantes
{
    public class BuscarRestaurantePorIdUseCase
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public BuscarRestaurantePorIdUseCase(IRestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public async Task<RestauranteDto?> Execute(Guid id)
        {
            var restaurante = await _restauranteRepository.BuscarPorId(id);

            if (restaurante == null)
                return null;

            return new RestauranteDto
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                CPNJ = restaurante.CPNJ,
                Endereco = restaurante.Endereco,
                EstaAberto = restaurante.EstaAberto
            };
        }
    }
}
