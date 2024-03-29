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

## Trabajando con SASS
Para organizar el codigo, creamos dos carpetas `base` y `content` y para que la api de sass no cree dos hojas de estilo agregamos un `_` al incio del archivo.

1. `@forward` solo va a ir en los archivos index, `@use` es para acceder al contenido de una archivo en especiaL.
2. `@import` una vez que lo importas en el app.scss lo hace disponible en todos los archivos
3. `@use` lo hace disponible unicamente donde decidas importarlo

## Compilar todos los archivos sass dentro de un proyecto

1. `**` todas las carpetas
2. `*` todos los archivos

## Correcion cuando escribimos mal el codigo y el watch del build se rompe

1. Instalamos el plugin `gulp-plumber`
```console
npm i -D gulp-plumber
```
## Mixins en SASS

1. Codigo css que puedes reutilizar en multiples lugares en tu hoja de estilos. En este sentido, podemos utilizar los mixins para botones, los cuales llevan mucho codigo.
2. Para el uso de mixins que requiera ciertos valores, para que reciba argumentos.
```
@mixins heading ($color) {

}
```
En el llamado
```
.prueba {
    @include m.heading(v.$amarillo);
}
```
En el caso de que se le pase una variable que no exista, le indicamos `:` y tomara lo seguido en los dos puntos

3. Mixins para los media querys

`@content` lo agregamos dentro del mixin para que lo que agregemos en el header lo inyecte y acepte contenido por bloque

## Snippet media query mixins SASS

En vscode buscamos documentos sass snippets y escribimos el siguiente codigo en el json
```
"media query":{
		"prefix": "mq",
		"body": [
			"@include m.$1 {\n\t$2\n}"
		]
	}
```

## Mostrar imagenes Avif, Webp o un fallback

1. Primero mostrar la imagen mas ligera, que seria avif (soporte menor)
2. Despues mostrar la webp (soportada en edge)

```
<picture>
          <source srcset="build/img/imagen_vocalista.avif" type="image/avif">
          <source srcset="build/img/imagen_vocalista.webp" type="image/webp">
          <img src="build/img/imagen_vocalista.jpg" alt="imagen vocalista">
</picture>
```
3. Al trabajar con un mejor performance, se recomienda poner este snippet en la etiqueta `img` ya que muestra rapidamente las imagenes
```
<img width="200" height="300" src="build/img/imagen_vocalista.jpg" alt="imagen vocalista">
```
Agregamos el `loading="lazy"` para reducir el timpo de carga
4. El snippet para de imagenes en html
```
"imagenes" : {
		"prefix": "im",
		"body": [
			 "<picture>",
			 	"\t<source srcset=\"$1.avif\" type=\"image/avif\">",
				"\t<source srcset=\"$1.webp\" type=\"image/webp\">",
				"\t<img loading=\"lazy\" width=\"200\" height=\"300\" src=\"$1.jpg\" alt=\"$2\">",
			 "</picture>"
		]
	}
```

## Footer padding
1. El `p` tiene muco padding, para quitarlo le agregamos un `margin:0;`

```
.site-footer{
    background-color: v.$rosa;
    padding: 1rem;
    p{
        margin: 0;
        text-align: center;
        font-size: 1.5rem;
    }
}
```

## Behavior smooth

1. Prevenir el comporatmiento por default y despues mandar llamar `scrollIntoView`

```
enlace.addEventListener('click', function(e){
      e.preventDefault();
      const sectionScroll = e.target.attributes.href.value;
        const section = document.querySelector(sectionScroll);
        section.scrollIntoView({behavior:'smooth'});
     });
```

## Header flotante evitar que el contenido del body se mueva

1. Se hace un salto de linea por flotar el header, medimos el padding del header y ese es el que agregamos cuando se cumpla el `getBoundingClientRect()` 
```
&.body-scroll{
        padding-top: 8.6rem; //tamano del header
    }
```

## Mejorando el performance del css

Instalamos cssnano, autoprefixer, postcss, gulp-postcss
```console
npm i -D cssnano autoprefixer postcss gulp-postcss
```

1. Autoprefixer nos va a yudar a que si las ultimas caracteristicas de css no son soportadas por el nnavegador, toma las funcionales

2. Cuando minificamos el codigo de css, se complica modificar el archivo porque esta comprimido en una sola linea, para solucionarlo, utilizamos `sourcemaps`

```console
npm i -D gulp-sourcemaps
```

## Mejorando el performance de js

1. Instalamos terser 
```console
npm i -D gulp-terser-js
```

2. Utilizamos el sourcemaps para que la lectura sea legible en el browser







