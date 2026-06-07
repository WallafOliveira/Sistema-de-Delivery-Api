using System;
using System.Threading.Tasks;
using Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Restaurantes
{
    public class UpdateRestauranteUseCase
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public UpdateRestauranteUseCase(IRestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public async Task<RestauranteDto> Execute(Guid id, UpdateRestauranteDto dto)
        {
            var restaurante = await _restauranteRepository.BuscarPorId(id);

            if (restaurante == null)
                throw new Exception($"Restaurante com ID {id} não encontrado.");

            restaurante.AtualizarDados(dto.Nome, dto.CPNJ, dto.Endereco, dto.EstaAberto, dto.Logo);

            var restauranteAtualizado = await _restauranteRepository.Atualizar(id, restaurante);

            if (restauranteAtualizado == null)
                throw new Exception("Falha ao atualizar restaurante.");

            return new RestauranteDto
            {
                Id = restauranteAtualizado.Id,
                Nome = restauranteAtualizado.Nome,
                CPNJ = restauranteAtualizado.CPNJ,
                Endereco = restauranteAtualizado.Endereco,
                Logo = restauranteAtualizado.Logo,
                EstaAberto = restauranteAtualizado.EstaAberto
            };
        }
    }
}
