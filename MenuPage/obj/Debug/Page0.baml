   M S B A M L   `   `   `  ����C  ?MenuPage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MenuPageMenuPage  5          MenuPage.Page0   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:MenuPage     5        N� Title$  Page0��5	       � 	Resources 5         	SysButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value  	FucButton	 �� CornerRadius��%k  &	        &	 �    �� 5   
   " ��6"   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 0q�60   �� 5       � ��$ 40��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  � ��
 �����6?   5      5      5      5       �� 5"   
   " ��6"   .�5#      ��  � ��
 ���� 6+   �� 5$       � ��$ 12(�6)   �� 5%       � ��$ 微软雅黑)�6+   �� 5&       � ��$ 1q�60   �� 5'       � ��
 ���� 6,   �� 5(       � ��$	 100��6&   �� 5)       � ��$	 100��6'   �� 5*       � ��$ 0 0 15 5q�6'   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� $	 5��6!   #��z��62   #��z��6\   #��z��6�   ._�50      �� $��Center=�6/   $��Center=�6L   51       53      P� 54       �@J�IsMouseOver . . �55   "   ��  � �� �#6CE26C6@   56      58      5:      5;      5<      .��5>      �� ._�5?   
   � 
 � RowDefinitions
 5@      �� 5A      $��40 �6    6.   �� 5B      $��* �6    6-   .+�5E      � -   5         �Name$ gridContent��5E       $��1��6    � ColumnDefinitions 5F      �� 5G      $
��485* �6'   �� 5H      $
��313* �6'   .+�5J      �  � Orientation$ 
Horizontal=�6   $	��Top=�65   $��Center=�6M   $��174,100,157,0q�6j   $	��467��6�   $��2��6�   .+�5K      �� -   5         ��Name$
 btn0��5K   y   #��[ 6   ���#FFF199$��中药开方��6U   6y   �� 5L      -   5        $
 btn2��5L   {   #��[ 6   ���#FFBF98$��中药处方管理��6U   6{   �� 5M      -   5        $
 btn1��5M   y   #��[ 6   ���#C1FF98$��中药入库��6U   6y   �� 5N      -   5        $
 btn3��5N   y   #��[ 6   ���#CB98FF$��营业统计��6U   6y   �� 5Q      -   5        $
 btn6��5Q   y   #��[ 6   ���#BCCB43$��数据备份��6U   6y   �� 5R      -   5        $
 btn7��5R   y   #��[ 6   ���#9DCB46$��数据恢复��6U   6y   5S      5T      5U      5V      5W      