using System.Threading.Tasks;
using Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;
using Sistema_de_delivery_cardapio.Domain.Entities;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Restaurantes
{
    public class CreateRestauranteUseCase
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public CreateRestauranteUseCase(IRestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public async Task<RestauranteDto> Execute(CreateRestauranteDto dto)
        {
            var restaurante = new Restaurante(dto.Nome, dto.CPNJ, dto.Endereco, dto.Logo);

            await _restauranteRepository.Adicionar(restaurante);

            return new RestauranteDto
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                CPNJ = restaurante.CPNJ,
                Endereco = restaurante.Endereco,
                Logo = restaurante.Logo,
                EstaAberto = restaurante.EstaAberto
            };
        }
    }
}
