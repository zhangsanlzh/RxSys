   M S B A M L   `   `   `  ���� E  AFirstPages, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FirstPages
FirstPages  E AUsrControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UsrControl;assembly=UsrControl
UsrControl =#clr-namespace:FirstPages.PropertiesFirstPages.Properties      FirstPages.Page0   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:FirstPages     @usrCtrl,clr-namespace:UsrControl;assembly=UsrControl     2dd#clr-namespace:FirstPages.Properties       N� Title$  Page0�� � 	Resources    ButtonCheckedColor  ButtonMouseEnterColor  LeftPnlBgColor �� 
TargetType  SearchResultBoxStyle �� Property �� Value  ListItemStyle �� 
TargetType �� Triggers P� Property P� Value	 ]� 
Conditions
 �� Property �� Value��%b  &	        &	      &	 "     &	 3     &	 �     ��#67CEFF����#89D8FF����#F7F7F7���� " ��.���  � ��$ 0q���  � ��$ 0q���  � ��$ Disabled=���  � ��$ Hidden=��� " ��.���  � ��$ 30����  � ��$ 15(���  � �� �#5D5D5D��  � �� �� " ��.R��� #��z��._��� $��12 0 0 0q�$
��Left=�$��Center=� P�  �@��
IsSelected .  ���  � �� �#007ACC��  � �� �#F1F1F1]� 	 �� 
 �@J�IsMouseOver . �� 
 �@��
IsSelected .  ./���  � �� �#F1F1F1��  � �� �#56B8FF.���  � ColumnDefinitions �� $��2* ��� $��4* ��� $��1* �.+�� $��0��$	��558��$��Bottom=�����  �� Color# [  � RowDefinitions �� $��* ��� $��40 �.+��� $��0��.+��� -    ��Name$ txtBox��  txtBoxStyle#���  �� -    ��Name$ listBox��#��[ $y�	Collapsed=��� -   $ HiddenTextBox��$��0��� $��1������ $ White��.+��   gridPnlStyle#���  $	��350��$	��520�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ -4Q�   
BlurRadius$ 5Q�   Color$ 	LightGray��.+�� $	��300�� �� $
��auto ��� $��* ��� $��50 �.+��� $��0��.+�� .+��� $��Center=�$��0 10 0 0q�$��处方��$��18(�$
��Bold"���  �� Orientation$ 
Horizontal=�$��0 12 0 5q�.+��� $��姓名��$��11(�$
��Bold"�$��Center=�  UsrControl.InforLabel  -     Name$ ucName��   Text$ 张三��   FontSize$ 14��   MaxWidth$	 100��   	MaxHeight$ 50���� $��性别��$��黑体)�$��12(�$
��Bold"�$��Center=�$��20 0 5 0q��� -    ��Name$ cmbSex�� �� SelectedIndex$ 0��  comboBoxStyle#���  .@��� $	��男���� $	��女�� ��%�   &	       '�� S     �� " ��.���  � ��$ 45����  � ��$ 25����  � ��$ Center=��� " ��.���  � ��$ 20���� $��年龄��$��黑体)�$��12(�$
��Bold"�$��Center=�$��20 0 0 0q�  -   $ ucAge��$ 20��$ 14��$ 25���� $ 
Horizontal=�.+��� $��诊断��$��11(�$
��Bold"�$��Center=�  -   $ ucDiagnosis_desc��$ 脾胃失调��$ 14���� -    ��Name$ stackPnlList��$��1��.+��� 
���   �$��1q�$��0 5 0 5q��� $��用药��$��11(�$
��Bold"�$��Center=�$��0 5 0 12q��� $	��300��$��Hidden=���. .��� -	    �Name$ wrapPnl��$��0��$
��Left=�  wrapPnlStyle#���  � $��2�� �� $
��auto ��� $��* ��� $
��auto �.+�  UsrControl.TotalInfor  -
     Name$ 
totalInfor��    Count$  0��!   Costs$! 0���� $��2��$��Center=�.+��� -   " ��Name$" txtDoctorName��$��李四��$��12(�$
��Bold"�$��Center=�$��Center=�$��0 4 0 3q��� -   $" txtDateTime��$��	2018-6-25��$��11(�$��Center=�$��Right=�$��0q� ��%�   &	       &	 @     �� " �.���  � ��$ 0 1 0 0q���  � ��
 ������� " �.���  � ��$ 22 0 0 5q���  � ��$	 Top=���  � ��$ 60����  � ��$	 300����  �@�Orientation$ 
Horizontal=�� $��2������ $ White�� �� $��* ��� $��80 �.+��� -   # ��Name$# btnPop��$��1�� 	 btnManagement#��� 	 ��(� $��13��.���� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     -   $ ��Name$$ Document��$��571.057��$��497.05��% J� Clip4% ��        �h�	"    �h�	"�a��    �a��        & � UseLayoutRounding& .  .+��� -   $$ Layer_1��$��100.01��$��50.005��' �� Left$' 0��
( �� Top$( 0��.+��� -   ) ��Name$) 	Rectangle��$��571.057��$��28.0027��$' 0��$( 230.393��* �� Stretch$
* Fill=�+ �� StrokeLineJoin$+ Round=����	#FF000000���	#FF000000F� -   , F�Name$
, Path��$��44.0501��$��497.05��$' 272.239��$( -6.10352e-005��$
* Fill=�$+ Round=����	#FF000000
���iii�4����X��p���Ȏ��� �(~v� Ѹ�Ah���X��p��� -   - �Name$	- Pop��. � VerticalOffset$. -5��/ � HorizontalOffset$	/ -30��$��Scroll=�$	��100��$	��Top=�0 � AllowsTransparency0 . 1 � 	StaysOpen1 .  2 � PlacementTarget2 �� 3 �� ElementName$3 btnPop��.���� 
������ 4 �� CornerRadius$4 5�����#F0F0F0$��1q�._��� .+��� -   $# btnSave��$��保存�� 
 popManagement#��� 
 �� -   $# btnReset��$��重置��#��� 
 � -   $- herbPop��$. -5��$	/ -30��$��Scroll=�$	��100��$	��Top=�0 . 1 .  .���� 
������ $4 5��
�������$��1q�._��� .+��� -   $# 	btnDelete��$��删除��#��� 
  5 �� Triggers6 ��Name��%�  &	
       &		 �     &	 �    �� " ��.���  � ��
 �������  � ��$ 27����  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#F5F5F5�� " ��.���  � ��$ 0 0 0 10q���  � ��$ 40����  � ��$ 40����  � ��
 �������  � �� �� " ��.R��� $4 20��#��z��$��1q�
�������   $ -4Q�$ 5Q�$ 	LightGray��._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#F5F5F5��  � �� (� $��13��.���� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     $$ Document��$��451.556��$��451.993��4% ��        Ѡ2�    Ѡ2�����    ����        & .  .+��� $$ Layer_1��$��99.9018��$��49.9992��$' 0��$( 0��.+�F� $
, Path��$��451.556��$��428.357��$' -3.05176e-005��$( 17.0231��$
* Fill=�$+ Round=����	#FF000000���	#FF0000004���𘏟�aр�� ���УJ�T��� ���ј���aF� $, Path_0��$��427.889��$��451.993��$' 8.49246��$( -6.10352e-005��$
* Fill=�$+ Round=����	#FF000000���	#FF0000004�����6� ��QѨ-I� �(����;�<���6� ��Q�� " ��.���  � ��$ 0 0 0 0q���  � ��$ 35����  � ��$ 12(���  � �� �#EBEBEC��  � ��
 �iii���  � ��$5 /输入药品拼音简称搜索，如当归，dg����  � �� �� " ��.R��� #��z��$��1q����� $ White��._��� $6 PART_ContentHost��$��Center=�$��12 0 0 0q�5 P�  �@J�	IsFocused . . ���  � �� �#89D8FF��  � ��$ 1q�P�  �@J�IsMouseOver . . ���  � �� �#89D8FF��  � ��$ 1q�