# Manual Media Player

## Indice de contenidos

* [Seleccionar directorio](#seleccionar-directorio)
* [Agregar canciones](#agregar-canciones)
* [Editar tags](#editar-tags)
	* [Seleccionar directorio a editar](#seleccionar-directorio-a-editar)
		* [Ejemplo 1](#ejemplo)
	* [Enumerar Automáticamente](#enumerar-automáticamente)
* [Pista de audio](#pista)
	* [Página del artista](#página-del-artista)
	* [Página del álbum](#página-del-álbum)
* [Listas de reproducción](#listas-de-reproducción)
	* [Agregar canción](#agregar-una-cación-a-la-lista)
	* [Agregar varias canciones](#agregar-varias-canciones-a-la-lista)

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
El paso siguiente es ir a las canciones que queremos agregar y utilizar los direrentes medios proveistos para agregar dichas canciones al la lista.

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
Uno de ellos, es marcar cada una de las canciones que queremos agregar y utilizar el menú de botones emergente que nos permite acceder al paner de agregar canciones antes visto.

![Agregar menu emergente](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarMenuEmergente.png?raw=true)

Luego desde el panel que nos aparece, seleccionamos la lista de reprucción que deseamos y damos clic en el botón agregar y listo.

La segunda forma es desde el panel superior de la página de un álbum donde presionamos agregar, automáticamente se nos abrirá el panel antes visto para agregar canciones a las lista de reproducción con las canciones del álbum cargadas y listas para ser agregagadas.

![Agregar álbum género](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarAlbumGenero.png?raw=true)

Otra forma es de la página de todos los álbumes, accediendo a ella a través del menú principal en la opción `Álbumes` del menú lateral.
En esta página buscamos el álbum que nos interesa y hacemos clic derecho sobre el mismo. De esta forma se nos abrirá el panel para agregar canciones a la lista con 

![Agregar álbum género](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarAlbum.png?raw=true)

Otra forma desde la página de artistas haciendo clic derecho sobre el álbum y realizando el mismo procedimiento visto.

![Agregar álbum género](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/agregarDesdeArtista.png?raw=true)
