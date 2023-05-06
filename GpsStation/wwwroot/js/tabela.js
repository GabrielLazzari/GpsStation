
function retornarPagina() {
    pagina = window.location.href.split('/');
    if (pagina.length > 0) {
        if (pagina[pagina.length - 1] != "") {
            pagina = pagina[pagina.length - 1]
        } else if (pagina.length > 1) {
            pagina = pagina[pagina.length - 2]
        }
    }

    return pagina;
}

function excluirItem(nome, id, td) {
    if (confirm("Relamente deseja excluir o item '" + nome + "'?") == true) {
        $.post('/' + retornarPagina() + '/Excluir', { id: id }, function (retorno) {
            td.closest("tr").remove();
        });
    }
}

function editarLinha(idTabela, td, campos) {
    var tabela = document.getElementById(idTabela);
    campos = JSON.parse(campos);
    tr = tabela.querySelector('tr');

    console.log(td)
    td = td.closest("tr")

    console.log('ee', td)
    transformarLinhaEditavel(tabela, tr, td, campos);
}

function novaLinha(idTabela, campos) {
    var tabela = document.getElementById(idTabela);
    campos = JSON.parse(campos);
    tr = tabela.querySelector('tr');

    novaTr = document.createElement('tr');
    novaTr.setAttribute("novaLinha", true);
    for (var c = 0; c < tr.querySelectorAll("th").length; c++) {
        novaTr.appendChild(document.createElement("td"));
    }

    tr.insertAdjacentElement("afterend", novaTr);
    transformarLinhaEditavel(tabela, tr, novaTr, campos);
}

function transformarLinhaEditavel(tabela, trCabecalho, trEditar, campos) {
    var cloneTr = `` + trEditar.innerHTML.replaceAll('"', "aspapadupla").replaceAll("'", "aspapa").replaceAll("\n", "") + ``;

    for (var chave in campos) {
        var posColuna = 0;
        Array.prototype.forEach.call(trCabecalho.querySelectorAll("th"), function (th) {
            var tdLocalizada = trEditar.cells[posColuna];
            if (th.innerHTML == "Açoes") {
                tdLocalizada.innerHTML = `<img onclick="salvarEdicaoLinha(this)" src="/gifs/checkmark-circle-outline.svg" class="svg-sm" title="Salvar Alteraçoes">
                                          <img onclick="cancelarEdicaoLinha('${cloneTr}', this)" src="/gifs/close-circle-outline.svg" class="svg-sm" title="Cancelar Alteraçoes">`
            } else {
                if (th.innerText.toLowerCase().includes(chave.toLowerCase())) {
                    /*if (campos[chave] == "checkbox") {
                        var posAux = trEditar.rowIndex;
                        tdLocalizada.innerHTML = `<input type="radio" id="admin${posAux}" name="admin_" value="True" checked>
                                              <label for="admin${posAux}">True</label>
                                              <input type="radio" id="normal${posAux}" name="admin_" value="False">
                                              <label for="normal${posAux}">False</label>`;
                    } else {*/
                        //tdLocalizada.innerHTML = campos[chave];
                        bloquearEnter(tdLocalizada);
                    tdLocalizada.setAttribute("contenteditable", true);
                    //}
                }
            }
            posColuna++;
        });
    }
}

function cancelarEdicaoLinha(dadosAntigos, el) {
    var tr = el.closest("tr");

    // Se o atributo abaixo estiver null entao foi clicado em uma linha para editar, senao foi criado uma nova linha
    if (tr.getAttribute("novaLinha") == null) {

        //retransformar os valores antigos que vieram em string para objeto DOM
        dadosAntigos = dadosAntigos.replaceAll("aspapadupla", '"').replaceAll("aspapa", "'");
        trAntiga = document.createElement("tr");
        trAntiga.innerHTML = dadosAntigos;

        // Aramazenar os valores antigos em uma lista
        var valoresAntigos = [];
        Array.prototype.forEach.call(trAntiga.querySelectorAll("td"), function (td) {
            valoresAntigos.push(`${td.innerHTML}`);
        })

        // Recolocar os valores antigos na tabela, isso previne se houve qualquer edicao
        var posicao = 0
        Array.prototype.forEach.call(tr.querySelectorAll("td"), function (td) {
            td.innerHTML = valoresAntigos[posicao];
            td.setAttribute("contenteditable", false)
            posicao++;
        })

    } else {
        tr.remove();
    }
}

function salvarEdicaoLinha(el) {
    var tabela = el.closest("table")
    var trCabecalho = tabela.querySelector("tr")
    var trSalvar = el.closest("tr");

    pagina = retornarPagina();

    var novaTd = ``;

    parametrosCabecalho = [];
    dados = {};

    Array.prototype.forEach.call(trCabecalho.querySelectorAll("th"), function (th) {
        parametrosCabecalho.push(th.innerText);
    })

    if (pagina == "Usuario") {
        for (var posColuna = 0; posColuna < parametrosCabecalho.length; posColuna++) {
            td = trSalvar.cells[posColuna];
            if (parametrosCabecalho[posColuna].toLowerCase() == "nome") {
                dados['Nome'] = td.innerText;
                
            } else if (parametrosCabecalho[posColuna].toLowerCase() == "senha") {
                dados['Senha'] = td.innerText;
               
            } else if (parametrosCabecalho[posColuna].toLowerCase() == "código") {
                dados['Id'] = trSalvar.getAttribute("idUsuario");
            }
        }
        novaTd = `<td>
					    <img onclick="editarLinha('tabelaUsuarios', this, JSON.stringify({nome:'', senha:''}))" src="/gifs/brush-outline.svg" class="svg-sm" title="Editar">
					    <img onclick="excluirItem('${dados['Nome']}', '${dados['Id']}', this)" src="/gifs/trash-outline.svg" class="svg-sm" title="Excluir">
				    </td>`;

    } else if (pagina == "Dispositivo") {

        for (var posColuna = 0; posColuna < parametrosCabecalho.length; posColuna++) {
            td = trSalvar.cells[posColuna];
            if (parametrosCabecalho[posColuna].toLowerCase() == "dispositivo") {
                dados['Nome'] = td.innerText;
           
            } 
            dados['Id'] = trSalvar.getAttribute("idDispositivo");
           
        }
        novaTd = ` <td>
					    <a href="/Relatorio/Index">Últimos registros</a>
					    <a href="/Mapa/Index">Visualizar localização</a>
					    <img onclick="editarLinha('tabelaDispositivos', this, JSON.stringify({dispositivo:'', status:''}))" src="/gifs/brush-outline.svg" class="svg-sm" title="Editar">
					    <img onclick="excluirItem('${dados['Nome']}', '${dados['Id']}', this)" src="/gifs/trash-outline.svg" class="svg-sm" title="Excluir">		
				    </td>`;

        dados['Localizacao'] = "";
    }
    console.log('dados: ', dados)

    // Se o atributo abaixo estiver null entao foi clicado em uma linha para editar, senao foi criado uma nova linha
    if (trSalvar.getAttribute("novaLinha") == null) {
        //inserir
        var url = '/' + pagina + '/Gravar';
        console.log('ddaaa', dados)
        $.post(url, dados, function (retorno) {
            var pos = 0;
            Array.prototype.forEach.call(trSalvar.querySelectorAll("td"), function (td) {
                if (parametrosCabecalho[pos] == "Açoes") {
                    td.innerHTML = novaTd;
                } else {
                    td.setAttribute("contenteditable", false);
                }
                pos++;
            });
        });
    } else {
        //salvar edicao
        var url = '/' + pagina + '/Gravar/';
        $.post(url, dados, function (retorno) {
            var pos = 0;
            Array.prototype.forEach.call(trSalvar.querySelectorAll("td"), function (td) {
                if (parametrosCabecalho[pos] == "Açoes") {
                    td.innerHTML = novaTd;
                } else {
                    td.setAttribute("contenteditable", false);
                }
                pos++;
            });
        });
    }
}

// O atributo contenteditable necessta bloquear o enter pois, por ser mais facil de trabalhar ele cria um item
// como se fose um textarea e nao um input type text
function bloquearEnter(td) {
    td.addEventListener("keydown", function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
        }
    });
}


