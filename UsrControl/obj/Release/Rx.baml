   M S B A M L   `   `   `  ���� E  AUsrControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UsrControl
UsrControl      UsrControl.Rx   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:UsrControl     .��(� $	��250��.���    gridPnlStyle#���   $	��350��$	��520��  J� Effect  3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ -4Q�   
BlurRadius$ 5Q�   Color$ 	LightGray��.+�� $	��300�� � RowDefinitions �� $
��auto ��� $��* ��� $��50 �.+��� $��0��.+�� .+��� $��Center=�$��0 10 0 0q�$��处方��$��18(�$
��Bold"���  �� Orientation$ 
Horizontal=�$��0 12 0 5q�.+��� $��姓名��$��11(�$
��Bold"�$��Center=�   UsrControl.InforLabel  -     Name$ ucName��   Text$ 张三��   FontSize$ 14��	   MaxWidth$		 100��
   	MaxHeight$
 50��   ReadOnly$
 true���� $��性别��$��黑体)�$��12(�$
��Bold"�$��Center=�$��20 0 5 0q�  -   $ ucSex��$	 男��$ 14��$		 100��$
 50��$
 true���� $��年龄��$��黑体)�$��12(�$
��Bold"�$��Center=�$��20 0 0 0q�  -   $ ucAge��$ 20��$ 14��$
 25��$
 true���� $ 
Horizontal=�.+��� $��诊断��$��11(�$
��Bold"�$��Center=�  -   $ ucDiagnosis_desc��$ 脾胃失调��$ 14��$
 true���� -    ��Name$ stackPnlList��$��1��.+��� 
���   �$��1q�$��0 5 0 5q��� $��用药��$��11(�$
��Bold"�$��Center=�$��0 5 0 12q��� $	��300��$��Hidden=���. .��� -    �Name$ wrapPnl��$��0��$
��Left=�� $��2�� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+�   UsrControl.TotalInfor  -     Name$ 
totalInfor��   Count$ 0��   Costs$ 0���� $��2��$��Center=�.+��� -    ��Name$ txtDoctorName��$��李四��$��12(�$
��Bold"�$��Center=�$��Center=�$��0 4 0 3q��� -	   $ txtDateTime��$��	2018-6-25��$��11(�$��Center=�$��Right=�$��0q� � 	Resources  �� 
TargetType �� Property �� Value��%J   &	        �� " �.���  � ��$ 5 5 0 5q���  � ��
 �����