# Fitness API 💪

API REST para gerenciamento de exercícios físicos, músculos e grupos musculares.

## 🎯 Objetivo

Esta API foi desenvolvida para fornecer informações sobre exercícios físicos, seus músculos trabalhados e grupos musculares relacionados. Ideal para aplicações de fitness, academias e apps de treino.

## 🚀 Tecnologias

| Tecnologia | Versão | Descrição |
|------------|--------|-----------|
| .NET | 8.0 | Framework principal |
| ASP.NET Core | 8.0 | Framework web |
| Entity Framework Core | 8.0 | ORM para acesso a dados |
| SQL Server (Azure SQL Edge) | Latest | Banco de dados |
| Docker | - | Containerização do banco |
| Swagger | 6.6.2 | Documentação da API |
| xUnit | 2.6.6 | Framework de testes |
| Moq | 4.20.72 | Mocking para testes |
| FluentAssertions | 6.12.0 | Assertions legíveis |

## 📁 Estrutura do Projeto

```
FitnessAPI/
├── fitnessApi/
│   ├── Controllers/          # Endpoints da API
│   ├── Models/
│   │   ├── DTOs/            # Data Transfer Objects
│   │   ├── Entities/        # Entidades do banco
│   │   └── Events/          # Eventos de domínio
│   ├── Repository/          # Camada de acesso a dados
│   ├── Services/            # Regras de negócio
│   └── Middlewares/         # Tratamento de exceções
├── FitnessApi.Tests/
│   ├── UnitTests/           # Testes unitários (Services)
│   └── IntegrationTests/    # Testes de integração (Controllers)
└── docker-compose.yml       # Configuração do banco de dados
```

## 🔧 Configuração

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)

### 1. Iniciar o Banco de Dados

```bash
docker-compose up -d
```

Isso irá iniciar o SQL Server (Azure SQL Edge) na porta `1433`.

### 2. Executar a API

```bash
cd fitnessApi
dotnet run
```

A API estará disponível em: `http://localhost:5140`

### 3. Acessar a Documentação (Swagger)

Abra no navegador: `http://localhost:5140/swagger`

## 📡 Rotas da API

### Exercícios (`/api/exercicios`)

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/exercicios` | Lista todos os exercícios |
| GET | `/api/exercicios/{id}` | Retorna um exercício pelo ID |
| GET | `/api/exercicios/{id}/detalhes` | Retorna exercício com músculo e grupo muscular |

**Exemplo de resposta** (`GET /api/exercicios/1`):
```json
{
  "id": 1,
  "nome": "Supino Reto com Barra",
  "descricao": "Exercício para peitoral maior"
}
```

**Exemplo de resposta detalhada** (`GET /api/exercicios/1/detalhes`):
```json
{
  "id": 1,
  "nome": "Supino Reto com Barra",
  "descricao": "Exercício para peitoral maior",
  "musculo": "Peitoral Maior",
  "grupoMuscular": "Peito"
}
```

---

### Grupos Musculares (`/api/grupos`)

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/grupos` | Lista todos os grupos musculares |
| GET | `/api/grupos/{id}` | Retorna um grupo muscular pelo ID |
| GET | `/api/grupos/{id}/detalhes` | Retorna grupo com lista de músculos |

**Exemplo de resposta** (`GET /api/grupos/1`):
```json
{
  "id": 1,
  "nome": "Peito",
  "descricao": "Grupo muscular peitoral"
}
```

**Exemplo de resposta detalhada** (`GET /api/grupos/1/detalhes`):
```json
{
  "id": 1,
  "nome": "Peito",
  "descricao": "Grupo muscular peitoral",
  "musculos": [
    {
      "id": 1,
      "nome": "Peitoral Maior",
      "movimentoPrincipal": "Flexão horizontal",
      "funcao": "Adução do braço"
    }
  ]
}
```

---

### Músculos (`/api/musculos`)

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/musculos` | Lista todos os músculos |
| GET | `/api/musculos/{id}` | Retorna um músculo pelo ID |
| GET | `/api/musculos/{id}/detalhes` | Retorna músculo com grupo e exercícios |

**Exemplo de resposta** (`GET /api/musculos/1`):
```json
{
  "id": 1,
  "nome": "Peitoral Maior",
  "movimentoPrincipal": "Flexão horizontal",
  "funcao": "Adução do braço"
}
```

**Exemplo de resposta detalhada** (`GET /api/musculos/1/detalhes`):
```json
{
  "id": 1,
  "nome": "Peitoral Maior",
  "movimentoPrincipal": "Flexão horizontal",
  "funcao": "Adução do braço",
  "tipoTecido": "Estriado esquelético",
  "fibraMuscular": "Mista",
  "grupoMuscular": "Peito",
  "exercicios": [
    {
      "id": 1,
      "nome": "Supino Reto com Barra",
      "descricao": "Exercício para peitoral maior"
    }
  ]
}
```

## 🧪 Testes

O projeto inclui **69 testes** automatizados:

- **42 Testes Unitários** - Validam os Services
- **30 Testes de Integração** - Validam os endpoints HTTP

### Executar os Testes

```bash
dotnet test
```

### Estrutura de Testes

| Camada | Arquivo | Testes |
|--------|---------|--------|
| Service | ExercicioServiceTests | 14 |
| Service | GrupoMuscularServiceTests | 14 |
| Service | MusculoServiceTests | 14 |
| Controller | ExerciciosControllerIntegrationTests | 10 |
| Controller | GruposControllerIntegrationTests | 10 |
| Controller | MusculosControllerIntegrationTests | 10 |

### Diagrama de Entidades

```
┌─────────────────┐      ┌─────────────────┐      ┌─────────────────┐
│ GrupoMuscular   │      │    Musculos     │      │   Exercicios    │
├─────────────────┤      ├─────────────────┤      ├─────────────────┤
│ Id              │◄────┐│ Id              │◄────┐│ Id              │
│ NomeGrupoMuscular│     ││ NomeMusculo     │     ││ NomeExercicio   │
│ DescricaoGrupo  │     ││ MovimentoPrincipal│   ││ DescricaoExercicio│
└─────────────────┘     ││ Funcao          │     ││ MusculoId (FK)  │──┘
                        ││ TipoTecido      │     │└─────────────────┘
                        ││ FibraMuscular   │     │
                        ││ GrupoMuscularId │─────┘
                        │└─────────────────┘
                        │        1:N
                        └────────────────────
```

## 📝 Licença

Este projeto foi desenvolvido no intuito de publicar essa API para estudos.

---

Desenvolvido utilizando .NET 8.0
