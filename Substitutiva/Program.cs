var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//cadastro
app.MapPost("/api/imc/cadastrar", (ImcRequest req) =>
{
    if (req.Altura <= 0 || req.Peso <= 0)
    {
        return Results.BadRequest("altura e peso devem ser positivos.");
    }

    double imc = ImcService.CalcularImc(req.Peso, req.Altura);
    string classificacao = ImcService.Classificar(imc);

    var registro = new ImcRegistro
    {
        Id = ++Banco.UltimoId,
        Nome = req.Nome,
        Altura = req.Altura,
        Peso = req.Peso,
        Imc = imc,
        Classificacao = classificacao,
        DataCriacao = DateTime.Now
    };

    Banco.Registros.Add(registro);

    return Results.Created($"/api/imc/{registro.Id}", new { registro.Id });
});

//listar
app.MapGet("/api/imc/listar", () =>
{
    return Results.Ok(Banco.Registros);
});


//lsitar por classificaçao
app.MapGet("/api/imc/listarporstatus/{classificacao}", ([FromRoute] string Classificacao,
    [FromServices] AppDbContext ctx) =>
{
    IMCdados? resultado = ctx.IMCdados.Find(Classificacao);
    if (resultado is null)
    {
        return Results.NotFound("nao encontrado");
    }
    return Results.Ok(resultado);
});



//:(


app.Run();