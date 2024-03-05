using BancoQuestor.Contexto;
using BancoQuestor.DAO;
using BancoQuestor.Entities;
using Evolution.Model.Model.Static;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Context>
    (option =>
    option.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=BancoQuestor2;User Id=postgres;Password=1234;"));


builder.Services.AddSwaggerGen();

var app = builder.Build();

//Banco EndPoints
app.MapPost("AdicionaBanco", async (int banco_id, string nomeBanco, int codigoBanco, decimal percentualJuros, Context context) =>
{
    return await new APIBancoDAO().SalvarBanco(banco_id, nomeBanco, codigoBanco, percentualJuros, context);
});

app.MapGet("ListaBancos", async (Context context) =>
{
    return await new APIBancoDAO().ListaBancos(context);
});

app.MapGet("ListaBancoPorId", async (int banco_id, Context context) =>
{
    return await new APIBancoDAO().ListaBancoPorId(banco_id, context);
});

//Boleto EndPoints
app.MapPost("AdicionaBoleto", async (int boleto_id, string nomePagador, string cpfCnpjPagador, string nomebeneficiario,
    string cpfCnpjBeneficiario, decimal valor, DateTime dataVencimento, string? observacao, int banco_id, Context context) =>
{
    dataVencimento.AddDays(2);
    return await new APIBoletoDAO().AdicionaBoleto(boleto_id, nomePagador, cpfCnpjPagador, nomebeneficiario, cpfCnpjBeneficiario,
        valor, dataVencimento, observacao, banco_id, context);
});

app.MapGet("ListaBoletoPorId", async (int boleto_id, Context context) =>
{
    return await new APIBoletoDAO().ListaBoletoPorId(boleto_id, context);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
