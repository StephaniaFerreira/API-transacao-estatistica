using System.Runtime.ConstrainedExecution;
using transacao_estatistica.Models;

namespace transacao_estatistica.Service;


public class TransacaoEstatisticaService
{
    private static List<Request> TrasacoesFeitas = new List<Request>();
    public void validarTransacao(Request body)
    {
        validarPreenchimentoObrigatorio(body);
        validarDataHora(body);
        validarValor(body);

        TrasacoesFeitas.Add(body);
    }

    public void deletarTransacoes()
    {
        TrasacoesFeitas.RemoveRange(0,TrasacoesFeitas.Count);
    }

    private void validarPreenchimentoObrigatorio(Request body)
    {
        if (body.valor == 0 && body.dataHora == DateTime.MinValue)
            throw new ApplicationException(Excecoes.VALOR_OU_DATAHORA_NAO_PREENCHIDOS.ToString());
    }

    private void validarDataHora(Request body)
    {
        if (body.dataHora.Date > DateTime.Now.Date)
            throw new ApplicationException(Excecoes.DATAHORA_FUTURA.ToString());
    }

    private void validarValor(Request body)
    {
        if (body.valor < 0)
            throw new ApplicationException(Excecoes.VALOR_NEGATIVO.ToString());
    }
        
        
    
}