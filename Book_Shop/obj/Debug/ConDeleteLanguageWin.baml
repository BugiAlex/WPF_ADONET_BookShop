   M S B A M L   `   `   `  ����D  @Book_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Book_Shop	Book_Shop  5   	   $    Book_Shop.ConDeleteLanguageWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Book_Shop     5   	     � Title$  System message��5   	   $	��200��6    $	��400��6-    � WindowStartupLocation$ CenterScreen=�6:    � 	Resources 5	   
      ButtonTemplate �� 
TargetType �� CornerRadius �� TextAlignment �� StrokeDashArray �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value��%�  &	        �� 5
   
   " ��61   .R�5      �� $��Border��5   9   
����  �$��3q�5   (   $ 10��6<   
���   �
��� ���$ Center=�5   G   ._�5      � .+�5      �� $��FocusCue��6    $y�Hidden=�60   
����  �$��1��5      $	 1 2R�6    68   �� 5      ��. #��z��5   
   6/   5      5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 Border��6    � ��
 ��  �6G   5      P� 5       � ��	 . . �5      �� $
 Border��6    � ��
 � ���6G   �� 5      $
 Border��6    � ��
 �k���6H   5      P� 5       �@J�IsKeyboardFocused	 . . �5      �� $
 FocusCue��6    � y�$ Visible=�6I   5      P� 5       � {�	 .  . �5       �� $
 Border��6    � ��
 �����6Q   �� 5!      $
 Border��6    � ��
 �   �6G   5"      5%      5'      ��5(      �� 5)   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5*      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5+      $ 	#FF06C4EE��6   $ 1Q�6-   5,      .��5.      �  � RowDefinitions 5/   
   �� 50      $��2* �6   6*   �� 51      $��* �6   6)   .+�54   
   �� -   5         ��Name$ 
WindowMess��54      $��Center=�6(   $��10q�6E   $
��Wrap=�6Q   $��Center=�6f   
��� ���$��Cooper Black)�6�   $��Italic$�6�   $��14(�6�   �� 55   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�56      �� -   5        #��[  56      $��Ok��6@   $��10,10,20,20q�6O   $��Bottom=�6d   $��74��6   ��6�   �� *DeleteLanguageCommand+6�   �� 57      -   5        #��[  57      $��Cancel��6@   $��10,10,20,20q�6S   $��Bottom=�6h   $��74��6�   6�   58      5:      5;      