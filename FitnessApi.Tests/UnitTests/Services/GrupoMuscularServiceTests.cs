using fitnessApi.Models.Entities;
using fitnessApi.Repository.GrupoMuscularRepository;
using fitnessApi.Services.GrupoMuscularService;
using fitnessApi.Services.Exceptions;
using FluentAssertions;
using Moq;

namespace FitnessApi.Tests.UnitTests.Services
{
    public class GrupoMuscularServiceTests
    {
        private readonly Mock<IGrupoMuscularRepository> _repositoryMock;
        private readonly GrupoMuscularService _service;

        public GrupoMuscularServiceTests()
        {
            _repositoryMock = new Mock<IGrupoMuscularRepository>();
            _service = new GrupoMuscularService(_repositoryMock.Object);
        }

        #region GetAll Tests

        [Fact]
        public void GetAll_DeveRetornarListaDeGrupos()
        {
            // Arrange
            var grupos = new List<GrupoMuscular>
            {
                new GrupoMuscular(1, "Peito", "Grupo peitoral", new List<Musculos>()),
                new GrupoMuscular(2, "Costas", "Grupo dorsal", new List<Musculos>())
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(grupos);

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(grupos);
        }

        [Fact]
        public void GetAll_DeveRetornarListaVazia_QuandoNaoExistemGrupos()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<GrupoMuscular>());

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region GetById Tests

        [Fact]
        public void GetById_DeveRetornarGrupo_QuandoExiste()
        {
            // Arrange
            var grupo = new GrupoMuscular(1, "Peito", "Grupo peitoral", new List<Musculos>());
            _repositoryMock.Setup(r => r.GetById(1)).Returns(grupo);

            // Act
            var result = _service.GetById(1);

            // Assert
            result.Should().BeEquivalentTo(grupo);
        }

        [Fact]
        public void GetById_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetById(999)).Returns((GrupoMuscular?)null);

            // Act
            var act = () => _service.GetById(999);

            // Assert
            act.Should().Throw<NotFoundException>()
                .WithMessage("*999*");
        }

        #endregion

        #region Add Tests

        [Fact]
        public void Add_DeveAdicionarGrupo_QuandoDadosValidos()
        {
            // Arrange
            var grupo = new GrupoMuscular(0, "Peito", "Grupo peitoral", new List<Musculos>());
            var grupoCriado = new GrupoMuscular(1, "Peito", "Grupo peitoral", new List<Musculos>());
            _repositoryMock.Setup(r => r.Add(grupo)).Returns(grupoCriado);

            // Act
            var result = _service.Add(grupo);

            // Assert
            result.Should().BeEquivalentTo(grupoCriado);
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeVazio()
        {
            // Arrange
            var grupo = new GrupoMuscular(0, "", "Descrição", new List<Musculos>());

            // Act
            var act = () => _service.Add(grupo);

            // Assert
            act.Should().Throw<BadRequestException>()
                .WithMessage("*Nome do grupo muscular*");
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeNull()
        {
            // Arrange
            var grupo = new GrupoMuscular(0, null, "Descrição", new List<Musculos>());

            // Act
            var act = () => _service.Add(grupo);

            // Assert
            act.Should().Throw<BadRequestException>();
        }

        #endregion

        #region Update Tests

        [Fact]
        public void Update_DeveAtualizarGrupo_QuandoExiste()
        {
            // Arrange
            var grupoExistente = new GrupoMuscular(1, "Peito", "Descrição", new List<Musculos>());
            var grupoAtualizado = new GrupoMuscular(1, "Peitoral", "Nova Descrição", new List<Musculos>());
            
            _repositoryMock.Setup(r => r.GetById(1)).Returns(grupoExistente);
            _repositoryMock.Setup(r => r.Update(grupoAtualizado, 1)).Returns(grupoAtualizado);

            // Act
            var result = _service.Update(grupoAtualizado, 1);

            // Assert
            result.Should().BeEquivalentTo(grupoAtualizado);
        }

        [Fact]
        public void Update_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            var grupo = new GrupoMuscular(999, "Peito", "Descrição", new List<Musculos>());
            _repositoryMock.Setup(r => r.GetById(999)).Returns((GrupoMuscular?)null);

            // Act
            var act = () => _service.Update(grupo, 999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region Delete Tests

        [Fact]
        public void Delete_DeveDeletarGrupo_QuandoExiste()
        {
            // Arrange
            var grupo = new GrupoMuscular(1, "Peito", "Descrição", new List<Musculos>());
            _repositoryMock.Setup(r => r.GetById(1)).Returns(grupo);
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
            _repositoryMock.Setup(r => r.GetById(999)).Returns((GrupoMuscular?)null);

            // Act
            var act = () => _service.Delete(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region GetWithMusculos Tests

        [Fact]
        public void GetWithMusculos_DeveRetornarGrupoComMusculos()
        {
            // Arrange
            var musculos = new List<Musculos>
            {
                new Musculos(1, "Peitoral Maior", "Flexão", "Adução", "Estriado", 1, "Mista", new List<Exercicios>()),
                new Musculos(2, "Peitoral Menor", "Estabilização", "Depressão", "Estriado", 1, "Lenta", new List<Exercicios>())
            };
            var grupo = new GrupoMuscular(1, "Peito", "Grupo peitoral", musculos);
            
            _repositoryMock.Setup(r => r.GetWithMusculos(1)).Returns(grupo);

            // Act
            var result = _service.GetWithMusculos(1);

            // Assert
            result.Should().NotBeNull();
            result.Musculos.Should().HaveCount(2);
        }

        [Fact]
        public void GetWithMusculos_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetWithMusculos(999)).Returns((GrupoMuscular?)null);

            // Act
            var act = () => _service.GetWithMusculos(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion
    }
}
