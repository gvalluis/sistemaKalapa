using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.Extensions.Logging;

namespace Infraestrutura.Dados
{
    public class ContextoLojaSemear
    {
        public static async Task SemearAsync(ContextoLoja contexto, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!contexto.CategoriaProduto.Any())
                {
                    var categoriaDados = File.ReadAllText("../Infraestrutura/Dados/DadosSemear/categorias.json");

                    var categorias = JsonSerializer.Deserialize<List<CategoriaProduto>>(categoriaDados);

                    foreach (var item in categorias)
                    {
                        contexto.CategoriaProduto.Add(item);
                    }

                    await contexto.SaveChangesAsync();


                }

                if (!contexto.TipoProdutos.Any())
                {
                    var tipoDados = File.ReadAllText("../Infraestrutura/Dados/DadosSemear/tipos.json");

                    var tipos = JsonSerializer.Deserialize<List<TipoProduto>>(tipoDados);

                    foreach (var item in tipos)
                    {
                        contexto.TipoProdutos.Add(item);
                    }

                    await contexto.SaveChangesAsync();
                }

                if (!contexto.Produtos.Any())
                {
                    var produtoDados = File.ReadAllText("../Infraestrutura/Dados/DadosSemear/tipos.json");

                    var produtos = JsonSerializer.Deserialize<List<Produto>>(produtoDados);

                    foreach (var item in produtos)
                    {
                        contexto.Produtos.Add(item);
                    }

                    await contexto.SaveChangesAsync();
                }

            } catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<ContextoLojaSemear>();
                logger.LogError(ex.Message);
            }
        }
    }
}
