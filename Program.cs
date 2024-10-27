using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
} // tela de erro específica só aparece para desenvolvedores

app.UseDefaultFiles(); // abre no arquivo padrão
app.UseStaticFiles(); // serve o front-end abrindo o que está em wwwroot pelo nome do arquivo
// geralmente coloca-se todo o front-end na pasta wwwroot

app.MapGet("/hello-world", () =>
{
    return Results.Ok(new {
        mensagem = "Hello, World!"
    });
});

// Swashbuckle.AspNetCore

/*
app.Logger.LogInformation("Aplicação iniciada.");
app.Logger.LogWarning("Algo está errado.");
app.Logger.LogError("Ocorreu um erro.");
app.Logger.LogCritical("Dados perdidos.");*/

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

/*
app.MapPost("/", () => "Responde ao método POST");
app.MapPut("/", () => "Responde ao método PUT");
app.MapDelete("/", () => "Responde ao método DELETE");
app.MapPatch("/", () => "Responde ao método PATCH");
app.MapMethods("/", new[] {"PATCH"}, () => "Responde ao método PATCH");*/

// http://localhost:5174/api?x=1&y=2 -- query string 
// app.MapGet("/api", (int x, int y) => $"Recebido: x={x} e y={y}");

// http://localhost:5174/api/2/5 -- route
// app.MapGet("/api/{x}/{y}", (int x, int y) => $"Recebido: x={x} e y={y}");

// app.MapGet("/api/{x}", ([FromRoute] int x, [FromQuery] int y) => $"Recebido: x={x} e y={y}");

// app.MapPost("/api", ([FromBody] DadosEntrada entrada) => $"Recebido: x={entrada.x} e y={entrada.y}"); 

// FromHeader FromServices

app.MapGet("/teste", () => {
    //...
    //...
    /*var resultado = new DadosSaida {
        x = 10,
        y = 2,
    };
    return resultado;*/
    //return new { x = 1, y = "teste" };

    var resultado = new {
        mensagem = "Olá mundo",
    };

    return Results.BadRequest(resultado); // 400
    // return Results.Ok(resultado); -> 200
    // return Results.NotFound(); -> não encontrado
    // return Results.StatusCode(501); -> passa o código manual
});

app.MapGet("/vai-dar-m", () => {
    //...
    throw new ArgumentException("Oops... 💩");
});

app.Logger.LogInformation("Aplicação iniciada.");
app.Run();

public class DadosEntrada{ // DTO - Data Transfer Object
    public int x { get; set; }
    public int y { get; set; }
}
public class DadosSaida{
    public int x { get; set; }
    public int y { get; set; }
}