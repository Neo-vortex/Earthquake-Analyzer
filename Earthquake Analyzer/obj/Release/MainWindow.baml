   M S B A M L   `   `   `  ���� N  JEarthquake Analyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Earthquake_AnalyzerEarthquake_Analyzer  $    Earthquake_Analyzer.MainWindow   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Earthquake_Analyzer     R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf    � Title$  Earthquake Analyzer��$��626.6��$��1029.115��(  "MahApps.Metro.Controls.MetroWindow   TitleCharacterCasing$ Normal=�.��� .+��� -    ��Name$ textbox1��$
��Left=�$��23��$��	50,14,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��802��{�.  �� $
��Left=�$��8,20,0,0q�$
��Wrap=�$��Folder: ��$	��Top=��� -   $��Browse��$
��Left=�$��
857,13,0,0q�$	��Top=�$��75�� J� RenderTransformOrigin$ 2.205,4.537&��� 
���   �$��1q�$
��Left=�$��58��$��	8,524,0,0q�$	��Top=�$
��1004��._�� -    �Name$ progress��$
��Left=�$��9��$	��Top=�$	��984��$��9.2,37.2,0,0 q��� -    ��Name$ status��$
��Left=�$��
15,534,0,0q�$
��Wrap=�$��Ready��$	��Top=�$ 
4.4,-9.944&��� -    ��Name$
 tabs��$
��Left=�$	��459��$��	10,58,0,0q�$	��Top=�$
��1002��{�.  .@��� $��X Axis�� �� 
IsSelected . .��� ���	#FFE5E5E5.+��� 
���   �$��1q�$
��Left=�$	��356��$��	10,12,0,0q�$	��Top=�$	��976��._�  OxyPlot.Wpf.PlotView  -   	  Name$	 plot1��$��9.2,9.2,9.4,9.6q���Z� �� -   $ minmax1��$
��Left=�$��
10,373,0,0q�$
��Wrap=�$��	Max -Min=��$	��Top=�
���   ��� -   
 ��Name$
 save1��$��	Save Plot��$
��Left=�$��466,379,0,0q�$	��Top=�$��71��$��17���� $��Y Axis��.��� ���	#FFE5E5E5.+��� 
���   �$��1q�$
��Left=�$	��360��$��	10,12,0,0q�$	��Top=�$	��976��._�  -	   $	 plot2��$��9.2,9.2,9.4,9.6q���Z� �� -
   $ minmax2��$
��Left=�$��
10,377,0,0q�$
��Wrap=�$��Max-Min=��$	��Top=�
���   ��� -   $
 save2��$��	Save Plot��$
��Left=�$��487,379,0,0q�$	��Top=�$��71��$��17���� $��Z axis��$
��Left=�$
��39.2��$	��Top=�$��105.6��.��� ���	#FFE5E5E5.+��� 
���   �$��1q�$
��Left=�$	��362��$��	10,12,0,0q�$	��Top=�$	��976��._�  -   $	 plot3��$��9.2,9.2,9.4,9.6q���Z� �� -   $ minmax3��$
��Left=�$��
10,379,0,0q�$
��Wrap=�$��Max-Min=��$	��Top=�
���   ��� -   $
 save3��$��	Save Plot��$
��Left=�$��515,379,0,0q�$	��Top=�$��71��$��17���� $��All in One X��$
��Left=�$��39��$	��Top=�$	��155��$��
0,-0.2,0,0q�.��� ���	#FFE5E5E5.+��� 
���   �$��1q�$
��Left=�$	��360��$��	10,12,0,0q�$	��Top=�$	��976��._�  -   $	 plot4��$��9.2,9.2,9.4,9.6q���Z� �� -   $��	Save Plot��$
��Left=�$��495,377,0,0q�$	��Top=�$��71���� $��Single Mean X��$
��Left=�$��39��$	��Top=�$	��163�� . $��0.4,0,-57.8,0q�.��� ���	#FFE5E5E5$��0,0,0.2,0.4q�.+��� 
���   �$��1q�$
��Left=�$	��360��$��	10,12,0,0q�$	��Top=�$	��976��._�  -   $	 plot5��$��9.2,9.2,9.4,9.6q���Z� �� -   $
 save4��$��	Save Plot��$
��Left=�$��463,377,0,0q�$	��Top=�$��71���� $��Repeated Mean X��$
��Left=�$��39��$	��Top=�$	��203��$��0.2,-0.2,0,0q�.��� ���	#FFE5E5E5$��0,0,0.2,0.4q�.+��� 
���   �$��1q�$
��Left=�$	��360��$��	10,12,0,0q�$	��Top=�$	��976��._�  -   $	 plot6��$��9.2,9.2,9.4,9.6q���Z� �� -   $
 save5��$��	Save Plot��$
��Left=�$��468,377,0,0q�$	��Top=�$��71���� $��	Reduced X��$
��Left=�$
��39.2��$	��Top=�$��153.6��.��� ���	#FFE5E5E5.+��� 
���   �$��1q�$
��Left=�$	��368��$��	10,12,0,0q�$	��Top=�$	��976��._�  -   $	 plot7��$��9.2,9.2,9.4,9.6q���Z� �� -   $��Process��$
��Left=�$��
937,13,0,0q�$	��Top=�$��75��