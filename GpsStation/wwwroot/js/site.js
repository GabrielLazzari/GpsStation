var larguraTela = window.innerWidth;
const tamanhoControle = 520;
var menuToggle = document.querySelector('.menuToggle');
var navigation = document.querySelector('.navigation');
var pagina = document.querySelector('.pagina');

// Mostra ou esconde o menu esquerdo
menuToggle.onclick = function () {
    navigation.classList.toggle('open');
}

function executarPausarGif(evt) {
    if (evt.target.classList.contains("icon")) {
        aux = evt.target.getAttribute("src");
        evt.target.setAttribute("src", evt.target.getAttribute("gif"));
        evt.target.setAttribute("gif", aux);
    }
}

document.addEventListener("mouseover", function (evt) {
    executarPausarGif(evt);
});

document.addEventListener("mouseout", function (evt) {
    executarPausarGif(evt);
});

// Define se o estilo do menu esquerdo deve ser superior ou padrao(lateral)
function redmin() {
    larguraTela = window.innerWidth;
    console.log(larguraTela)
    if (larguraTela < tamanhoControle) {
        navigation.classList.add('barraSuperior');
        if (pagina != null) {
            pagina.style.top = "45px";
            pagina.style.left = "0px";
        }
    } else {
        navigation.classList.remove('barraSuperior');
        if (pagina != null) {
            pagina.style.top = "0px";
            pagina.style.left = "45px";
        }
    }
}

redmin();
addEventListener("resize", redmin);

document.onmousedown = function (evt) {
    if (evt.target.closest(".navigation") == null) {
        if (navigation.classList.contains("open")) {
            navigation.classList.toggle('open');
        }
    }
}