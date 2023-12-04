# :books: Manual Media Player

## :link: Indice de contenidos

* :earth_americas: [Descargar](#descargar-reproductor)
* :dvd: [Instalar reproductor](#instalación)
* :open_file_folder: [Seleccionar directorio](#seleccionar-directorio)
* :heavy_plus_sign: [Agregar canciones](#agregar-canciones)
* :pencil: [Editar tags](#editar-tags)
	* :open_file_folder: [Seleccionar directorio a editar](#seleccionar-directorio-a-editar)
		* :pencil2: [Ejemplo 1](#ejemplo)
	* :1234: [Enumerar Automáticamente](#enumerar-automáticamente)
* :musical_note: [Pista de audio](#pista)
	* :construction_worker: [Página del artista](#página-del-artista)
	* :cd: [Página del álbum](#página-del-álbum)
* :arrow_forward: [Listas de reproducción](#listas-de-reproducción)
	* :heavy_plus_sign: [Agregar canción](#agregar-una-cación-a-la-lista)
	* :heavy_plus_sign: [Agregar varias canciones](#agregar-varias-canciones-a-la-lista)
	* :x: [Eliminar lista de reproducción](#borrar-lista-de-reproducción)
	* :x: [Eliminar canción de una lista](#borrar-una-canción-de-la-lista)
* :airplane: [Navegación por la aplicación](#navegación-por-la-aplicación)
* :arrow_forward: [Reproducción](#reproducción)
* :arrow_down: [Descargas](#descargas)


### Descargar Reproductor

Para descargar el reproductor lo podemos hacer desde el siguiente enlace:

[Descarga :musical_note:](https://mega.nz/file/UAEVEQTI#iPNuwvtsf-5aEXAzz1UmEV2msngMP6E_u0eCp1Z5vDc)

El resultado de la descarga nos va a dejar un archivo llamado `MediaPlayer.zip`.

```txt
MediaPlayer
	| Application Files
		| Todos los archivos de la aplicación
    | ReproductorMusicaTagEditables.application
	| setup.exe       
```

### Instalación

Ejecutamos el archivo :dvd:`setup.exe` y aceptamos en el asistente de instalación.
Con esto ya estaría instalado.

![Ejecutar App](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/ejecutarApp.png?raw=true)


### Seleccionar Directorio

![Seleccionar directorio](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/seleccionar.png?raw=true)

Desde el botón que se muestra en la imágen seleccionamos el directorio en el cual tenemos nuestra cancines.
Los formatos de archivos permitidos son: 

`MP3`, `M4A`, `WAV`.

![Directorio raiz de la música](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/seleccionDirectorio.png?raw=true)

> Si en el directorio seleccionado existen otros tipos de archivo o subdirectorios el programa toma todos los archivos validos existentes desde el directorio seleccionado sólo los archivos de audio.

![Canciones Cargadas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/cancionesCargadas.png?raw=true)

### Agregar Canciones

Para agregar canciones desde otro directorio simplemento los hacemos desde el botón `Agregar`, con esto se añaden las canciones a las ya cargadas desde el botón `Seleccionar`.

### Editar Tags

Dispone de las funcionalidades necesarias para editar los metadatos de los archivos de audio, a partir de esto podemos filtrar el contenido y discriminar a los archivos de audio
por Artista, Género, Álbum y Año de lanzamiento, junto con una imágen de la portada del álbum al cual pertenece el track contenido dentro del archivo de audio.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editorTags.png?raw=true)

#### Seleccionar directorio a editar

Desde el botón seleccionar podemos abrir el directorio que contiene las canciones que queremos editar, de esta forma, se van a enumerar el listado de canciones seleccionadas en el visor principal de la ventana de edición.

> Recomendación: Seleccionar un directorio con menos de mil canciones, ya que, si la cantidad de archivos de audio es muy elevada puede demorarle mucho tiempo al usuario editar cada archivo individualmente.
Otra recomendación que la edición sea por álbum, lo que facilita la tarea y permite una rápida edición.

##### Ejemplo

Álbum Live de ACDC.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editorMuestra.png?raw=true)

Para modificar los tags de una única canción simplemente la marcamos y modificamos los campos que se encuentran a la derecha.
Luego presionamos editar para que se lleve a cabo la modificación.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/modificarUnaCancion.png?raw=true)

De esta forma el programa va a discriminar la información cargada y va a filtrar el track en función de los campos suministrados por el usuario.

Para modificar varios tracks simplmente seleccionamos varias canciones y luego editamos la información en los campos de texto.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editarVariosTracks.png?raw=true)

Si lo que buscamos es editar todos los tracks seleccionados hay que pulsar el botón `Marcar todos`. Notaremos que todas las canciones quedarán seleccionadas y luego el mismo procedimiento anterior. Simplemente editamos la información en el panel de la derecha y pulsamos el botón `Editar`.

#### Enumerar Automáticamente

Si queremos enumerar los tracks de manera automática simplmente seleccionamos todos los tracks y luego presionamos el botón `Números`.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/formatearCampos.png?raw=true)

Y el resultado a esta operación es la siguiente:

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/formateados.png?raw=true)

### Pista

El track se representa en forma de cuadricula en la que cada tupla contiene la información del la canción a la cual hace referencia.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/pistaAudio.png?raw=true)

A través de este elemento podemos acceder a la página del artista o a la pagina del álbum al cual pertenece.

#### Página del Artista 

Si accedemos a la página del artista se vería como lo que se muestra a continuación.

![Página del artista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/paginaArtista.png?raw=true)

#### Página del Álbum

Si accedemos a la página del álbum se vería de la siguiente forma:

![Página del álbum](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/paginaAlbum.png?raw=true)

### Listas de reproducción

Existen varias maneras de agregar canciones a las listas de reproducción que vayamos generando.
Para empezar nos tenemos que ir a la opción `+ Mis Listas` del menú lateral. En este punto simplemente creamos la lista que queremos desde el botón `+ Agregar Lista` desde la esquina superior derecha.
Una vez creada la lista nos va aparecer el logo de una lista vacia con el nombre de la misma por debajo.
El paso siguiente es ir a las canciones que queremos agregar y utilizar los direrentes medios provistos para agregar dichas canciones al la lista.

![Crear Lista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/crearLista.png?raw=true)

Una vez creada la lista nos aparecerá referenciada desde su inicial en la parte inferior con el logo de lista vacía.

![Panel crear lista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/listaCreada.png?raw=true)

#### Agregar una cación a la lista

Para agregar una sola canción a la lista simplemente hacemos clic derecho sobre la pista de audio que deseamos agregar y luego, en el menú emergente, seleccionamos la opción `Agregar a lista`. Esto nos abrirá un panel con las siguientes opciones.

![Agregar canción a lista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/panelAgregarLista.png?raw=true)

Una vez agregada la canción, si nos dirijimos a `+ Mis Listas` notaremos que ahora la lista recién creada cuenta con una canción. Si hacemos clic en ella nos enviará a la página recién creada de la lista con la cación recién agregada.

![Página de la lista con una canción](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/paginaListaConUnaCancion.png?raw=true)

#### Agregar varias canciones a la lista

Aquí hay varias manera para obtener el resultado esperado.
Uno de ellos, es marcar cada una de las canciones que queremos agregar y utilizar el menú de botones emergente que nos permite acceder al panel para agregar canciones antes visto.

![Agregar menu emergente](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarMenuEmergente.png?raw=true)

Luego desde el panel que nos aparece, seleccionamos la lista de reproducción que deseamos y damos clic en el botón agregar y listo.

La segunda forma es desde el panel superior de la página de un álbum donde presionamos agregar, automáticamente se nos abrirá el panel antes visto para agregar canciones a las lista de reproducción con las canciones del álbum cargadas y listas para ser agregagadas.

![Agregar álbum género](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarAlbumGenero.png?raw=true)

Otra forma es desde la página de todos los álbumes, accediendo a ella a través del menú principal en la opción `Álbumes` del menú lateral.
En esta página buscamos el álbum que nos interesa y hacemos clic derecho sobre el mismo. De esta forma se nos abrirá el panel para agregar canciones a la lista.

![Agregar álbum](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarAlbum.png?raw=true)

Otra forma es desde la página de artistas haciendo clic derecho sobre el álbum y realizando el mismo procedimiento antes visto.

![Agregar álbum](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarDesdeArtista.png?raw=true)

El resultado a todo los visto sobre la creación de las listas de reproducción es el siguiente:

![Miniatura de la lista creada](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/resultadoListaCreada.png?raw=true)

Y dentro de la página de la lista: 

![Página lista creada](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/paginaListaCreada.png?raw=true)

#### Borrar lista de reproducción

Para borrar una lista completa de reproducción simplmente vamos a la pestaña `+ Mis Listas` del mnú principal y con un clic derecho sobre la lista a eliminar seleccionamos eliminar lista.

![Eliminar lista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/eliminarLista.png?raw=true)

#### Borrar una canción de la lista

Para eliminar una sola canción de la lista, simplemente accedemos a la lista, luego en la canción que queremos eliminar hacemos clic derecho y seleccionamos la opción eliminar de la lista.

![Eliminar lista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/eliminarCancion.png?raw=true)

### Navegación por la aplicación

La navegación se realiza a través del menú principal que se encuentra en la parte lateral izquierda. A través de las opciones allí expuestas podemos acceder al contenido buscado de manera sencilla.
Se puede navegar también a través de los enlaces internos de cada una de las páginas que permiten un rápido acceso al contenido buscado. 
Para llevar a cabo una navegación sencilla, en las páginas `Artista`, `Álbumes`, `Géneros` y `Mis Listas` existe un elemento paginador en la parte inferior de las páginas, a través de este elemento podemos encontrar el contenido buscado por su inicial.

Por ejemplo: 

Si buscamos el artista `ACDC` nos vamos a la pestaña `Artistas` y en la parte inferior seleccionamos la letra `A`, a partir de esto se mostrarán por pantalla todos los artistas cuya inicial es la letra `A`.
Lo mismo para las otras páginas, buscamos por su inicial y encontramos el contenido filtrado.

![Navegación 1](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/navegacion1.png?raw=true)

Dentro de las páginas internas tambien disponemos de elementos para navegar de manera eficiente. Uno de ellos es el botón para ir a la página anterior que se encuentra en todas las páginas internas
como se muestra en la siguiente imágen.

![Navegación 2](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/navegacion2.png?raw=true)

Otra forma de acceder de manera rápida al contenido es a través del bloque de información en la página de un álbum, más especificamente el enlace con el nombre del artista.

![Navegación 3](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/navegacion3.png?raw=true)

### Reproducción

Es uno de los apartados más sencillos pero no menos importantes. En este caso, existen varias formas de cargar canciones para reproducir.

Apenas inicia la aplicación desde el botón `Play` en la zona inferior en el controlador de reproducción del reproductor.

![Reproducir 1](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/reproducir1.png?raw=true)

Desde el botón Play podemos reproducir la canción cargada actualmente. Si la app fué cerrada, y luego, se vuelve a ejecutar, la canción en curso, álbum o lista a la cual pertenezca se recuperará.

> Desde el botón `Random` la reproducción no será secuencial, irá saltando de canciones cuendo la misma cambie.

Otra cosa importante:

> Desde los botones `>>` y `<<` podemos pasar a la canción siguiente o anterior respectivamente. Pero cual sería la canción actual, anterior o siguiente ?.
Bueno, esto va a depender del listado que tengamos cargado, si pusimos a reproducir un álbum, entonces las canciones que se iran reproduciendo serán las del álbum. 
Si por el contrario, las canciones pertenecen a una lista de reproducción, se van a reproducir las canciones de la lista de reproducción.
En el caso que estemos reproduciendo las canciones de un artista (y no sólo un álbum) el resultado es que se van reproducir todas las canciones de determinado artista.
Lo mismo pasa con los géneros.

#### Ejemplo 2

![Play artista](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/playArtista.png?raw=true)

Lo mismo aplica para los álbumes, listas o géneros cargados.

### Descargas

Para descargar videos de `Youtube` y quedarnos sólo con el audio, el programa dispone de un apartado para realizar esta tarea.

![Descargas1](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/descargas1.png?raw=true)

La cantidad de videos simultaneos que podemos descargar varía según las necesidades del usuario. 
Por ejemplo si queremos descargar todo un album simplemente agregamos los enlaces de los videos en el campo URL y luego pulsamos `Convertir`.

#### Ejemplo 3

En este ejemplo vamos a descargar 3 canciones de 3 videos de Youtube.

![Descargando](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/descargando.png?raw=true)

En esta imágen hay 3 videos en proceso de descarga, a la espera de su finalización los controles quedan bloqueados.

Una vez finalizada la descarga de todos los videos la pantalla se vería de esta manera.

![Descarga Finalizada](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/descargaFinalizada.png?raw=true)

Ahora, en este estado, las canciones están almacenadas en un directorio dedicado. Para poder disponer de las mismas hay que editarlas y moverlas a un directorio seleccionado por el usuario.
Podemos mover los archivos sin editar, pero en este caso, el programa no va a poder reconocer la información de los metadatos del archivo.

Pulsamos el botón editar y se abrirá el editor de tags de la aplicación ya visto en secciones anteriores.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editorDescargas.png?raw=true)

Como podemos ver en la imágen los metadatos son desconocidos. Para cambiar este situación y formatear los campos vamos a editarlos.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editarDescargasInfo.png?raw=true)

Cuando seleccionemos todas las pistas vamos a poder editar (Artista, Álbum, Género, Año de lanzamiento e imágen).

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editadosDescargas.png?raw=true)

Ahora vamos a editar los números de pistas.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editarNumeros.png?raw=true)

Por último editamos los nombres de las canciones selecciondo las mismas de a una a la vez.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/editarTitulos.png?raw=true)

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/finEdicion.png?raw=true)

Una vez editadas las canciones sólo queda moverlas a un directorio seleccionado por el usuario. Esto lo hacemos con el botón `Mover`.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/audioMovido.png?raw=true)

El resultado de todo lo que hicimos es el siguiente.

> Importante: Todos los archivos movidos desde la sección descargas son añadidos a las canciones que ya teniamos anteriormente sin necesidad de incorporarlas desde el directorio seleccionado.

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/artistaDesc.png?raw=true)

Y el interior de las descargas es:

![Editor de descargas](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/cancionesDesc.png?raw=true)

En este caso, las canciones quedan disponibles hasta borremos los enlaces con el botón seleccionar desde la aplicación. Si no reiniciamos el directorio raíz las canciones van a estar disponibles.


