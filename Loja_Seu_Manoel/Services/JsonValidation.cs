using System.Text;
using System.Text.Json;

public class JsonValidation
{
    private readonly RequestDelegate _next;

    public JsonValidation(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentType?.Contains("application/json") == true &&
            context.Request.Method == HttpMethods.Post)
        {
            context.Request.EnableBuffering();
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
            var errors = new Dictionary<string, string>();

            try
            {
                using var document = JsonDocument.Parse(body);
                if (document.RootElement.TryGetProperty("pedidos", out var pedidosElement) &&
                    pedidosElement.ValueKind == JsonValueKind.Array)
                {
                    for (int i = 0; i < pedidosElement.GetArrayLength(); i++)
                    {
                        var pedido = pedidosElement[i];

                        if (pedido.TryGetProperty("produtos", out var produtos) &&
                            produtos.ValueKind == JsonValueKind.Array)
                        {
                            for (int j = 0; j < produtos.GetArrayLength(); j++)
                            {
                                var produto = produtos[j];
                                if (produto.TryGetProperty("dimensoes", out var dimensoes))
                                {
                                    ValidaInteger(dimensoes, "altura", $"pedidos[{i}].produtos[{j}].dimensoes.altura", errors);
                                    ValidaInteger(dimensoes, "largura", $"pedidos[{i}].produtos[{j}].dimensoes.largura", errors);
                                    ValidaInteger(dimensoes, "comprimento", $"pedidos[{i}].produtos[{j}].dimensoes.comprimento", errors);
                                }
                            }
                        }
                    }
                }
            }
            catch (JsonException ex)
            {
                errors.Add("json", $"Erro no arquivo JSON: {ex.Message}");
            }

            if (errors.Count > 0)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = JsonSerializer.Serialize(new { errors });
                await context.Response.WriteAsync(response);
                return;
            }
        }
        await _next(context);
    }
    private void ValidaInteger(JsonElement parent, string field, string path, Dictionary<string, string> errors)
    {
        if (parent.TryGetProperty(field, out var element))
        {
            if (element.ValueKind != JsonValueKind.Number || !element.TryGetInt32(out _))
            {
                errors[path] = "Esperado tipo Integer, mas recebeu outro tipo.";
            }
        }
        else
        {
            errors[path] = "Campo obrigatório ausente.";
        }
    }
}