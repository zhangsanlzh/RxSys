   M S B A M L   `   `   `  ���� E  AUsrControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UsrControl
UsrControl      UsrControl.Herb   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:UsrControl     -     >�Name$
  herb��.���� ._�� -    �Name$ gridPnl��$��0 0 4 4q�   gridPnlStyle#���    � RowDefinitions �� $��3* ��� $��1* �.+��� -    ��Name$ txtBlockHerbName��$��Center=�$
��Wrap=�$��Center=�$��70��$��0��$��12(� �� Padding$ 10q�
���   �$��微软雅黑)��� -    ��Name$ txtBoxHerbGram��$��1��$��Right=�$��Bottom=�$��0 0 5 5q�$��12(�  txtBoxStyle#���   � ContextMenu Z� � -    �Name$ herbPop�� � VerticalOffset$	 -10��$��Scroll=�$��50��$��Right=�	 � AllowsTransparency	 . 
 � 	StaysOpen
 .   � PlacementTarget ��  �� ElementName$ gridPnl��.���� 
������ 
�������$��1q�._��� .+��� -    ��Name$ 	btnDelete��$��删除��  popManagement#���   � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value ��Name �� Triggers��%�  &	       &	 �     &	  �    �� " ��.���  � ��
 �������  � ��$ 20����  � ��$ 11(���  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#F5F5F5�� " ��.���  � {� .  ��  � �� �� " ��.R��� $ PART_ContentHost��$��Center=�$��12 0 0 0q� P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand���� " �.���  � �� �#D1E8FF