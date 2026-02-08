using fitnessApi.Models.Entities;
using fitnessApi.Repository.MusculosRepository;
using fitnessApi.Services.MusculoService;
using fitnessApi.Services.Exceptions;
using FluentAssertions;
using Moq;

namespace FitnessApi.Tests.UnitTests.Services
{
    public class MusculoServiceTests
    {
        private readonly Mock<IMusculoRepository> _repositoryMock;
        private readonly MusculoService _service;

        public MusculoServiceTests()
        {
            _repositoryMock = new Mock<IMusculoRepository>();
            _service = new MusculoService(_repositoryMock.Object);
        }

        #region GetAll Tests

        [Fact]
        public void GetAll_DeveRetornarListaDeMusculos()
        {
            // Arrange
            var musculos = new List<Musculos>
            {
                new Musculos(1, "Bíceps", "Flexão", "Flexão do cotovelo", "Estriado", 1, "Mista", new List<Exercicios>()),
                new Musculos(2, "Tríceps", "Extensão", "Extensão do cotovelo", "Estriado", 1, "Rápida", new List<Exercicios>())
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(musculos);

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(musculos);
        }

        [Fact]
        public void GetAll_DeveRetornarListaVazia_QuandoNaoExistemMusculos()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<Musculos>());

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region GetById Tests

        [Fact]
        public void GetById_DeveRetornarMusculo_QuandoExiste()
        {
            // Arrange
            var musculo = new Musculos(1, "Bíceps", "Flexão", "Flexão do cotovelo", "Estriado", 1, "Mista", new List<Exercicios>());
            _repositoryMock.Setup(r => r.GetById(1)).Returns(musculo);

            // Act
            var result = _service.GetById(1);

            // Assert
            result.Should().BeEquivalentTo(musculo);
        }

        [Fact]
        public void GetById_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Musculos?)null);

            // Act
            var act = () => _service.GetById(999);

            // Assert
            act.Should().Throw<NotFoundException>()
                .WithMessage("*999*");
        }

        #endregion

        #region Add Tests

        [Fact]
        public void Add_DeveAdicionarMusculo_QuandoDadosValidos()
        {
            // Arrange
            var musculo = new Musculos(0, "Bíceps", "Flexão", "Flexão do cotovelo", "Estriado", 1, "Mista", new List<Exercicios>());
            var musculoCriado = new Musculos(1, "Bíceps", "Flexão", "Flexão do cotovelo", "Estriado", 1, "Mista", new List<Exercicios>());
            _repositoryMock.Setup(r => r.Add(musculo)).Returns(musculoCriado);

            // Act
            var result = _service.Add(musculo);

            // Assert
            result.Should().BeEquivalentTo(musculoCriado);
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeVazio()
        {
            // Arrange
            var musculo = new Musculos(0, "", "Flexão", "Função", "Estriado", 1, "Mista", new List<Exercicios>());

            // Act
            var act = () => _service.Add(musculo);

            // Assert
            act.Should().Throw<BadRequestException>()
                .WithMessage("*Nome do músculo*");
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeNull()
        {
            // Arrange
            var musculo = new Musculos(0, null, "Flexão", "Função", "Estriado", 1, "Mista", new List<Exercicios>());

            // Act
            var act = () => _service.Add(musculo);

            // Assert
            act.Should().Throw<BadRequestException>();
        }

        #endregion

        #region Update Tests

        [Fact]
        public void Update_DeveAtualizarMusculo_QuandoExiste()
        {
            // Arrange
            var musculoExistente = new Musculos(1, "Bíceps", "Flexão", "Função", "Estriado", 1, "Mista", new List<Exercicios>());
            var musculoAtualizado = new Musculos(1, "Bíceps Braquial", "Flexão", "Nova Função", "Estriado", 1, "Mista", new List<Exercicios>());
            
            _repositoryMock.Setup(r => r.GetById(1)).Returns(musculoExistente);
            _repositoryMock.Setup(r => r.Update(musculoAtualizado, 1)).Returns(musculoAtualizado);

            // Act
            var result = _service.Update(musculoAtualizado, 1);

            // Assert
            result.Should().BeEquivalentTo(musculoAtualizado);
        }

        [Fact]
        public void Update_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            var musculo = new Musculos(999, "Bíceps", "Flexão", "Função", "Estriado", 1, "Mista", new List<Exercicios>());
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Musculos?)null);

            // Act
            var act = () => _service.Update(musculo, 999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region Delete Tests

        [Fact]
        public void Delete_DeveDeletarMusculo_QuandoExiste()
        {
            // Arrange
            var musculo = new Musculos(1, "Bíceps", "Flexão", "Função", "Estriado", 1, "Mista", new List<Exercicios>());
            _repositoryMock.Setup(r => r.GetById(1)).Returns(musculo);
            _repositoryMock.Setup(r => r.Delete(1));

            // Act
            _service.Delete(1);

            // Assert
            _repositoryMock.Verify(r => r.Delete(1), Times.Once);
        }

        [Fact]
        public void Delete_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Musculos?)null);

            // Act
            var act = () => _service.Delete(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region GetWithGrupoAndExercicios Tests

        [Fact]
        public void GetWithGrupoAndExercicios_DeveRetornarMusculoComRelacionamentos()
        {
            // Arrange
            var grupo = new GrupoMuscular(1, "Braço", "Grupo dos braços", new List<Musculos>());
            var exercicios = new List<Exercicios>
            {
                new Exercicios(1, "Rosca Direta", "Exercício de bíceps", 1),
                new Exercicios(2, "Rosca Martelo", "Exercício de bíceps", 1)
            };
            var musculo = new Musculos(1, "Bíceps", "Flexão", "Flexão do cotovelo", "Estriado", 1, "Mista", exercicios)
            {
                GrupoMuscular = grupo
            };
            
            _repositoryMock.Setup(r => r.GetWithGrupoAndExercicios(1)).Returns(musculo);

            // Act
            var result = _service.GetWithGrupoAndExercicios(1);

            // Assert
            result.Should().NotBeNull();
            result.GrupoMuscular.Should().NotBeNull();
            result.Exercicios.Should().HaveCount(2);
        }

        [Fact]
        public void GetWithGrupoAndExercicios_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetWithGrupoAndExercicios(999)).Returns((Musculos?)null);

            // Act
            var act = () => _service.GetWithGrupoAndExercicios(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion
    }
}
