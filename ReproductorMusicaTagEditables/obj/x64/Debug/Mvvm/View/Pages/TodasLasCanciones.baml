   M S B A M L   `   `   `  ����X  TReproductorMusicaTagEditables, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Eclr-namespace:ReproductorMusicaTagEditables.Controls.InfoCancionTabla7ReproductorMusicaTagEditables.Controls.InfoCancionTabla  5      k:clr-namespace:ReproductorMusicaTagEditables.Mvvm.ViewModel,ReproductorMusicaTagEditables.Mvvm.ViewModel  5      {Bclr-namespace:ReproductorMusicaTagEditables.Controls.AgregarALista4ReproductorMusicaTagEditables.Controls.AgregarALista  5
      u?clr-namespace:ReproductorMusicaTagEditables.Controls.CampoTexto1ReproductorMusicaTagEditables.Controls.CampoTexto  5      E    ?ReproductorMusicaTagEditables.Mvvm.View.Pages.TodasLasCanciones   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      WtuplaEclr-namespace:ReproductorMusicaTagEditables.Controls.InfoCancionTabla     5      P	viewModel:clr-namespace:ReproductorMusicaTagEditables.Mvvm.ViewModel     5      j fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a8fa-http://metro.mahapps.com/winfx/xaml/iconpacks   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5	      YagregarCancionesBclr-namespace:ReproductorMusicaTagEditables.Controls.AgregarALista  5
      Jbusq?clr-namespace:ReproductorMusicaTagEditables.Controls.CampoTexto  5        N� Title$  TodasLasCanciones��5       � 	Resources 5       �� Source�� 5   
   $4 ./Mvvm/View/Pages/Theme/generalesPageTheme.xaml?�6   %     � DataContext 5      E   ?ReproductorMusicaTagEditables.Mvvm.ViewModel.PrincipalViewModel  5   
   -   5        panelPrincipal��5   '   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��55 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��Center=�6    � ColumnDefinitions 5       �� 5!      �� 5"      $	��650 �6#   .+�5%      ��    tituloPrincipalPaginas#��[  6   ��5&      ��  �� Path$ Irg.TitutloVentana��� 5'      $��1��6   $��Right=�5(      $��Center=�5)       �� Orientation$ 
Horizontal=�5*      .+�5+      )  #MahApps.Metro.Controls.ProgressRing  $��0 0 10 0q�5,      
���  ��   IsActive 5.      �� *Irg.Preloader+�� 5/        btnSeleccionar#��[ 6   $��0 0 10 0q�50      
���  ��	 � ToolTip$	 Seleccionar directorio��53      ��51      �� *CargarMusicaCommand+{�54      �� *Habilitados+.��55      �� $ 
Horizontal=�6!   .+�56      1  +MahApps.Metro.IconPacks.PackIconFontAwesome    btnIconSelecionar#��[ 61   
   Kind$
 FolderPlusSolid=�6\   �� 57      $��Seleccionar��6$   69   58      59      �� 5:      -   5        #��[ 5:      $	 Editar tags��5;      $��0 0 10 0q�5<      {�5>      �� *Habilitados+.��5?      �� $ 
Horizontal=�6!   .+�5@        #��[ 61   $
 TagSolid=�6\   �� 5A      $
��Tags��6$   5B      5C      �� 5E      #��[ 6   $+	 %Agregar canciones a las ya existentes��5F      ��5G      �� *AgregarCommand+{�5H      �� *Habilitados+.��5I      �� $ 
Horizontal=�6!   .+�5J        #��[ 61   $
 	PlusSolid=�5K   1   �� 5L      $��Agregar��6$   65   5M      5N      5P      5R      � 5T   
   $��1��6   $
��0 10q�6    5U      �� 5V      $	��600 �6#   �� 5W      .+�5Z      �� $ 
Horizontal=�6   .+�5[      �� $��Todas las Canciones��5\      $��Center=�5]      
�������$��22(�5_      �� 5`      $��Center=�5b      ���#ccc$��12(�5d      $��0 4 0 0 q�5e      ��5a      �� *CantidadCanciones+5e      �� 5f      -   5          btnEliminarHistorial#��[ 5f      $	 Últimos escuchados.��5g      $��15 0 0 0q�67   y�5h      �� *HayHistorial+.��5i      �� $ 
Horizontal=�6!   .+�5j          iconEliminarHistorial#��[ 61   $
 HistorySolid=�6`   �� 5k        txtEliminacion#��[ 6$   $��Más Recientes��6L   $��5 0 0 0q�6a   5l      5m      �� 5n      -   5        #��[ 5n      $	 Listas de regalo.��5o      $��15 0 0 0q�65   y�5p      �� *RegalosVisibilidad+.��5q      �� $ 
Horizontal=�6!   .+�5r        #��[ 61   $
 	GiftSolid=�6`   
���  ��6q   5s      5t      5u      O   IReproductorMusicaTagEditables.Controls.AgregarALista.AgregarAListaControl  5z      -   5          Name$ agregarControl��5|   5   O   IReproductorMusicaTagEditables.Controls.AgregarALista.AgregarAListaControl   AgregarClick$! agregarControl_AgregarClick��5}   5      DesmarcarClick$# agregarControl_DesmarcarClick��5~   5   $��Right=�5z   5   $��1��5{   5   5~   5   5�      �� 5�   
   $��2��6   $
��3500��6   
���   � J� Opacity$ 0Q�6>   $��-1300 0 0 0 q�5�      y�5�      �� *CapaProtectora+5�      �� 5�   
   -   5         ��Name$ txtSinCanciones��5�      $��No hay canciones cargadas��5�      ���#ccc$��2��5�      $��22(�5�      $��Center=�5�      $��Center=�5�      y�5�      �� *Irg.IsMensajeVisible+�� 5�   
   -   5         ��Name$ scrollCanciones��5�      $��2��5�      $
��Auto=�5�      y�5�      �� *Irg.IslistadoVisible+.��5�      �� -   5         ��Name$ itemList��5�      ��6.   �� *
Irg.Partes+��5�      �� 5�      .R�5�      �� 5�      ��5�      �� 5�      .R�5�      N   HReproductorMusicaTagEditables.Controls.InfoCancionTabla.InfoCancionTabla  N   HReproductorMusicaTagEditables.Controls.InfoCancionTabla.InfoCancionTabla   	PlayClick InfoCancionTabla_PlayClick5�   1      ArtistaClick! InfoCancionTabla_ArtistaClick5�   1      
AlbumClick InfoCancionTabla_AlbumClick5�   1      
MouseLeave InfoCancionTabla_MouseLeave5�   1      
Habilitado .     Comando 5�   1   ��  �� ElementName$ panelPrincipal��$ PlayCommand�   ParametroComando 5�   1   �� *.+   
NumeroInfo 5�   1   �� *Numero+   
TituloInfo 5�   1   �� *Titulo+   ArtistaInfo 5�   1   �� *	Artista+   	AlbumInfo 5�   1   �� *Album+   
GeneroInfo 5�   1   �� *Genero+   AnoInfo 5�   1   �� *FechaLanzamiento+    DuracionInfo  5�   1   �� *
Duracion+!   
ColorTexto! 5�   1   �� *EstadoColor+"   HabilitadoCarga" 5�   1   �� $ panelPrincipal��$ Habilitados�5�      5�      5�      5�      5�      5�      