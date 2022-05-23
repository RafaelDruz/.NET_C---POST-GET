using Microsoft.EntityFrameworkCore;
using WebApiTest.Descricao;
using WebApiTest.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Descricao>
    (options => options.UseMySql(
        "server=localhost;initial catalog=contato;uid=root;pwd=*****",
         Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("Adiciona", async (Contato contato, Descricao descricao) =>
{
    descricao.Contato.Add(contato);
    await descricao.SaveChangesAsync();
});

app.MapPost("Listar", async (Descricao descricao) =>
{
    return await descricao.Contato.ToListAsync();
});

app.UseSwaggerUI();
app.Run();