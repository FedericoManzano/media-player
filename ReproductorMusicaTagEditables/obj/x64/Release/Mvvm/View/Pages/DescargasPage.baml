   M S B A M L   `   `   `  ���� X  TReproductorMusicaTagEditables, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:ReproductorMusicaTagEditables.Mvvm.ViewModel,ReproductorMusicaTagEditables.Mvvm.ViewModel  A    ;ReproductorMusicaTagEditables.Mvvm.View.Pages.DescargasPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P	viewModel:clr-namespace:ReproductorMusicaTagEditables.Mvvm.ViewModel     j fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a8fa-http://metro.mahapps.com/winfx/xaml/iconpacks   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f:control,http://metro.mahapps.com/winfx/xaml/controls    N� Title$  DescargasPage�� � 	Resources  �� Source�� $4 ./Mvvm/View/Pages/Theme/generalesPageTheme.xaml?�%     � DataContext E   ?ReproductorMusicaTagEditables.Mvvm.ViewModel.DescargasViewModel  -   descargarViewModel��.��� $��15q� � ColumnDefinitions �� �� $	��76* � � RowDefinitions �� $	��100 ��� $��* ��� $��5 �.+�� $��2�� �� .+���  �� Orientation$ 
Horizontal=�$��Center=�.+�1  +MahApps.Metro.IconPacks.PackIconFontAwesome     Kind$ YoutubeBrands=�$��0 7 10 0q�$��80��$��80��
���  ���� 
�������$��35(�$
��0 23q����� *Irg.TitutloVentana+  $ 	BellSolid=�$��Center=�$��35��$��35��$��10 0 0 0q�
���  �� � ToolTip$X RExisten canciones descargadas y convertidas. Las puede ver desde el botón editar.��y��� *NotificacionCancion+� $��1��$��2��.+��� .+��� $
��0 15q�.+��� $��Formato��
�������$��18(�$��0 15 0 0q��� -   	 ��Name$	 
selectores��$ 
Horizontal=�$��0 15 0 0q�.+�	� -   
 	�Name$	
 mp3�� d� 	IsChecked$
 trueY�   radioSelector#��[  $ Convertir a mp3��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�  -     Name$ iconMp3��$ CircleSolid=�
���  ���� $	��MP3��
���  ��$��5 0 0 0q�	� -   $	
 wav��$ falseY�#��[  $��10 0 0 0q�$ Convertir a wav��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�  -   $ iconWav��$ CircleRegular=�
���  ���� $	��WAV��
���  ��$��5 0 0 0q�	� -   $	
 m4a��$ falseY�#��[  $��10 0 0 0q�$ Convertir a m4a��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�  -   $ iconM4a��$ CircleRegular=�
���  ���� $	��M4A��
���  ��$��5 0 0 0q��� .+��� $ 
Horizontal=�.+��� $ ��URLs de videos a convertir��
�������$��18(�$
��0 15q��� $��Descargado...��
���  ��$��18(�$��7 0 0 0q�$��Center=��� 
���  ��$��18(�$��7 0 0 0q�$��Center=����� *CantidadDescargando+�� $
��Auto=�$	��200��.���� -	    ��Name$ itemDescargas������ .R��� �� $ 
Horizontal=�$��0 30 0 0q�.+��� -
     
btnGeneral#��[ 
���P��
�������$! Editar archivos descargados��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�    btnIcon#��[ $ TagSolid=��� $��Editar��
�������$��5 0 0 0q��� -   #��[ 
�������
���   �$
��10 0q�$, &Mover archivos a una ruta seleccionada��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�  #��[ $ DirectionsSolid=�
���   ��� $��Mover��
���   �$��5 0 0 0q��� -   #��[ 
���  ��
�������$ Borrar todos los archivos��{��� *HabilitarBotones+.���� $ 
Horizontal=�.+�  #��[ $ 
BroomSolid=��� $��Eliminar��
�������$��5 0 0 0q��� $��10 0 0 0q�.+��� $H��BNo Cambie de página mientras el proceso de descarga está activo.��
���  ��$��15(�y��� *MjeDescargaActivado+�� $��1��$	��250��$	��600��$��-327 -20 0 0q�
���   � J� Opacity$	 0.8Q�$��Center=�$��Center=�y��� *MjeDescargaActivado+._�)  #MahApps.Metro.Controls.ProgressRing  
���  ��$��70��$��70��