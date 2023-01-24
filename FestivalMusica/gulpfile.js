// Sacamos source y destination de gulp. El compile lo hacemos con las dependencias via el package.json
const { src, dest, watch } = require("gulp");
// Importamos las funcion de sass

const sass = require("gulp-sass")(require('sass')); 

//Importamos plumber
const plumber = require("gulp-plumber");

// Agregamos un callback

function tarea(cb) {
  console.log("First task");
  cb();
}

//Mandar llamar una funcion con node
exports.primerTarea = tarea; // cuando mande llamar primer tarea, va a ejecutar la funcion 'tarea'

//Gulp nos da una api que busca, compila y guarda

function css(done) {
  src("src/scss/**/*.scss")//identificar el archivo de sass
  .pipe(plumber())
  .pipe(sass())// Compilar las funciones de sass
  .pipe(dest("build/css")); //Almacenarla o guardarla en el disco duro

  done(); // callback que avisa a gulp cuando llegamos al final de la funcion
}

exports.css = css;

function dev(done) {
    watch("src/scss/**/*.scss", css);
    done();
}

exports.watchDev = dev;
