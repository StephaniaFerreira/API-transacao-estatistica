using System.Runtime.ConstrainedExecution;
using transacao_estatistica.Models;

namespace transacao_estatistica.Service;


public class TransacaoEstatisticaService
{
    private static double DIFERENCA_SEGUNDO = 60;
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
        TrasacoesFeitas.RemoveRange(0, TrasacoesFeitas.Count);
    }

    public Estatistica GetEstatistica()
    {
        //converter a diferença de segundo para minuto
        double Diferenca_minutos = DIFERENCA_SEGUNDO / 60; 
        Estatistica estatistica = new Estatistica();
        List<Request> transacoesSelecionadas = TrasacoesFeitas.Where(p => (DateTime.Now - p.dataHora).TotalMinutes <= Diferenca_minutos)
                                                    .ToList();
        estatistica.count = transacoesSelecionadas.Count;
        estatistica.sum = sum(transacoesSelecionadas);
        estatistica.avg = avg(estatistica.sum, estatistica.count);
        estatistica.min = min(transacoesSelecionadas);
        estatistica.max = max(transacoesSelecionadas);

        return estatistica;
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
    private decimal sum(List<Request> TrasacoesFeitas)
    {
        decimal soma = 0;
        for (int i = 0; i < TrasacoesFeitas.Count; i++)
        {
            soma += TrasacoesFeitas[i].valor;
        }
        return soma;
    }
    private decimal avg(decimal sum, int count)
    {
        decimal media = Math.Round(sum / count, 3);

        return media;
    }
    private decimal min(List<Request> TrasacoesFeitas)
    {
        decimal min = TrasacoesFeitas.Min(p => p.valor);
        return min;
    }
    private decimal max(List<Request> TrasacoesFeitas)
    {
        decimal max = TrasacoesFeitas.Max(p => p.valor);
        return max;
    }
}




