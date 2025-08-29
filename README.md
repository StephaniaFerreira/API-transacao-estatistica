# API-transacao-estatistica

Desafio de Backend do Itau encontrado no ![GitHUb](https://github.com/feltex/desafio-itau-backend). 

## Definição do Desafio

>Neste desafio você deve criar uma API REST no GitHub ou GitLab. Leia com atenção todas as instruções a seguir!
>
> ## 2.1. Restrições Técnicas
>Seu projeto:
>
>   - DEVE estar no GitHub ou GitLab
>   - NÃO DEVE fazer fork de nenhum outro projeto
>   - DEVE ter pelo menos 1 commit por cada endpoint (mínimo de 3 commits)
>   Queremos ver a evolução do seu projeto com o tempo ;)
>   Todos os commits DEVEM ser feitos pelo mesmo usuário que criou o projeto
>   Entendemos que algumas pessoas tem usuários pessoais e profissionais, ou um usuário diferente usado para   estudar. Atenção com isso se você for uma dessas pessoas!
>   - DEVE seguir exatamente os endpoints descritos a seguir
>   Por exemplo, /transacao não é a mesma coisa que /transacoes
>   - DEVE aceitar e responder com objetos exatamente como descritos a seguir
>   Por exemplo, dataHora não é a mesma coisa que data-hora ou dtTransacao
>   - NÃO DEVE utilizar quaisquer sistemas de banco de dados (como H2, MySQL, PostgreSQL, ...) ou cache (como Redis, Memcached, Infinispan, ...)
>   - DEVE armazenar todos os dados em memória
>   - DEVE aceitar e responder apenas com JSON
>   Atenção! Por motivos de segurança, não podemos aceitar projetos enviados como arquivos. Você DEVE disponibilizar seu projeto publicamente para que possamos acessá-lo e corrigi-lo! Após receber uma resposta de nós, sinta-se livre para tornar seu projeto privado :)
>
>## 2.2. Endpoints da API
>A seguir serão especificados os endpoints que devem estar presentes na sua API e a funcionalidade esperada de cada um deles.
>
>## 2.2.1. Receber Transações: POST /transacao
>Este é o endpoint que irá receber as Transações. Cada transação consiste de um valor e uma dataHora de quando ela aconteceu:
>```json
>{
>    "valor": 123.45,
>    "dataHora": "2020-08-07T12:34:56.789-03:00"
>}
>
>Os campos no JSON acima significam o seguinte:
>
>| Campo      | Significado                                                   | Obrigatório? |
>|------------|---------------------------------------------------------------|--------------|
>| `valor`    | **Valor em decimal com ponto flutuante** da transação         | Sim          |
>| `dataHora` | **Data/Hora no padrão ISO 8601** em que a transação aconteceu | Sim          |
>>**Dica:** O Spring Boot, por padrão, consegue compreender datas no padrão ISO 8601 sem problemas. Experimente utilizar um atributo do tipo `OffsetDateTime`!
>
>A API só aceitará transações que:
>
>Tenham os campos valor e dataHora preenchidos
>A transação NÃO DEVE acontecer no futuro
>A transação DEVE ter acontecido a qualquer momento no passado
>A transação NÃO DEVE ter valor negativo
>A transação DEVE ter valor igual ou maior que 0 (zero)
>Como resposta, espera-se que este endpoint responda com:
>
>   - 201 Created sem nenhum corpo
>A transação foi aceita (ou seja foi validada, está válida e foi registrada)
>   - 422 Unprocessable Entity sem nenhum corpo
>A transação não foi aceita por qualquer motivo (1 ou mais dos critérios de aceite não foram atendidos - por exemplo: uma transação com valor menor que 0)
>   - 400 Bad Request sem nenhum corpo
>A API não compreendeu a requisição do cliente (por exemplo: um JSON inválido)
>## 2.2.2. Limpar Transações: DELETE /transacao
>Este endpoint simplesmente apaga todos os dados de transações que estejam armazenados.
>
>Como resposta, espera-se que este endpoint responda com:
>
>   - 200 OK sem nenhum corpo
>Todas as informações foram apagadas com sucesso
>## 2.2.3. Calcular Estatísticas: GET /estatistica
>Este endpoint deve retornar estatísticas das transações que aconteceram nos últimos 60 segundos (1 minuto). >As estatísticas que devem ser calculadas são:
>
>```json
>{
>    "count": 10,
>    "sum": 1234.56,
>    "avg": 123.456,
>    "min": 12.34,
>    "max": 123.56
>}
>
>Os campos no JSON acima significam o seguinte:
>
>|  Campo  | Significado                                                   | Obrigatório? |
>|---------|---------------------------------------------------------------|--------------|
>| `count` | **Quantidade de transações** nos últimos 60 segundos          | Sim          |
>| `sum`   | **Soma total do valor** transacionado nos últimos 60 segundos | Sim          |
>| `avg`   | **Média do valor** transacionado nos últimos 60 segundos      | Sim          |
>| `min`   | **Menor valor** transacionado nos últimos 60 segundos         | Sim          |
>| `max`   | **Maior valor** transacionado nos últimos 60 segundos         | Sim          |
>**Dica:** Há um objeto no Java 8+ chamado `DoubleSummaryStatistics` que pode lhe ajudar ou servir de inspiração.
>
>Como resposta, espera-se que este endpoint responda com:
>
>   - 200 OK com os dados das estatísticas
>Um JSON com os campos count, sum, avg, min e max todos preenchidos com seus respectivos valores
>Atenção! Quando não houverem transações nos últimos 60 segundos considere todos os valores como 0 (zero)

## Tecnologias utilizadas

- .net 6
- Swagger - para documentação da API
- Linux
- VS Code

## Como utilizar

- Baixe o código fonte
- Abra no VSCode a pasta raiz do projeto
- Execute no terminal
    ```bash
        dotnet run
    ```
- Abra no navegador
    ```bash
        https://localhost:7046/swagger/index.html
    ```