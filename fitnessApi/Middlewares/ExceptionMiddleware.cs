// Importa as exceções customizadas que criamos (NotFoundException, BadRequestException, etc.)
using fitnessApi.Services.Exceptions;
// Importa o enum HttpStatusCode que contém os códigos HTTP (200, 400, 404, 500, etc.)
using System.Net;
// Importa o JsonSerializer para converter objetos C# em JSON
using System.Text.Json;

namespace fitnessApi.Middlewares
{
    /// <summary>
    /// Middleware responsável por interceptar todas as exceções não tratadas da aplicação
    /// e convertê-las em respostas HTTP padronizadas com status codes apropriados.
    /// </summary>
    public class ExceptionMiddleware
    {
        // Delegate que representa o próximo middleware na pipeline do ASP.NET Core
        // É através dele que a requisição "passa adiante" para os próximos middlewares/controllers
        private readonly RequestDelegate _next;
        
        // Logger para registrar erros no console/arquivo de log
        private readonly ILogger<ExceptionMiddleware> _logger;

        /// <summary>
        /// Construtor - recebe as dependências via injeção de dependência do ASP.NET Core
        /// </summary>
        /// <param name="next">Próximo middleware na pipeline</param>
        /// <param name="logger">Serviço de logging</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Método principal do middleware - é chamado automaticamente para CADA requisição HTTP
        /// </summary>
        /// <param name="context">Contém todas as informações da requisição e resposta HTTP</param>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Tenta executar o próximo middleware (e eventualmente o controller)
                // Se tudo correr bem, a requisição segue normalmente
                await _next(context);
            }
            catch (Exception ex)
            {
                // Se qualquer exceção for lançada em qualquer parte da aplicação,
                // ela é capturada aqui e tratada de forma padronizada
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Método privado que processa a exceção e monta a resposta HTTP apropriada
        /// </summary>
        /// <param name="context">Contexto HTTP para escrever a resposta</param>
        /// <param name="exception">A exceção que foi lançada</param>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Define valores padrão para erro genérico (500 Internal Server Error)
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Ocorreu um erro interno no servidor.";

            // Switch expression para determinar o status code baseado no TIPO da exceção
            // Cada tipo de exceção customizada é mapeada para um status HTTP específico
            switch (exception)
            {
                // Se a exceção for do tipo NotFoundException → retorna 404 Not Found
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = exception.Message; // Usa a mensagem da própria exceção
                    break;

                // Se a exceção for do tipo BadRequestException → retorna 400 Bad Request
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;

                // Se a exceção for do tipo InternalServerErrorException → retorna 500
                case InternalServerErrorException:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    // Loga o erro pois é um erro grave que precisa ser investigado
                    _logger.LogError(exception, "Erro interno: {Message}", exception.Message);
                    break;

                // Para qualquer outra exceção não prevista, mantém 500 e loga
                default:
                    // Loga exceções desconhecidas para investigação posterior
                    _logger.LogError(exception, "Erro não tratado: {Message}", exception.Message);
                    break;
            }

            // Define o tipo de conteúdo da resposta como JSON
            context.Response.ContentType = "application/json";
            
            // Define o status code HTTP da resposta (404, 400, 500, etc.)
            context.Response.StatusCode = (int)statusCode;

            // Cria um objeto anônimo com a estrutura padronizada da resposta de erro
            var response = new
            {
                statusCode = (int)statusCode,  // Ex: 404
                message = message               // Ex: "Exercício com ID 5 não encontrado."
            };

            // Converte o objeto para string JSON
            var jsonResponse = JsonSerializer.Serialize(response);
            
            // Escreve o JSON no corpo da resposta HTTP e envia ao cliente
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
