   M S B A M L   `   `   `  ���� F  BCardService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CardServiceCardService  E AUsrControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UsrControl;assembly=UsrControl
UsrControl     CardService.AddCardPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:CardService     @usrCtrl,clr-namespace:UsrControl;assembly=UsrControl       N� Title$  AddCardPage��.���  � RowDefinitions �� $��* ��� $��80 �.+�� $��0��$	��400��$	��250��$��Center=�$��Center=�.+�  UsrControl.Card  � $��1��$��Center=�$��Center=�����  �� Color$ White�� �� $��* ��� $��80 �.+��� -    ��Name$ btnPop��$��1��   btnManagement#���   ��(� $��13��.���� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     -    ��Name$ Document��$��571.057��$��497.05�� J� Clip4 ��        �h�	"    �h�	"�a��    �a��         � UseLayoutRounding .  .+��� -   $ Layer_1��$��100.01��$��50.005�� �� Left$ 0��
 �� Top$ 0��.+��� -   	 ��Name$	 	Rectangle��$��571.057��$��28.0027��$ 0��$ 230.393��
 �� Stretch$

 Fill=� �� StrokeLineJoin$ Round=����	#FF000000���	#FF000000F� -    F�Name$
 Path��$��44.0501��$��497.05��$ 272.239��$ -6.10352e-005��$

 Fill=�$ Round=����	#FF000000
���iii�4����X��p���Ȏ��� �(~v� Ѹ�Ah���X��p��� -    �Name$	 Pop�� � VerticalOffset$ -5�� � HorizontalOffset$	 -30��$��Scroll=�$	��100��$	��Top=� � AllowsTransparency .  � 	StaysOpen .   � PlacementTarget ��  �� ElementName$ btnPop��.���� 
������  �� CornerRadius$ 5�����#F0F0F0$��1q�._��� .+��� -   $ btnSave��$��保存��  popManagement#���  �� -   $ btnReset��$��重置��#���   � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius    Color��%�  &	       &	  �     �� " ��.���  � ��
 �������  � ��$ 27����  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#F5F5F5�� " ��.���  � ��$ 0 0 0 10q���  � ��$ 40����  � ��$ 40����  � ��
 �������  � �� �� " ��.R��� $ 20��#��z��$��1q�
�������   $ -4Q�$ 5Q�$  	LightGray��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � �� �#F5F5F5��  � �� (� $��13��.���� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     $ Document��$��451.556��$��451.993��4 ��        Ѡ2�    Ѡ2�����    ����         .  .+��� $ Layer_1��$��99.9018��$��49.9992��$ 0��$ 0��.+�F� $
 Path��$��451.556��$��428.357��$ -3.05176e-005��$ 17.0231��$

 Fill=�$ Round=����	#FF000000���	#FF0000004���𘏟�aр�� ���УJ�T��� ���ј���aF� $ Path_0��$��427.889��$��451.993��$ 8.49246��$ -6.10352e-005��$

 Fill=�$ Round=����	#FF000000���	#FF0000004�����6� ��QѨ-I� �(����;�<���6� ��Q