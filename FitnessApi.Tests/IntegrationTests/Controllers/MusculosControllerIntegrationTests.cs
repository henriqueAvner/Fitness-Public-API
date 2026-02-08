using System.Net;
using System.Net.Http.Json;
using fitnessApi.Models.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FitnessApi.Tests.IntegrationTests.Controllers
{
    public class MusculosControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public MusculosControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeMusculos()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var musculos = await response.Content.ReadFromJsonAsync<List<MusculoDto>>();
            musculos.Should().NotBeNull();
            musculos.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoMusculoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var musculo = await response.Content.ReadFromJsonAsync<MusculoDto>();
            musculo.Should().NotBeNull();
            musculo!.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoMusculoNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/9999");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetWithGrupoAndExercicios_DeveRetornarOkComDetalhes()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/1/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var detalhes = await response.Content.ReadFromJsonAsync<MusculoDetalhesDto>();
            detalhes.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWithGrupoAndExercicios_DeveRetornarNotFound_QuandoNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/9999/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAll_DeveRetornarContentTypeJson()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos");

            // Assert
            response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
        }

        [Fact]
        public async Task GetById_DeveRetornarMusculoComNomeCorreto()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/1");
            var musculo = await response.Content.ReadFromJsonAsync<MusculoDto>();

            // Assert
            musculo.Should().NotBeNull();
            musculo!.Nome.Should().Be("Peitoral Maior");
        }

        [Fact]
        public async Task GetAll_DeveRetornarMusculosComMovimentoPrincipal()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos");
            var musculos = await response.Content.ReadFromJsonAsync<List<MusculoDto>>();

            // Assert
            musculos.Should().NotBeNull();
            musculos!.Should().AllSatisfy(m => m.MovimentoPrincipal.Should().NotBeNullOrEmpty());
        }

        [Fact]
        public async Task GetWithGrupoAndExercicios_DeveRetornarGrupoMuscular()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos/1/detalhes");
            var detalhes = await response.Content.ReadFromJsonAsync<MusculoDetalhesDto>();

            // Assert
            detalhes.Should().NotBeNull();
            detalhes!.GrupoMuscular.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetAll_DeveRetornarMultiplosMusculos()
        {
            // Act
            var response = await _client.GetAsync("/api/musculos");
            var musculos = await response.Content.ReadFromJsonAsync<List<MusculoDto>>();

            // Assert
            musculos.Should().NotBeNull();
            musculos!.Count.Should().BeGreaterThanOrEqualTo(3);
        }
    }
}
