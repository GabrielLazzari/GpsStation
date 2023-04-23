

function excluirDispositivo(nome, id, td) {
    if (confirm("Relamente deseja excluir o dispositivo '" + nome + "'?") == true) {
        $.post('/Dispositivo/Excluir', { id: id }, function (retorno) {
            td.closest("tr").remove();
        });
    }
}

function excluirUsuario(nome, id, td) {
    if (confirm("Relamente deseja excluir o usuário '" + nome + "'?") == true) {
        $.post('/Usuario/Excluir', { id: id }, function (retorno) {
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
            var tdLocalizada = tabela.rows[1].cells[posColuna];
            if (th.innerHTML == "Açoes") {
                var cloneBotoesAcao = `` + tdLocalizada.innerHTML.replaceAll('"', "aspapadupla").replaceAll("'", "aspapa").replaceAll("\n", "") + ``;
                tdLocalizada.innerHTML = `<img onclick="salvarEdicaoLinha(this, '${cloneBotoesAcao}')" src="/gifs/checkmark-circle-outline.svg" class="svg-sm" title="Salvar Alteraçoes">
                                          <img onclick="cancelarEdicaoLinha('${cloneTr}', this)" src="/gifs/close-circle-outline.svg" class="svg-sm" title="Cancelar Alteraçoes">`
            } else {
                if (th.innerText.toLowerCase().includes(chave.toLowerCase())) {
                    if (campos[chave] == "checkbox") {
                        tdLocalizada.innerHTML = `<input type="radio" id="admin" name="admin_" value="True" checked>
                                              <label for="admin">True</label>
                                              <input type="radio" id="normal" name="admin_" value="False">
                                              <label for="normal">False</label>`;
                    } else {
                        //tdLocalizada.innerHTML = campos[chave];
                        bloquearEnter(tdLocalizada);
                        tdLocalizada.setAttribute("contenteditable", true);
                    }
                }
            }
            posColuna++;
        });
    }
}

function cancelarEdicaoLinha(dadosAntigos, el) {
    console.log('ddd', dadosAntigos)
    var tr = el.closest("tr");

    // Se o atributo abaixo estiver null entao foi clicado em uma linha para editar, senao foi criado uma nova linha
    if (tr.getAttribute("novaLinha") == null) {

        //retransformar os valores antigos que vieram em string para objeto DOM
        dadosAntigos = dadosAntigos.replaceAll("aspapadupla", '"').replaceAll("aspapa", "'");
        trAntiga = document.createElement("tr");
        trAntiga.innerHTML = dadosAntigos;

        console.log(trAntiga)

        // Aramazenar os valores antigos em uma lista
        var valoresAntigos = [];
        Array.prototype.forEach.call(trAntiga.querySelectorAll("td"), function (td) {
            valoresAntigos.push(`${td.innerHTML}`);
        })

        console.log('vv', valoresAntigos);

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

function salvarEdicaoLinhaUsuario(el, botoesAcao) {

}

function salvarEdicaoLinhaDispositivo(el, botoesAcao) {

}

function salvarEdicaoLinha(el, botoesAcao) {
    var tabela = el.closest("table")
    var trCabecalho = tabela.querySelector("tr")
    var trSalvar = el.closest("tr");

    pagina = window.location.href.split('/');
    if (pagina.length > 0) {
        if (pagina[pagina.length - 1] != "") {
            pagina = pagina[pagina.length - 1]
        } else if (pagina.length > 1) {
            pagina = pagina[pagina.length - 2]
        }
    }

    console.log(pagina)

    //retransformar os valores antigos que vieram em string para objeto DOM
    botoesAcao = botoesAcao.replaceAll("aspapadupla", '"').replaceAll("aspapa", "'");
    botoesAcaoAntigo = document.createElement("tr");
    botoesAcaoAntigo.innerHTML = botoesAcao;

    parametrosCabecalho = [];
    dados = {};

    Array.prototype.forEach.call(trCabecalho.querySelectorAll("th"), function (th) {
        parametrosCabecalho.push(th.innerText);
    })

    console.log(trSalvar)
    if (pagina == "Usuario") {
        for (var posColuna = 0; posColuna < parametrosCabecalho.length; posColuna++) {
            Array.prototype.forEach.call(trSalvar.querySelectorAll("td"), function (td) {
                if (parametrosCabecalho[posColuna].toLowerCase() == "nome") {
                    dados['Nome'] = td.innerText;
                } else if (parametrosCabecalho[posColuna].toLowerCase() == "senha") {
                    dados['Senha'] = td.innerText;
                } else if (parametrosCabecalho[posColuna].toLowerCase() == "codigo") {
                    dados['Id'] = td.innerText;
                } else if (parametrosCabecalho[posColuna].toLowerCase() == "administrador") {
                    dados['Administrador'] = td.innerText;
                }
            })
        }
    } else if (pagina == "Dispositivo") {
        for (var posColuna = 0; posColuna < parametrosCabecalho.length; posColuna++) {
            Array.prototype.forEach.call(trSalvar.querySelectorAll("td"), function (td) {
                console.log(td, parametrosCabecalho[posColuna])
                if (parametrosCabecalho[posColuna].toLowerCase() == "dispositivo") {
                    console.log('ok')
                    dados['Nome'] = td.innerText;
                } else if (parametrosCabecalho[posColuna].toLowerCase() == "status") {
                    dados['Ativo'] = td.innerText;
                }
                //Como aqui recuperar id, id de usuario?
            })
        }
        dados['Id'] = "";
        dados['IdUsuario'] = "";
        dados['Localizacao'] = "";
    }

    console.log(parametrosCabecalho)
    console.log(dados)

    // Se o atributo abaixo estiver null entao foi clicado em uma linha para editar, senao foi criado uma nova linha
    if (trSalvar.getAttribute("novaLinha") == null) {
        //inserir
        var url = '/' + pagina + '/Inserir';
        ados = JSON.stringify(dados);
        $.post(url, dados, function (retorno) {
            //consolidar valores na tela
        });
    } else {
        //salvar edicao
        var url = '/' + pagina + '/Gravar';
        var dados = JSON.stringify({});
        $.post(url, dados, function (retorno) {
            //consolidar valores na tela
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