   M S B A M L   `   `   `  ����E  AUsrControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UsrControl
UsrControl  5   	       UsrControl.RxDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:UsrControl     5   	   -   5          � Title$  RxDialog��5   	   $	��200��5	   	   $	��300��6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 
ResizeMode$ CanMinimize=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6   .��5      �� 
�������$��1q�6%    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6   	   ShadowDepth$	 -4Q�6.   
   Color$
 	LightGray��6?   ._�5   
   � .+�5      �� -   5         ��Name$ 
txtMsgInfo��5   ;   $��50,40,48,69q�6   $��14(�6-   $
��Wrap=�6O    J� RenderTransformOrigin$ 0.5,0.5&�6c   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 1.548Q�6(   �� 5      T� 5       T� X$ 0.973Q�6-   5      5!      �� 5"      -   5         ��Name$	 yes��5"   !   $	��是��6   $
��Left=�6.   $��
60,140,0,0q�6I   $	��Top=�6]   $ 
-2.757,0.9&�6u   6�   �� 5#      -   5        $ no��5#   !   $	��否��6   $
��Left=�6-   $��162,140,0,0q�6H   $	��Top=�6]   $ 
-2.757,0.9&�6u   6�   5$      5%       � 	Resources 5'       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  '��       �� 5(   
   " ��6   .�5)      ��  � ��$ 11(�6)   �� 5*       � ��$ 26��6'   �� 5+       � ��$ 60��6&   �� 5,       � ��
 ���� 6+   �� 5-       � �� 5.      �� 5/      " ��6&   .R�50      �� #��z��6!   ���#EAEAEA$	��0.3q�6a   ._�51      �� $��Center=�6/   $��Center=�6L   52       54      P� 55       �@J�IsMouseOver . . �56   "   ��  � �� �#F5F5F56?   57      59      5;      5<      5=      5@      