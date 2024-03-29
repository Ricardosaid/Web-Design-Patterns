// Sacamos source y destination de gulp. El compile lo hacemos con las dependencias via el package.json
const { src, dest, watch,parallel } = require("gulp");

// Dependencias de css
const sass = require("gulp-sass")(require('sass')); 
const plumber = require("gulp-plumber");
const autoprefixer = require('autoprefixer');
const cssnano = require('cssnano');
const postcss = require('gulp-postcss');
const sourcemaps = require('gulp-sourcemaps');

// Dependencias de imagenes
const cache = require("gulp-cache");
const imagemin = require("gulp-imagemin");
const webp = require("gulp-webp");
const avif = require("gulp-avif");

//javascript
const terser = require('gulp-terser-js');



//Gulp nos da una api que busca, compila y guarda

function css(done) {
  src("src/scss/**/*.scss")//identificar el archivo de sass
  .pipe(sourcemaps.init()) // inicializamos el sourcemapscon la hoja de estilos que va a compilar
  .pipe(plumber())
  .pipe(sass())// Compilar las funciones de sass
  .pipe(postcss([autoprefixer(),cssnano()]))
  .pipe(sourcemaps.write('.')) // se guarde en la misma ubicacion de la hoja de archivo de css
  .pipe(dest("build/css")) //Almacenarla o guardarla en el disco duro

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
  .pipe(sourcemaps.init())
  .pipe(terser())
  .pipe(sourcemaps.write('.')) //en la misma carpeta de js
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
