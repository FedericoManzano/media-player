   M S B A M L   `   `   `  ���� X  TReproductorMusicaTagEditables, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags;ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags  u?clr-namespace:ReproductorMusicaTagEditables.Controls.CampoTexto1ReproductorMusicaTagEditables.Controls.CampoTexto  �Vclr-namespace:ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.HandlerEditorTagsHReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.HandlerEditorTags  G    AReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.EditarTags   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     j fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a8fa-http://metro.mahapps.com/winfx/xaml/iconpacks   WtuplaIclr-namespace:ReproductorMusicaTagEditables.Controls.InfoCancionTablaTags   Mtexto?clr-namespace:ReproductorMusicaTagEditables.Controls.CampoTexto   h	viewModelVclr-namespace:ReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.HandlerEditorTags   -     � Title$  
EditarTags��$	��770��$
��1260�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $/ )/Mvvm/VentanasUtilitarias/TagsThemes.xaml?�%     � DataContext ^   XReproductorMusicaTagEditables.Mvvm.VentanasUtilitarias.HandlerEditorTags.EditorViewModel  -   
editorTags��.����  �� CornerRadius$ 10��   bordeVentana#��[  $��2q�._��� $ 10��  gradientePrincipal#��[ 	 �� Padding$	 40q�._�� 
 � ColumnDefinitions
 �� $	��850 ��� .+�� $��0�� � RowDefinitions �� $��80 ��� $��80 ��� $��* �.+��� $��Gestor de Tags��$��35(�
�������$��Center=���  �� Orientation$ 
Horizontal=�$��Center=�$��1��.+��� -     
btnPlayAll#��[ ���#ccc � ToolTip$D >Seleccionar todas las pistas o deseleccionar todas las pistas.��.���� $ 
Horizontal=�.+�1  +MahApps.Metro.IconPacks.PackIconFontAwesome     Kind$ SquareRegular=��� $��Marcar Todos��$��5 0 0 0q��� -   #��[ $��10 0 0 0q�$H BSeleccionar directorio donde se encuentran las canciones a editar.��.���� $ 
Horizontal=�.+�  $ FolderOpenSolid=��� $��Seleccionar��$��5 0 0 0q��� $��2��$��Center=�$��Center=�y��� *
MjeVacio+.+��� $$��No Hay Canciones seleccionadas��
�������$��30(�$��Center=�$��Center=��� $:��4Seleccione las canciones desde el botón seleccionar�����#ccc$��18(�$��Center=�$��Center=��� -    ��Name$ scrollCanciones��$��2��$
��Auto=�.���� -    ��Name$ itemList������ *TodosLosItems+���� .R��� � $��1��$��30 0 0 0q� �� $��80 ��� $��80 ��� $��* ��� $��80 �.+��� $ 
Horizontal=�$��Center=�$��1��$��5 0 0 0q�.+��� -   #��[ 
�������$" Limpiar los campos de texto.��.���� $ 
Horizontal=�.+�  $ 
BroomSolid=��� $��Limpiar Campos��$��5 0 0 0q��� -   #��[ $��10 0 0 0q�$A ;Generar los numeros de canciones en los traks seleccionados��.���� $ 
Horizontal=�.+�  $ SortNumericDownAltSolid=��� $��Números��$��5 0 0 0q��� $��2��.+�I   CReproductorMusicaTagEditables.Controls.CampoTexto.CampoTextoControl  -	     Name$ 	txtNumero��  
campoTexto#��[    PlaceholderTexto$ Número��$ Asignar número de track.��   Texto �� *Numero+ �� Mode$ TwoWay=�  -
   $ 	txtTitulo��#��[ $ Asignar título de track.��$ Título�� �� *Titulo+$ TwoWay=�  -   $ 
txtArtista��#��[ $/ )Asignar nombre de artista de/los track/s.��$ Artista�� �� *	Artista+$ TwoWay=�  -   $ txtAlbum��#��[ $/ )Asignar nombre del álbum de/los track/s.��$ Álbum�� �� *Album+$ TwoWay=�  -   $ 	txtGenero��#��[ $% Asignar género de/los track/s.��$ Género�� �� *Genero+$ TwoWay=�  -   $ txtAno��#��[ $1 +Asignar año de lanzamiento de/los track/s.��$
 Año�� �� *Ano+$ TwoWay=��� $ 
Horizontal=�$��0 15 0 0q�.+��� -    ��Name$ imagenAlbum��$��80��$��80�� � Cursor$
 Hand������ *Imagen+$ TwoWay=��� -   #��[ $��10 0 0 0q�
����·�$^ XEditar las canciones seleccionadas con la información provista en los campos de arriba.��.���� $ 
Horizontal=�.+�  $ EditRegular=��� $��Editar��$��5 0 0 0q�� $��3��$��Right=�.+��� -   #��[ 
�������.���� $ 
Horizontal=�.+�  $ DoorClosedSolid=��� $��Salir��$��5 0 0 0q�