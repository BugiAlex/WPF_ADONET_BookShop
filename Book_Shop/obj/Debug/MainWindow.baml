   M S B A M L   `   `   `  ����D  @Book_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Book_Shop	Book_Shop  5   	       Book_Shop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Book_Shop     5   	     � Title$  Welcome!��5      $	��400��6   $	��350��6&    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I    � 	Resources 5	         ButtonTemplate �� 
TargetType �� CornerRadius �� TextAlignment �� StrokeDashArray �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value��%�  &	        �� 5
   
   " ��61   .R�5      �� $��Border��5   9   
����  �$��3q�5   (   $ 10��6<   
���   �
��� ���$ Center=�5   G   ._�5      � .+�5      �� $��FocusCue��6    $y�Hidden=�60   
����  �$��1��5      $	 1 2R�6    68   �� 5      ��. #��z��5   
   6/   5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ Border��6    � ��
 ��  �6G   5      P� 5      	 � ��
 . . �5      �� $ Border��6    � ��
 � ���6G   �� 5      $ Border��6    � ��
 �k���6H   5      P� 5      	 �@J�IsKeyboardFocused
 . . �5      �� $ FocusCue��6    � y�$ Visible=�6I   5      P� 5      	 � {�
 .  . �5       �� $ Border��6    � ��
 �����6Q   �� 5!      $ Border��6    � ��
 �   �6G   5"      5%      5'      ��5(      �� 5)   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5*      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5+      $ 	#FF06C4EE��6   $ 1Q�6-   5,      .��5.      �  � ColumnDefinitions 5/   
   �� 50      $	��36* �6   �� 51      $	��13* �6    � RowDefinitions 53   
   �� 54      $��2* �6   6*   �� 55      $��4* �6   6*   �� 56      $��4* �6   6*   �� 57      $��2* �6   6*   �� 58      $��2* �6   6*   .+�5<   
   �� $��Center=�6   $
��Wrap=�62   $��	Book Shop��6F   $��Center=�6W   $��20(�6r   $��Cooper Black)�6�   $
��Bold"�6�   $��2��6�   $��27,12,27,11q�6�   ��5=      �� 5>      $ 0.5,1&�6&   $ 0.5,0&�67   .��5?      � $ 	#FFE8932D��6#   $ 0Q�65   � 5@      $ 	#FFE9FF00��6#   $ 1Q�65   5A      5C      �� 5D   
   $��Login��6   $��Center=�6#   $��60��6@   $��22,16q�6L   $��1��6[   $��Center=�6h   $	��250��6�   
����  �
��� ���$��Cooper Black)�6�   $��Italic$�6�   $��15(�6�   $��2��6�   .��5E      �� $
��Left=�6   $��25��61   $��	10,10,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $	��Top=�6e   $	��220��6}   ���	#FFEDF70D���	#FF999FDE���	#FF060223$��18(�6  ��6�   �� *
LoginCheck+ �� UpdateSourceTrigger$ PropertyChanged=�6  5F      �� 5G   
   $��Password��6   $��Center=�6&   $��60��6C   $��22,16,22,15q�6O   $��2��6d   $��Center=�6q   $	��250��6�   
����  �
��� ���$��Cooper Black)�6�   $��Italic$�6�   $��2��6�   $��15(�6   .��5I      G� -   5         G�Name$ PasswodrBox1��5I      $
��Left=�60   $��25��6K   $��	10,10,0,0q�6W   $	��Top=�6k   $	��220��6�   ���	#FF999FDE
��� ������	#FF060223$��18(�6�   5K      5L      � 5N   
   $��3��6   $��2��6    5P      �� 5Q      $��* �6#   6/   �� 5R      $��* �6#   6/   .+�5U      �� $��Login��6   $��Center=�6%   $��Center=�6B   $	��100��6]   #��[  6�   $��Cooper Black)�6�   $��Italic$�6  ��6j   �� *EnterCommand+��6�   ��  �� ElementName$ PasswodrBox1��6  �� 5V      -   5        $��Cancel��5V      $��Center=�6&   $��1��6D   $��Center=�6T   $	��100��6o   #��[  6�   $��Cooper Black)�6�   $��Italic$�6�   5X      �� 5Y   
   -   5        $��Registration��5Y      $��Center=�6(   $��4��6F   $��Center=�6S   $	��200��6n   #��[  6�   $��Cooper Black)�6�   $��Italic$�6�   $��2��6�   $��47,12q�6   5[      5\      