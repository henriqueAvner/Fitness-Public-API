using System.Net;
using System.Net.Http.Json;
using fitnessApi.Models.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FitnessApi.Tests.IntegrationTests.Controllers
{
    public class ExerciciosControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public ExerciciosControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAll_DeveRetornarOkComListaDeExercicios()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var exercicios = await response.Content.ReadFromJsonAsync<List<ExercicioDto>>();
            exercicios.Should().NotBeNull();
            exercicios.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public async Task GetById_DeveRetornarOk_QuandoExercicioExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/1");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var exercicio = await response.Content.ReadFromJsonAsync<ExercicioDto>();
            exercicio.Should().NotBeNull();
            exercicio!.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetById_DeveRetornarNotFound_QuandoExercicioNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/9999");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetWithMusculoAndGrupo_DeveRetornarOkComDetalhes()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/1/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var detalhes = await response.Content.ReadFromJsonAsync<ExercicioDetalhesDto>();
            detalhes.Should().NotBeNull();
            detalhes!.Musculo.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetWithMusculoAndGrupo_DeveRetornarNotFound_QuandoNaoExiste()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/9999/detalhes");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAll_DeveRetornarContentTypeJson()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios");

            // Assert
            response.Content.Headers.ContentType?.MediaType.Should().Be("application/json");
        }

        [Fact]
        public async Task GetById_DeveRetornarExercicioComNomeCorreto()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/1");
            var exercicio = await response.Content.ReadFromJsonAsync<ExercicioDto>();

            // Assert
            exercicio.Should().NotBeNull();
            exercicio!.Nome.Should().Be("Supino Reto com Barra");
        }

        [Fact]
        public async Task GetAll_DeveRetornarExerciciosComDescricao()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios");
            var exercicios = await response.Content.ReadFromJsonAsync<List<ExercicioDto>>();

            // Assert
            exercicios.Should().NotBeNull();
            exercicios!.Should().AllSatisfy(e => e.Descricao.Should().NotBeNullOrEmpty());
        }

        [Fact]
        public async Task GetWithMusculoAndGrupo_DeveRetornarGrupoMuscular()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios/1/detalhes");
            var detalhes = await response.Content.ReadFromJsonAsync<ExercicioDetalhesDto>();

            // Assert
            detalhes.Should().NotBeNull();
            detalhes!.GrupoMuscular.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetAll_DeveRetornarMultiplosExercicios()
        {
            // Act
            var response = await _client.GetAsync("/api/exercicios");
            var exercicios = await response.Content.ReadFromJsonAsync<List<ExercicioDto>>();

            // Assert
            exercicios.Should().NotBeNull();
            exercicios!.Count.Should().BeGreaterThanOrEqualTo(3);
        }
    }
}
