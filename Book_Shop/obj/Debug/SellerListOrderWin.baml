   M S B A M L   `   `   `  ����D  @Book_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Book_Shop	Book_Shop  5   	   "    Book_Shop.SellerListOrderWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Book_Shop     5   	     � Title$  
Order List��5   
   $	��450��6   $
��1500��6*    � WindowStartupLocation$ CenterScreen=�67    � 	Resources 5
         ButtonTemplate �� 
TargetType �� CornerRadius �� TextAlignment �� StrokeDashArray �� Triggers P� Property	 P� Value
 �� 
TargetName �� Property �� Value��%�  &	        �� 5   
   " ��61   .R�5      �� $��Border��5   9   
����  �$��3q�5   (   $ 10��6<   
���   �
��� ���$ Center=�5   G   ._�5      � .+�5      �� $��FocusCue��6    $y�Hidden=�60   
����  �$��1��5      $	 1 2R�6    68   �� 5      ��. #��z��5   
   6/   5      5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 Border��6    � ��
 ��  �6G   5      P� 5       � ��	 . . �5      �� $
 Border��6    � ��
 � ���6G   �� 5      $
 Border��6    � ��
 �k���6H   5      P� 5       �@J�IsKeyboardFocused	 . . �5      �� $
 FocusCue��6    � y�$ Visible=�6I   5      P� 5        � {�	 .  . �5!      �� $
 Border��6    � ��
 �����6Q   �� 5"      $
 Border��6    � ��
 �   �6G   5#      5&      5'      ��5(      �� 5)   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5*      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5+      $ 	#FF06C4EE��6   $ 1Q�6-   5,      .��5.      �  � RowDefinitions 5/   
   �� 50      $��* �6   �� 51      $
��Auto �6   .+�54   
   �� -   5         ��Name$ Listbox1��54   *   $��2��6   $��16(�6�   $
��Bold"�6�   $��Sitka Heading)�6�   
���������6<   �� *BooksInOrder+ �� SelectedIndex 6b   �� *%#Index_book_in_order_list_for_delete+��55      �� 56      $ 0.5,1&�6&   $ 0.5,0&�67   .��57      � $ Black��6#   $ 0Q�61   � 58      $ 	#FF02C6F1��6#   $ 1Q�65   59       �� View 5<      �� 5=      .P�5>      �� $
��Name��6%    �� Width$	 200��63    �� DisplayMemberBinding 6?   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� 5?      $
��Year��6%   $	 100��64    6@   �� *	Year_edit+$ PropertyChanged=��� 5@      $��Pages��6%   $	 100��65    6A   �� *Pages+$ PropertyChanged=��� 5A      $��Language��6%   $	 100��68    6D   �� *
Language+$ PropertyChanged=��� 5B      $��
Publishing��6%   $	 150��6:    6F   �� *
Publishing+$ PropertyChanged=��� 5C      $��Author��6%   $	 200��66    6B   �� *Author+$ PropertyChanged=��� 5D      $��Genre��6%   $	 100��65    6A   �� *Genre+$ PropertyChanged=��� 5E      $��Stock��6%   $	 100��64    6@   �� *Stock+$ PropertyChanged=��� 5F      $��Price��6%   $	 100��64    6@   �� *Price+$ PropertyChanged=��� 5G      $��Сost price��6%   $	 100��69    6E   �� *
Cost_price+$ PropertyChanged=��� 5H      $��Count books��6%   $	 100��6:    6F   �� *
Count_Book+$ PropertyChanged=�5I      5K      �� 5L   
   $��1��6    �� Orientation$ 
Horizontal=�6#   $��Right=�6<   .+�5M      �� $��Remove book from order��6   $��10q�68   $	��300��6D   #��[  6P   $��16(�6�   $��
Constantia)�6�   $��Italic$�6�   $
��Bold"�6�   ��6|   �� *DeleteBookFromOrderCommand+6�   5N      5O      5P      