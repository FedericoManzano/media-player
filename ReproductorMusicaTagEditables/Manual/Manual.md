# Manual Media Player

## Indice de contenidos

* [Seleccionar Directorio](#seleccionar-directorio)
* [Agregar Canciones](#agregar-canciones)
* [Editar Tags](#editar-tags)
	* [Seleccionar directorio a editar](#seleccionar-directorio-a-editar)
		* [Ejemplo 1](#ejemplo)
	* [Enumerar Automáticamente](#enumerar-automaticamente)

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
por Artista, Género, Álbum y Año de lanzamiento, junto con una imágen de la portada del álbum al cual pertenece el archivo de audio.

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

Si lo que buscamos es editar todos los tracks seleccionados hay que pulsar el botón `Marcar todos`. Notaremos que todas las canciones quedarán seleccionadas y luego el mismo procedimiento alterior simplemente editamos la información en el panel de la derecha y pulsamos el botón `Editar`.

#### Enumerar Automáticamente

Si queremos enumerar los tracks de manera automática simplmente seleccionamos todos los tracks y luego presionamos el botón `Números`.

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/formatearCampos.png?raw=true)

Y el resultado a esta operación es la siguiente:

![Editor Tags](https://github.com/FedericoManzano/media-player/blob/master/ReproductorMusicaTagEditables/Manual/Imagenes/formateados.png?raw=true)
