   M S B A M L   `   `   `  ����!  ReproductorMusicaTagEditablesS    MReproductorMusicaTagEditables.Controls.InfoAlbumPagina.InfoAlbumPaginaControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a8fa-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5          >�Name$  	infoAlbum��5       � 	Resources 5
       �� Source�� 5   
   $9 3/Controls/InfoAlbumPagina/InfoAlbumPaginaTheme.xaml?�6   %    .��5      ��    bordePrincipal#��[  6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5      .+�5      ��   bordeImagen#��[ 6   ��6:   ��  �� ElementName$ 	infoAlbum�� �� Path$ ImagenAlbum��� 5      $��1��6   $��10 0 0 0q�6)   .+�5      ��   nombreArtista#��[ 6   ��5      �� $ 	infoAlbum��$ NombreAlbum��� 5       �� Orientation$ 
Horizontal=�6   $
��0 10q�66   .+�5      �� $��Artista��6      txtDatos#��[ 5       �� 5      $��·��6    #��[ 5       $
��10 0q�5        60   �� 5!      -   5          
btnArtista#��[ 5"      ��5!      �� $ 	infoAlbum��$ NombreArtista�5%      5&      �� 5'      $ 
Horizontal=�6   $
��0 10q�66   .+�5(      �� #��[ 5)   !   ��5(       �� $ 	infoAlbum��$ CantidadCanciones�5)   !   �� 5*      $��·��6    #��[ 5+       $
��10 0q�5,       �� 5-      
�������#��[ 6e   ��6    �� $ 	infoAlbum��$ Horas�6�   5.      �� 5/      $ 
Horizontal=�6   $
��0 10q�66   .+�50      ��   
btnPlayAll#��[ 6    � ToolTip$/ )Reproducir todas las canciones del álbum��53      ��51      �� $ 	infoAlbum��$ ReproducirCommand���52      �� $ 	infoAlbum��$ ReproducirParamCommand�.��54      �� $ 
Horizontal=�6%   .+�55      1  +MahApps.Metro.IconPacks.PackIconFontAwesome     Kind$ PlayCircleRegular=�65   $��0 0 10 0q�6N   �� 56      $��Reproducir Todo��6(   57      58      �� 59      -   5        #��[ 59      
�������$��10 0 0 0q�5:   /   $< 6Agregar canciones del artista a lista de reproducción��5;      .��5=      �� $ 
Horizontal=�6%   .+�5>        $ 	PlusSolid=�65   $��0 0 10 0q�6F   �� 5?      $��Agregar��6(   5@      5A      �� 5B      -   5        #��[ 5B      
�������$��10 0 0 0q�5D      $* $Modificar la metadata de los tracks.��5E      .��5G      �� $ 
Horizontal=�6%   .+�5H        $ TagSolid=�65   $��0 0 10 0q�6E   �� 5I      $��	Modificar��6(   5J      5K      5L      5M      5N      5O      5P      