﻿
document.onkeyup = function () {
    if (document.activeElement.id == "pesquisarDispositivo") {
        var url = "/dispositivo/pesquisar";
        var parametros = { descricao: document.activeElement.value };
        $.post(url, parametros, function (retorno) {
            var tabela = document.querySelector("#tabelaDispositivos");

            novoHtml = `
                            	<tr>
		                            <th>Dispositivo</th>
		                            <th>Açoes</th>
	                            </tr>`;

            $.each(retorno, function (index, value) {
                novoHtml = novoHtml + `
                			        <tr idDispositivo="${value.id}" idUsuario="${value.idUsuario}">
				                        <td>${value.nome}</td>
				                        <td>
					                        <a href="/Relatorio/Index">Últimos registros</a>
					                        <a href="/Mapa/Index">Visualizar localização</a>
					                        <img onclick="editarLinha('tabelaDispositivos', this, JSON.stringify({dispositivo:''}))" src="/gifs/brush-outline.svg" class="svg-sm" title="Editar">
					                        <img onclick="excluirItem('${value.nome}', '${value.id}', this)" src="/gifs/trash-outline.svg" class="svg-sm" title="Excluir">
				                        </td>
			                        </tr>`;
            });
            tabela.innerHTML = novoHtml;
        });
    }
}
