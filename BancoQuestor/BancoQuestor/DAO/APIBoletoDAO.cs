using BancoQuestor.Contexto;
using BancoQuestor.Entities;

namespace BancoQuestor.DAO
{
    public class APIBoletoDAO
    {
        public async Task<Boleto> AdicionaBoleto(int boleto_id, string nomePagador, string cpfCnpjPagador, string nomebeneficiario,
            string cpfCnpjBeneficiario, decimal valor, DateTime dataVencimento, string observacao, int banco_id, Context context)
        {
            Boleto boleto = new Boleto();
            boleto.Boleto_id = boleto_id;
            boleto.NomePagador = nomePagador;
            boleto.CpfcnpjPagador = cpfCnpjPagador;
            boleto.NomeBeneficiario = nomebeneficiario;
            boleto.CpfcnpjBeneficiario = cpfCnpjBeneficiario;
            boleto.Valor = valor;
            boleto.DataVencimento = dataVencimento;
            boleto.Observacao = observacao;
            boleto.Banco_id = banco_id;

            context.Boleto.Add(boleto);
            await context.SaveChangesAsync();
            return boleto;
        }

        public async Task<Boleto> ListaBoletoPorId(int boleto_id, Context context)
        {
            Boleto boleto = await context.Boleto.FindAsync(boleto_id);
            Banco banco = await new APIBancoDAO().ListaBancoPorId(boleto.Banco_id, context);
            if(banco != null){
                //Banco banco = await context.Banco.FindAsync(boleto.Banco_id);
                if(boleto.DataVencimento < DateTime.Now)
                {
                    var valorJuros = boleto.Valor * (banco.PercentualJuros / 100);
                    boleto.Valor += valorJuros;
                }
            }
            return boleto;
        }
    }
}
