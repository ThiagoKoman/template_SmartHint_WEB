using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHint_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();


app.MapGet("/", () => "Hello World!");

app.MapGet("/api/clientes", async (ApplicationDbContext dbContext) =>
{
    var clientes = await dbContext.Clientes.ToListAsync();
    return Results.Ok(clientes);
});

app.MapPost("/api/clientes", async (Cliente cliente, ApplicationDbContext dbContext) =>
{
    dbContext.Clientes.Add(cliente);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/api/itens/{cliente.id}", cliente);
});

app.MapPut("/api/clientes/{id}", async (int id, Cliente newItem, ApplicationDbContext dbContext) =>
{
    var existingItem = await dbContext.Clientes.FindAsync(id);

    if (existingItem == null)
    {
        return Results.NotFound();
    }

    existingItem.nome = newItem.nome;
    existingItem.email = newItem.email;
    existingItem.telefone = newItem.telefone;
    existingItem.dataCadastro = newItem.dataCadastro;
    existingItem.cpf = newItem.cpf;
    existingItem.cnpj = newItem.cnpj;
    existingItem.inscricaoEstadual = newItem.inscricaoEstadual;
    existingItem.inscricaoEstadualIsento = newItem.inscricaoEstadualIsento;
    existingItem.genero = newItem.genero;
    existingItem.nascimento = newItem.nascimento;
    existingItem.bloqueado = newItem.bloqueado;
    existingItem.senha = newItem.senha;

    await dbContext.SaveChangesAsync();

    return Results.Ok(existingItem);
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});



app.Run();