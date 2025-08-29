using Microsoft.AspNetCore.Mvc;
using transacao_estatistica.Models;
using transacao_estatistica.Service;

namespace transacao_estatistica.Controllers;

[ApiController]
[Route("api/")]
public class TransacaoEstatisticaController : ControllerBase
{

    [HttpPost("POST/transacao")]
    public IActionResult CriarTransacao([FromBody] Request body)
    {
        TransacaoEstatisticaService service = new TransacaoEstatisticaService();
        try
        {
            service.validarTransacao(body);

        }
        catch (ApplicationException e)
        {
            if (e.Message.Equals(Excecoes.VALOR_OU_DATAHORA_NAO_PREENCHIDOS.ToString()) ||
                e.Message.Equals(Excecoes.DATAHORA_FUTURA.ToString()) ||
                e.Message.Equals(Excecoes.VALOR_NEGATIVO.ToString()))
                return UnprocessableEntity();
        }
        catch (Exception e)
        {
            return BadRequest();
        }


        return Created("/transacao", "Transacao Criada com Sucesso!");
    }
    
    [HttpDelete("DELETE/transacao")]
    public IActionResult DeletarTransacao()
    {
        TransacaoEstatisticaService service = new TransacaoEstatisticaService();
        try
        {
            service.deletarTransacoes();

        }
        catch (Exception e)
        { 
            return BadRequest();
        }

        
        return Ok();
    }
}
