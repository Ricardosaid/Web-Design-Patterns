// Sacamos source y destination de gulp. El compile lo hacemos con las dependencias via el package.json
const { src, dest, watch,parallel } = require("gulp");

// Dependencias de css
const sass = require("gulp-sass")(require('sass')); 
const plumber = require("gulp-plumber");

// Dependencias de imagenes
const cache = require("gulp-cache");
const imagemin = require("gulp-imagemin");
const webp = require("gulp-webp");
const avif = require("gulp-avif");


//Gulp nos da una api que busca, compila y guarda

function css(done) {
  src("src/scss/**/*.scss")//identificar el archivo de sass
  .pipe(plumber())
  .pipe(sass())// Compilar las funciones de sass
  .pipe(dest("build/css")); //Almacenarla o guardarla en el disco duro

  done(); // callback que avisa a gulp cuando llegamos al final de la funcion
}

function imagenes(done){
  const opciones = {
    optimizationLevel : 3
  }
  src("src/img/**/*.{png,jpg}")
  .pipe(cache(imagemin(opciones)))
  .pipe(dest("build/img"))
  done();
}

function versionWebp(done){
  const opciones = {
    quality:50
  };
  src("src/img/**/*.{png,jpg}") //buscas formatos
  .pipe(webp(opciones))
  .pipe(dest('build/img'))
  done();
}

function javascript(done) {
  src("src/js/**/galeria.js")
  .pipe(dest("build/js"))
  done();
}

function versionAvif(done){
  const opciones = {
    quality:50
  };
  src("src/img/**/*.{png,jpg}") //buscas formatos
  .pipe(avif(opciones))
  .pipe(dest('build/img'))
  done();
}

function dev(done) {
  watch("src/scss/**/*.scss", css);
  watch("src/js/**/galeria.js", javascript);
  done();
}


exports.css = css;
exports.js = javascript;
exports.version = versionWebp;
exports.versionAvif = versionAvif;
exports.imagenes = imagenes;
exports.watchDev = parallel(imagenes,versionWebp,versionAvif,javascript,dev);
