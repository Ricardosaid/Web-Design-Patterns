
// Agregamos un callback

function tarea(cb) {
    console.log("First task");
    cb(); 
}

//Mandar llamar una funcion con node
exports.primerTarea = tarea; // cuando mande llamar primer tarea, va a ejecutar la funcion 'tarea'

 
