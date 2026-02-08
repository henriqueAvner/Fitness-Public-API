using fitnessApi.Models.Entities;
using fitnessApi.Repository.ExercicioRepository;
using fitnessApi.Services.ExercicioService;
using fitnessApi.Services.Exceptions;
using FluentAssertions;
using Moq;

namespace FitnessApi.Tests.UnitTests.Services
{
    public class ExercicioServiceTests
    {
        private readonly Mock<IExercicioRepository> _repositoryMock;
        private readonly ExercicioService _service;

        public ExercicioServiceTests()
        {
            _repositoryMock = new Mock<IExercicioRepository>();
            _service = new ExercicioService(_repositoryMock.Object);
        }

        #region GetAll Tests

        [Fact]
        public void GetAll_DeveRetornarListaDeExercicios()
        {
            // Arrange
            var exercicios = new List<Exercicios>
            {
                new Exercicios(1, "Supino", "Exercício de peito", 1),
                new Exercicios(2, "Agachamento", "Exercício de perna", 2)
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(exercicios);

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(exercicios);
            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public void GetAll_DeveRetornarListaVazia_QuandoNaoExistemExercicios()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetAll()).Returns(new List<Exercicios>());

            // Act
            var result = _service.GetAll();

            // Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region GetById Tests

        [Fact]
        public void GetById_DeveRetornarExercicio_QuandoExiste()
        {
            // Arrange
            var exercicio = new Exercicios(1, "Supino", "Exercício de peito", 1);
            _repositoryMock.Setup(r => r.GetById(1)).Returns(exercicio);

            // Act
            var result = _service.GetById(1);

            // Assert
            result.Should().BeEquivalentTo(exercicio);
            _repositoryMock.Verify(r => r.GetById(1), Times.Once);
        }

        [Fact]
        public void GetById_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Exercicios?)null);

            // Act
            var act = () => _service.GetById(999);

            // Assert
            act.Should().Throw<NotFoundException>()
                .WithMessage("*999*");
        }

        #endregion

        #region Add Tests

        [Fact]
        public void Add_DeveAdicionarExercicio_QuandoDadosValidos()
        {
            // Arrange
            var exercicio = new Exercicios(0, "Supino", "Exercício de peito", 1);
            var exercicioCriado = new Exercicios(1, "Supino", "Exercício de peito", 1);
            _repositoryMock.Setup(r => r.Add(exercicio)).Returns(exercicioCriado);

            // Act
            var result = _service.Add(exercicio);

            // Assert
            result.Should().BeEquivalentTo(exercicioCriado);
            _repositoryMock.Verify(r => r.Add(exercicio), Times.Once);
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeVazio()
        {
            // Arrange
            var exercicio = new Exercicios(0, "", "Descrição", 1);

            // Act
            var act = () => _service.Add(exercicio);

            // Assert
            act.Should().Throw<BadRequestException>()
                .WithMessage("*Nome do exercício*");
        }

        [Fact]
        public void Add_DeveLancarBadRequestException_QuandoNomeNull()
        {
            // Arrange
            var exercicio = new Exercicios(0, null, "Descrição", 1);

            // Act
            var act = () => _service.Add(exercicio);

            // Assert
            act.Should().Throw<BadRequestException>();
        }

        #endregion

        #region Update Tests

        [Fact]
        public void Update_DeveAtualizarExercicio_QuandoExiste()
        {
            // Arrange
            var exercicioExistente = new Exercicios(1, "Supino", "Descrição", 1);
            var exercicioAtualizado = new Exercicios(1, "Supino Inclinado", "Nova Descrição", 1);
            
            _repositoryMock.Setup(r => r.GetById(1)).Returns(exercicioExistente);
            _repositoryMock.Setup(r => r.Update(exercicioAtualizado, 1)).Returns(exercicioAtualizado);

            // Act
            var result = _service.Update(exercicioAtualizado, 1);

            // Assert
            result.Should().BeEquivalentTo(exercicioAtualizado);
        }

        [Fact]
        public void Update_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            var exercicio = new Exercicios(999, "Supino", "Descrição", 1);
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Exercicios?)null);

            // Act
            var act = () => _service.Update(exercicio, 999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region Delete Tests

        [Fact]
        public void Delete_DeveDeletarExercicio_QuandoExiste()
        {
            // Arrange
            var exercicio = new Exercicios(1, "Supino", "Descrição", 1);
            _repositoryMock.Setup(r => r.GetById(1)).Returns(exercicio);
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
            _repositoryMock.Setup(r => r.GetById(999)).Returns((Exercicios?)null);

            // Act
            var act = () => _service.Delete(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion

        #region GetWithMusculoAndGrupo Tests

        [Fact]
        public void GetWithMusculoAndGrupo_DeveRetornarExercicioComRelacionamentos()
        {
            // Arrange
            var grupo = new GrupoMuscular(1, "Peito", "Grupo peitoral", new List<Musculos>());
            var musculo = new Musculos(1, "Peitoral Maior", "Flexão", "Adução", "Estriado", 1, "Mista", new List<Exercicios>())
            {
                GrupoMuscular = grupo
            };
            var exercicio = new Exercicios(1, "Supino", "Exercício de peito", 1)
            {
                Musculos = musculo
            };
            
            _repositoryMock.Setup(r => r.GetWithMusculoAndGrupo(1)).Returns(exercicio);

            // Act
            var result = _service.GetWithMusculoAndGrupo(1);

            // Assert
            result.Should().NotBeNull();
            result.Musculos.Should().NotBeNull();
            result.Musculos.GrupoMuscular.Should().NotBeNull();
        }

        [Fact]
        public void GetWithMusculoAndGrupo_DeveLancarNotFoundException_QuandoNaoExiste()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetWithMusculoAndGrupo(999)).Returns((Exercicios?)null);

            // Act
            var act = () => _service.GetWithMusculoAndGrupo(999);

            // Assert
            act.Should().Throw<NotFoundException>();
        }

        #endregion
    }
}
