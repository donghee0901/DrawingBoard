   M S B A M L   `   `   `  ����G  CDrawingBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DrawingBoardDrawingBoard  5   	       DrawingBoard.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DrawingBoard     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5        $	��abc��5	   	     � Title$  Drawing Board��5
   	   $	��500��6   $
��1000��6,   
���   � � Icon$" ./image/DrawingBoradIcon.png��5   *   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �  K� ZIndex$ 1��6   $��0��6    .+�5      ��  �� Orientation$ 
Horizontal=�6   
�������.+�5      �� -   5        $��50��5      $��59��6$   $
��Left=�6/   $	��Top=�6J   $��./image/LineButton.png��6b   6�   �� 5      -   5        $��50��5      $��59��6$   $
��Left=�6/   $	��Top=�6J   $!��./image/RectangleButton.png��6b   6�   �� 5      -   5        $��50��5      $��59��6$   $
��Left=�6/   $	��Top=�6J   $ ��./image/TriangleButton.png��6b   6�   �� 5      -   5        $��50��5      $��59��6$   $
��Left=�6/   $	��Top=�6J   $��./image/CircleButton.png��6b   6�   � 5      .+�5      �� $��50��6   $��67��6(   $
��Left=�63   $	��Top=�6N   $!��./image/FillColorBorder.png��6f   $��
0,0,0,-0.4q�6�   #  Xceed.Wpf.Toolkit.ColorPicker  5      -   5        $��FillColorPicker��5   8   $ 1��6'   $
��Left=�6O   $	��Top=�6j   $��30��6�   $��50��6�      DisplayColorAndName .  $��9 15 0 0q�6�   5      � 5      .+�5      �� $��50��6   $��67��6(   $
��Left=�63   $	��Top=�6N   $!��./image/LineColorBorder.png��6f     5      -   5        $��LineColorPicker��5   8   $ 1��6'   $
��Left=�6O   $	��Top=�6j   $��30��6�   $��50��6�    .  $��9 15 0 0q�6�   5      � 5       $��50��6   $��67��6#   .+�5!      �� 
�������
���   �6-   �� 5"      $��
선 굵기��6   $��8(�6+   $
��Bold"�68   $	��Top=�6J   $��Center=�6b   $��Center=�6�   $��Center=�6�   �� 5#      -   5        $��
LineStroke��5#      $��1��6U   $��27��6^   $��57��6j   $��Bottom=�6u   $��Center=�6�   $��5 5 5 5q�6�   
�������
���   �$��Center=�6�   $��Center=�6  5$      5%      5&      � 5(   
   $ 0��6   $��1��6    
���   �.+�5)      �� -	   5        $��
MainCanvas��5)      6e   5*      5+      5,      