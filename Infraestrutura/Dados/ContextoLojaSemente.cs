using Microsoft.Extensions.Logging;

namespace Infraestrutura.Dados
{
    public class ContextoLojaSemente
    {
        public static async Task SeedAsync(ContextoLoja contexto, ILoggerFactory loggerFactory);
    }
}