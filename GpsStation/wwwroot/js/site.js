const menuToggle = document.querySelector('.menuToggle');
const navigation = document.querySelector('.navigation');

menuToggle.onclick = function () {
    navigation.classList.toggle('open');
}

const list = document.querySelectorAll('.list');
function activeLink() {
    list.forEach((item) =>
        item.classList.remove('active')
    );
    this.classList.add('active');
}

list.forEach((item) =>
    item.addEventListener('click', activeLink)
);

document.addEventListener("mouseover", function (evt) {
    if (evt.target.classList.contains("icon")) {
        aux = evt.target.src
        evt.target.src = evt.target.getAttribute("gif");
        evt.target.setAttribute("gif", aux)
    }
});

document.addEventListener("mouseout", function (evt) {
    if (evt.target.classList.contains("icon")) {
        aux = evt.target.src
        evt.target.src = evt.target.getAttribute("gif");
        evt.target.setAttribute("gif", aux)
    }
});