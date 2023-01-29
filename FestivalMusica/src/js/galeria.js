document.addEventListener("DOMContentLoaded", function () {
  iniciarApp();
});

function iniciarApp() {
  crearGaleria();
}

function crearGaleria() {
  const galeria = document.querySelector(".galeria-imagenes");
  for (let i = 1; i <= 12; i++) {
    const imagen = document.createElement("picture");
    imagen.innerHTML = `
        <source srcset="build/img/grande/${i}.avif" type="image/avif" />
          <source srcset="build/img/grande/${i}.webp" type="image/webp" />
          <img
            loading="lazy"
            width="200"
            height="300"
            src="build/img/grande/${i}.jpg"
            alt="imagen galeria"
          />
        `;

        imagen.onclick = function(){
            mostrarImagen(i); //se puso asi como callback, para identificar a cual imagen, sino, se llamarian todas a la vez
        }

        galeria.appendChild(imagen);
        //console.log(imagen);
  }
}

function mostrarImagen(id) {
    const imagen = document.createElement("picture");
    imagen.innerHTML = `
        <source srcset="build/img/grande/${id}.avif" type="image/avif" />
          <source srcset="build/img/grande/${id}.webp" type="image/webp" />
          <img
            loading="lazy"
            width="200"
            height="300"
            src="build/img/grande/${id}.jpg"
            alt="imagen galeria"
          />
        `;
        const overlay = document.createElement('DIV');
        overlay.appendChild(imagen);
        overlay.classList.add('overlay');
        
        const body = document.querySelector('body');
        body.appendChild(overlay);
        console.log(imagen);
    
}
