   M S B A M L   `   `   `  ���� F  BDataService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DataServiceDataService      DataService.DataRecover   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:DataService       N� Title$  DataRecover��.���  � RowDefinitions �� $��50 ��� �� �� .+��� $��1��.+��� -    ��Name$ wrapPnl�� �� Orientation$ 
Horizontal=�$��Center=�   stackPnlStyle#���   .+��� $��80��$��1��$��conslas)����#B8B8B8$��35(� �� TextAlignment$ Center=�$��Center=��� -    ��Name$ txtBox��  txtBoxStyle#���   � ToolTip$W Q从指定位置恢复数据，可以是USB或其他挂载到本机的移动设备���� -    ��Name$ RecoverFromLocal��  popManagement#���  $��70��$��35��$��选择目录���� 
�������$��	25 50 0 0q�$	��0.3q�$	��500���� $	��450��$��2��$��25 0 0 0q�$ 
Horizontal=�$��Center=�#���   .+��� $��80��$��2��$��conslas)����#B8B8B8$��35(�$ Center=�$��Center=��� -   $ BackUpToCloud��#���  $��70��$��35��$��从云端恢复�� � 	Resources 	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value �� Color ��Name��%�  &	       &	 	    &	  "    �� "	 ��.��� 
 � �� �#F5F5F5�� 
 � �� �#EBEBEC�� 
 � ��$ 1q��� 
 � ��$ 27���� 
 � �� �� " ��.R��� #��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 
 � ��
 ������� "	 ��.��� 
 � ��$ 0 0 0 0q��� 
 � ��$ 35���� 
 � ��$ 12(��� 
 � �� �#EBEBEC�� 
 � ��
 �iii��� 
 � ��$! 从指定目录恢复数据���� 
 � ��$	 300���� 
 �@��
IsReadOnly . �� 
 � �� �� " ��.R��� #��z��$��1q����� $ White��._��� $ PART_ContentHost��$��Center=�$��12 0 0 0q� P�  �@J�	IsFocused . . ��� 
 � �� �#89D8FF�� 
 � ��$ 1q�P�  �@J�IsMouseOver . . ��� 
 � �� �#89D8FF�� 
 � ��$ 1q��� "	 ��.��� 
 � ��$ 22 0 0 5q��� 
 � ��$	 Top=��� 
 � ��$ 60��