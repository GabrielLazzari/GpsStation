
document.onkeyup = function () {
	if (document.activeElement.id == "pesquisarUsuario") {
        var url = "/usuario/pesquisar";
		var parametros = { descricao: document.activeElement.value };
		console.log(url)
        $.post(url, parametros, function (retorno) {
            var tabela = document.querySelector("#tabelaUsuarios");

            novoHtml = `
                           	<tr>
								<th>Nome</th>
								<th>Senha</th>
								<th>Código</th>
								<th>Administrador</th>
								<th>Açoes</th>
							</tr>`;

            $.each(retorno, function (index, value) {
                novoHtml = novoHtml + `
								   <tr idUsuario="${value.id}">
										<td id="${value.id}">${value.nome}</td>
										<td>${value.senha}</td>
										<td>${value.id}</td>
										<td>${value.administrador}</td>
										<td>
											<img onclick="editarLinha('tabelaUsuarios', this, JSON.stringify({nome:'', senha:'', administrador:'checkbox'}))" src="/gifs/brush-outline.svg" class="svg-sm" title="Editar">
											<img onclick="excluirItem('${value.nome}', '${value.id}', this)" src="/gifs/trash-outline.svg" class="svg-sm" title="Excluir">
										</td>
									</tr>`;
            });
            tabela.innerHTML = novoHtml;
        });
    }
}