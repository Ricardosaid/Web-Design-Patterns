# Festival de musica
## Requerimientos para SASS
```console
npm init
```
1. Dentro del package.json, las que son dependencias, una vez que se haga un deployment a un servidor que soporte node.js, se van a instalar automaticamente. Las que son dependencias de desarrollo no. Por lo que si queremos instalar dependencias de desarrollo ejecutamos:

```console
npm install sass --save-dev 
```

si no,
```console
npm install sass
```
2. La carpeta de node_modules, la podemos eliminar. Para volverla a sacar, lanzamos el siguiente codigo en consola  
```console
npm install 
```
Como ya tenemos las dependencias en el package.json, nos recupera la carpeta de node_modules

3. Para compilar las hojas de sass, dentro del package.json, en el nodo de scripts, (para este ejemplo) cambiamos `"sass": "sass src/scss:build/css"`. Lo que hace es que el script que vamos a corre se llama sass, despues, el otro sass es el binario que se encuentra en node_modules, despues mandamos la ubicacion y los `:` nos dicen que lo que ejecute el binario lo ponga en una carpeta llamada `css` dentro de la carpeta `build`.
Lanzamos en consola en siguiente codigo:
```console
npm run sass
```
4. Para habilitar el watch, agregamos en el nodo scripts del package.json `"sass": "sass --watch src/scss:build/css"`

## Requerimientos de Gulp

Gulp es una herramienta para automatizar tareas  y esas tareas son funciones de javascript

 1. Instalamos Gulp, lanzando el siguiente codigo

```console
npm i -D gulp
```
<note:-D es igual a dependencias de desarrollo>

2. Creamos el gulpfile, es un archivo de configuracion que contiene nuestras tareas. Ya que tengamos nuestras funciones/tareas en javascript, en la terminal ejecutamos lo siguiente
```console
npx gulp <nombre de la tarea>
```

3. Agregamos un callback para que no salga el error de `Did you forget to signal async completition`. Un callback es una funcion que se manda a llamar despues de otra funcion. Era la forma de tener codigo asincrono en js

```
[18:17:43] Using gulpfile FestivalMusica/gulpfile.js
[18:17:43] Starting 'primerTarea'...
First task
[18:17:43] Finished 'primerTarea' after 2.26 ms
```

## Mandar llamar una funcion de gulp con npm

1. En este `package.json`, en el nodo de script, agregamos la tareas que vamos a ejecutar.

```
"tarea":"gulp <nombre de la tarea/funcion en gulp>"
```
Despues de agregarlo, ejecutamos en consola
 
```console
npm run <nombre de la tarea en el package.json>
```

## Compilando SASS con Gulp

1.  Necesitamos un conectar entre gulp y sass, para ellos instalamos en terminal

```console
npm i -D gulp-sass
```
Despues ejecutamos

```console
npx gulp css
```
Con eso compilamos la hoja de estilos de sass

2. Anadiendo un watch al gulpfile
Importamos la funcion watch de gulp, paar ello, creamos una funcion nueva

```
watch("ruta del archivo que se va a ejecutar", "nombre de la funcion que se ejecuta ");
```
Ejecutamos en consola
```console
npx gulp watchDev
```


