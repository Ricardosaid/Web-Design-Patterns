document.addEventListener("DOMContentLoaded",function() {
    iniciarApp();  
});

function iniciarApp() {
    crearGaleria();
}

function crearGaleria() {
    const galeria = document.querySelector('.galeria-imagenes');
    galeria.textContent = 'Creando la galeria ...'
}