using BancoQuestor.Contexto;
using BancoQuestor.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoQuestor.DAO
{
    public class APIBancoDAO
    {
        public async Task<Banco> SalvarBanco(int banco_id, string nomeBanco, int codigoBanco, decimal percentualJuros, Context context)
        {
            Banco banco = new Banco();
            banco.Banco_id = banco_id;
            banco.NomeBanco = nomeBanco;
            banco.CodigoBanco = codigoBanco;
            banco.PercentualJuros = percentualJuros;
            context.Banco.Add(banco);
            await context.SaveChangesAsync();
            return banco;
        }

        public async Task<List<Banco>> ListaBancos(Context context)
        {
            var listaBancos = await context.Banco.ToListAsync();
            return listaBancos;
        }

        public async Task<Banco> ListaBancoPorId(int banco_id, Context context)
        {
            return await context.Banco.FindAsync(banco_id);
        }
    }
}
