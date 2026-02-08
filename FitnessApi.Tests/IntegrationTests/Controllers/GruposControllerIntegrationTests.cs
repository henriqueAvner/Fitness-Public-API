using System.Net;
using System.Net.Http.Json;
using fitnessApi.Models.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FitnessApi.Tests.IntegrationTests.Controllers
{
    public class GruposControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public GruposControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeGrupos()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var grupos = await response.Content.ReadFromJsonAsync<List<GrupoMuscularDto>>();
            grupos.Should().NotBeNull();
            grupos.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoGrupoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var grupo = await response.Content.ReadFromJsonAsync<GrupoMuscularDto>();
            grupo.Should().NotBeNull();
            grupo!.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoGrupoNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/9999");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetWithMusculos_DeveRetornarOkComDetalhes()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/1/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var detalhes = await response.Content.ReadFromJsonAsync<GrupoMuscularDetalhesDto>();
            detalhes.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWithMusculos_DeveRetornarNotFound_QuandoNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/9999/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAll_DeveRetornarContentTypeJson()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos");

            // Assert
            response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
        }

        [Fact]
        public async Task GetById_DeveRetornarGrupoComNomeCorreto()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/1");
            var grupo = await response.Content.ReadFromJsonAsync<GrupoMuscularDto>();

            // Assert
            grupo.Should().NotBeNull();
            grupo!.Nome.Should().Be("Peito");
        }

        [Fact]
        public async Task GetAll_DeveRetornarGruposComDescricao()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos");
            var grupos = await response.Content.ReadFromJsonAsync<List<GrupoMuscularDto>>();

            // Assert
            grupos.Should().NotBeNull();
            grupos!.Should().AllSatisfy(g => g.Descricao.Should().NotBeNullOrEmpty());
        }

        [Fact]
        public async Task GetWithMusculos_DeveRetornarListaDeMusculos()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos/1/detalhes");
            var detalhes = await response.Content.ReadFromJsonAsync<GrupoMuscularDetalhesDto>();

            // Assert
            detalhes.Should().NotBeNull();
            detalhes!.Musculos.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAll_DeveRetornarMultiplosGrupos()
        {
            // Act
            var response = await _client.GetAsync("/api/grupos");
            var grupos = await response.Content.ReadFromJsonAsync<List<GrupoMuscularDto>>();

            // Assert
            grupos.Should().NotBeNull();
            grupos!.Count.Should().BeGreaterThanOrEqualTo(3);
        }
    }
}
