function Confirmarlogin(usuario, senha) {

    // var inicio = //JSON.stringify({ inicio: inicio.toISOString() });



    //"testeini" //document.getElementsByName("inicio").values;
    //var fim = "testefim" //document.getElementsByName("fim").values;
    var dados = {
        usuario:usuario.trim(),
        senha:senha.trim()
    }
    $.post("/login/Confirmarlogin/", dados,CallBackConfirmarlogin);

}

function CallBackConfirmarlogin(retorno) {
    if(!retorno)
        alert("Usuário ou senha incorretos");
}

