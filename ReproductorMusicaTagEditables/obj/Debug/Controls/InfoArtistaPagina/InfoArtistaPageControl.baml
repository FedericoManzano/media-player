   M S B A M L   `   `   `  ����!  ReproductorMusicaTagEditablesU    OReproductorMusicaTagEditables.Controls.InfoArtistaPagina.InfoArtistaPageControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      j fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a8fa-http://metro.mahapps.com/winfx/xaml/iconpacks   5      -   5          >�Name$  infoArtista��5       � 	Resources 5
       �� Source�� 5   
   $; 5/Controls/InfoArtistaPagina/InfoArtistaPageTheme.xaml?�6   %    .��5      ��    bordePrincipal#��[  6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��190 �6#   �� 5      .+�5      ��   bordeImagen#��[ 6   ��6:   ��  �� ElementName$ infoArtista�� �� Path$ ImagenArtista��� 5      $��1��6   $��10 0 0 0q�6)   .+�5      ��   nombreArtista#��[ 6   ��5      �� $ infoArtista��$ NombreArtista��� 5       �� Orientation$ 
Horizontal=�6   $
��0 10q�66   .+�5      �� $��Artista��6      txtDatos#��[ 5       6D   �� 5      $��·��6    #��[ 5       $
��10 0q�5       60   �� 5       
�������#��[ 6g   ��6    �� $ infoArtista��$ Genero�6�   5!      �� 5"      $ 
Horizontal=�6   $
��0 10q�66   .+�5#      �� #��[ 5$   !   ��5#       �� $ infoArtista��$ CantidadAlbumes�5$   E   �� 5%      $��·��6    #��[ 5&       $
��10 0q�5'       60   �� 5(      
�������#��[ 6s   ��6    �� $ infoArtista��$ HorasReproduccion�6�   5)      �� 5*      $ 
Horizontal=�6   $
��0 10q�66   .+�5+      ��   
btnPlayAll#��[ 6    � ToolTip$0 *Reproducir todas las canciones del artista��5-      ��5,      �� $ infoArtista��$ PlayArtista�.��5.      �� $ 
Horizontal=�6%   .+�5/      1  +MahApps.Metro.IconPacks.PackIconFontAwesome     Kind$ PlayCircleRegular=�65   $��0 0 10 0q�6N   �� 50      $��Reproducir Todo��6(   51      52      53      54      55      56      57      