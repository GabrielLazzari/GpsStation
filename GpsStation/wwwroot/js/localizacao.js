function RelatorioLocalizacao(dispositivo, inicio, fim) {

    // var inicio = //JSON.stringify({ inicio: inicio.toISOString() });



    //"testeini" //document.getElementsByName("inicio").values;
    //var fim = "testefim" //document.getElementsByName("fim").values;
    var dados = {

        inicio: inicio,
        fim: fim,
        dispositivo: dispositivo
    }
    $.post("/localizacao/Consultar/", dados, CallBackRelatorioLocalizacao);

}

function CallBackRelatorioLocalizacao(retorno)
{
    var tabela = document.querySelector("#tabelaRelatorio");
    var contalinhas = tabela.rows.length;

    for (var i = contalinhas - 1; i > 0; i--)
    {
        tabela.deleteRow(i);
    }



    for (var i = 0; i < retorno.length; i++)
    {
        var objeto = retorno[i];
        var linha = document.createElement("tr");
        var coluna1 = document.createElement("td");
        var coluna2 = document.createElement("td");
        var coluna3 = document.createElement("td");
        coluna1.innerHTML = objeto.dataHora;
        coluna2.innerHTML = objeto.latitude;
        coluna3.innerHTML = objeto.longitude;
        linha.appendChild(coluna1);
        linha.appendChild(coluna2);
        linha.appendChild(coluna3);
        tabela.appendChild(linha);
    }






}